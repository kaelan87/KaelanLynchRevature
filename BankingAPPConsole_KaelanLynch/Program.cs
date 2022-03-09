using System;

namespace BankingAPPConsole_KaelanLynch
{
    class Program
    {
        static void Main(string[] args)
        {
           
           accNo = 000456789455;
           accName = "Kaelan Lynch";
           accType = "Checking";
           accBalance = 1000;
           accIsActive = true;
           accEmail = "kdog93@gmail.com";

        Accounts acct = new Accounts();
#region Menu
        Console.WriteLine("1. Create New Account");
        Console.WriteLine("2. Check Balance");
        Console.WriteLine("3. Withdraw");
        Console.WriteLine("4. Deposit");
        Console.WriteLine("5. Get Details");
        Console.WriteLine("6. Exit");
        Console.WriteLine("PLEASE SELECT AN OPTION");

    switch(acct){
        case 1: //CREATE ACCOUNT??
        break;
        case 2: checkBalance();
        break;
        case 3: withdraw();
        break;
        case 4: deposit();
        break;
        case 5: getAccountDetails();
        break;
        case 6: System.Exit();
        break;
        default: System.Console.WriteLine("Please enter one of the above options");
        break;
    }
#endregion
    }
    class Accounts
    {
#region Properties
        public int accNo { get; set; }
        public string accName { get; set; }
        public string accType { get; set; }
        public double accBalance { get; set; }
        public bool accIsActive { get; set; }
        public string accEmail { get; set; }
#endregion
#region Account Methods
   void withdraw(int accBalance)
   {
       System.Console.WriteLine("Enter an amount to withdraw");
       accBalance = accBalance - (Convert.ToInt32Console.ReadLine());
       System.Console.WriteLine(accBalance);
   }
   void deposit(int accBalance)
   {
        System.Console.WriteLine("Enter an amount to deposit");
       accBalance = accBalance + (Convert.ToInt32Console.ReadLine());
       System.Console.WriteLine(accBalance);

   }
   static void getAccountDetails(){
       Console.WriteLine(acct.accNo);
       Console.WriteLine(acct.accName);
       Console.WriteLine(acct.accType);
       System.Console.WriteLine(acct.accBalance);
        System.Console.WriteLine(acct.accEmail);
    
   }

   void checkBalance(){
       System.Console.WriteLine(accBalance);
   }
    }
    #endregion
    }
}
