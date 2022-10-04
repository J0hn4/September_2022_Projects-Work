using System;

namespace Expenses {

    class User {

    public string name;
    public string Name 
        {
          get { return name; }
          set { name = value; }
        }


    public bool isManager;
    public bool IsManager 
        {
          get { return isManager; }
          set { isManager = value; }
        }


    public string password;
    public string Password 
    {
      get { return password; }
      set { password = value; }
    }
    
    public bool isLoggedIn;

    public bool IsLoggedIn
     {
      get { return isLoggedIn; }
      set { isLoggedIn = value; }
    }

    private bool isApproved;
    private bool IsApproved
        {
          get { return isApproved; }
          set { 
              if (this.IsManager)
              {
                IsApproved = value;
              }
    

    

    

    
        //   else
        //   {
        //     biome = "Unknown";
        //   }




    }






}