using System;

    namespace Expenses {

 

        class FormApproval {

            public bool IsManager;
            public bool IsLoggedIn;
            public bool isFormApproved = false;


            public FormApproval() 
            {
                this.IsManager = user.IsManager;
                this.IsLoggedIn = user.IsLoggedIn;
                this.isFormApproved = false;
            }

            public Approve(User user, Form form)
            {
                System.Console.Write("Would you like to approve this form?\nIf yes, then please type 'y' :");
                string result = ReadLine().ToLowerCase();
                if (result == "y") 
                {
                    FormApproval.isFormApproved = true;
                    System.Console.WriteLine("The expense form has been APPROVED.");
                }
                else 
                {
                    System.Console.WriteLine("The expense form has NOT BEEN APPROVED");
                }
            }



            private bool isApproved = false;
            private bool IsApproved
                {
                get { return isApproved; }
                set 
                { 
                    if (IsManager)
                    {
                        IsApproved = value;
                    }
                }

                // public FormApproval(User user, Form form) 
                // {
                //     // if user.isManager == true, he can set the form to approved or not approved



                // }

            }
    }
}