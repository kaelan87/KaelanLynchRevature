using System;

namespace BankingAPPConsole_KaelanLynch
{
    class Program
    {
        static void Main(string[] args)
        {
             Accounts acc = new Accounts();
         acc.accNo = 000456789455;
         acc.accName = "Kaelan Lynch";
         acc.accType = "Checking";
         acc.accBalance = 1000;
         acc.accIsActive = true;
         acc.accEmail = "kdog93@gmail.com";
         
        Accounts newacct = new Accounts();

       // int newacctNo;
        string newacctName;
        string newacctType;
       // int newacctBalance;
        string newacctEmail;

#region Menu

        Console.WriteLine("1. Create New Account");
        Console.WriteLine("2. Check Balance");
        Console.WriteLine("3. Withdraw");
        Console.WriteLine("4. Deposit");
        Console.WriteLine("5. Get Details");
        Console.WriteLine("6. Exit");
        Console.WriteLine("PLEASE SELECT AN OPTION");
        int input = Convert.ToInt32(Console.ReadLine());

    switch(input){
        case 1: 
            System.Console.WriteLine("Please enter your full legal name");
            newacctName = Console.ReadLine();
            System.Console.WriteLine("Select the account type");
            newacctType = Console.ReadLine();
            System.Console.WriteLine("Enter your email");
            newacctEmail = Console.ReadLine();
            System.Console.WriteLine(newacctName);
            System.Console.WriteLine(newacctType);
            System.Console.WriteLine(newacctEmail);

        break;
        case 2: acc.checkBalance();
        break;
        case 3: acc.withdraw(acc.accBalance);
        break;
        case 4: acc.deposit(acc.accBalance);
        break;
        case 5: acc.getAccountDetails();
        break;
        case 6: 
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
        public int accBalance { get; set; }
        public bool accIsActive { get; set; }
        public string accEmail { get; set; }
#endregion
#region Account Methods
   public int withdraw(int accBalance)
   {
       System.Console.WriteLine("Enter an amount to withdraw");
       accBalance = accBalance - (Convert.ToInt32(Console.ReadLine()));

       return accBalance;
   }
  public int deposit(int accBalance)
   {
        System.Console.WriteLine("Enter an amount to deposit");
       accBalance = accBalance + (Convert.ToInt32(Console.ReadLine()));
       return accBalance;

   }
   public void getAccountDetails(){
       Console.WriteLine(accNo);
       Console.WriteLine(accName);
       Console.WriteLine(accType);
       System.Console.WriteLine(accBalance);
        System.Console.WriteLine(accEmail);
    
   }

   public int checkBalance(){
       return accBalance;
   }
    }
    #endregion
    }
}
