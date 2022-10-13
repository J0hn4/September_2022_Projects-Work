namespace Model;

public class User
{

    //Users information variables
   
    public string LogInName
    { get; set; }
    public string Password
    { get; set; }
    public bool IsManager
    { get; set; } = false;

    public User(string loginName, string password){

        this.LogInName = loginName;
        this.Password = password;
        // this.IsManager = isManager;

    }
}