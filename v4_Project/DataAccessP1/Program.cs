using Model;
using Microsoft.Data.SqlClient;

namespace Database;

    
public class DatabaseClass
{

    public static void Main(string[] args)
    {
        List<User> userList = getAllUsers();
        foreach (User user in userList) {
            System.Console.WriteLine(user.LogInName);
        }
        createUser("'newMan5'","'passwordzzz242'", true);
        // List<User> userList = getAllUsers();
        foreach (User user in userList) {
            System.Console.WriteLine(user.LogInName, user.Password);
        }
    }

    public static List<User> getAllUsers() {

        // Creates connection with the database
        SqlConnection connection = new SqlConnection("Server=tcp:xavierreavtureserver.database.windows.net,1433;Initial Catalog=Project-1;Persist Security Info=False;User ID=maxWayne44990;Password=ILovePizza##11;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        connection.Open();  // Opens connection

        // creates SqlCommand object, used to query the UserObjects table from the Azure SQL DB
        SqlCommand command = new SqlCommand("SELECT * FROM UserObjects", connection);
        SqlDataReader reader = command.ExecuteReader();

        List<User> returnList = new List<User>();

        // checks to see if table is empty
        if(reader.HasRows){

            // read.HasRows reads each line in the table until it does not exist
            while(reader.Read()){
                // gets the user info from the row
                string queriedLoginName = (string)reader["loginName"];
                string queriedPassword = (string)reader["password"];
                

                // creates the user object to be returned
                User user = new User(queriedLoginName, queriedPassword);
                returnList.Add(user);
        
                
            }

            Console.WriteLine("Database table is empty");
        }

        return returnList;

        connection.Close();
        return null; 
    }

    // this class retrieves a specific user's info from Azure SQL database and converts DB row into USEROBJECTS object 
    public static User getUser(string loginName, string password){


        // Creates connection with the database
        SqlConnection connection = new SqlConnection("Server=tcp:xavierreavtureserver.database.windows.net,1433;Initial Catalog=Project-1;Persist Security Info=False;User ID=maxWayne44990;Password=ILovePizza##11;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        connection.Open();  // Opens connection

        // creates SqlCommand object, used to query the UserObjects table from the Azure SQL DB
        SqlCommand command = new SqlCommand("SELECT * FROM UserObjects", connection);
        SqlDataReader reader = command.ExecuteReader();

        // checks to see if table is empty
        if(reader.HasRows){

            // read.HasRows reads each line in the table until it does not exist
            while(reader.Read()){

                // gets the user info for whoever is logged in
                if((string)reader["loginName"] == loginName && (string)reader["password"] == password){

                    string queriedLoginName = (string)reader["loginName"];
                    string queriedPassword = (string)reader["password"];
                    string queriedIsManager = (string)reader["isManager"];

                    User user = new User(queriedLoginName, queriedPassword);
                    return user;
                }
                
            }

            Console.WriteLine("Database table is empty");
        }

        connection.Close();
        return null; 
    }




    public static void createUser(string loginName, string password, bool IsManager){

        SqlConnection connection = new SqlConnection("Server=tcp:xavierreavtureserver.database.windows.net,1433;Initial Catalog=Project-1;Persist Security Info=False;User ID=maxWayne44990;Password=ILovePizza##11;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        connection.Open();

        // int id = (int)command.Executescalar() ;

        int managerType;
        if (IsManager) {
            managerType = 1;
        }
        else {
            managerType = 0;
        }

        SqlCommand command = new SqlCommand($"INSERT INTO UserObjects (loginName, password) VALUES(@loginName, @password)", connection);
        command.Parameters.AddWithValue("@loginName",loginName);
        command.Parameters.AddWithValue("@password",password);
        int affectRows = command.ExecuteNonQuery();
        Console.WriteLine("Created a new User row");
        Console.WriteLine("Affect rows: " + affectRows);

        connection.Close();
    }
}