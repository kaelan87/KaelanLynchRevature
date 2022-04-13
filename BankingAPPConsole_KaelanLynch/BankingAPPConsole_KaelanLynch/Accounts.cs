using System;
using System.Data.SqlClient;

namespace BankingAPPConsole_KaelanLynch
{

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

SqlConnection connection = new SqlConnection(
            @"Data Source=DESKTOP-L1CVGCU\TRAININGINSTANCE;Initial Catalog=bankingDB;integrated security=true");
#region Account Methods
 public string createNewUser(Accounts newAccount){
     SqlCommand cmd_createUser = new SqlCommand(
         "insert into ACCOUNTS values (@accNo, @accName, @accType, @accBalance, @accIsActive, @accEmail)", connection);
                cmd_createUser.Parameters.AddWithValue("@accNo",newAccount.accNo);
                cmd_createUser.Parameters.AddWithValue("@accName",newAccount.accName);
                cmd_createUser.Parameters.AddWithValue("@accType",newAccount.accType);
                cmd_createUser.Parameters.AddWithValue("@accBalance",newAccount.accBalance);
                cmd_createUser.Parameters.AddWithValue("@accIsActive",newAccount.accIsActive);
                cmd_createUser.Parameters.AddWithValue("@accEmail",newAccount.accEmail);

                try
                {
                    connection.Open();
                    cmd_createUser.ExecuteNonQuery();                    
                }
                catch(SqlException ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
                return "Account created successfully";

            }
   public string updateAccountDetails(Accounts newAccount){
       
       SqlCommand cmd_updateUser = new SqlCommand("update ACCOUNTS set accName =@newaccName, accType =@newaccType, accEmail =@newaccEmail where accNo =@newaccNo", connection);
                cmd_updateUser.Parameters.AddWithValue("@newaccNo",newAccount.accNo);
                cmd_updateUser.Parameters.AddWithValue("@newaccName",newAccount.accName);
                cmd_updateUser.Parameters.AddWithValue("@newaccType",newAccount.accType);
                cmd_updateUser.Parameters.AddWithValue("@newaccEmail",newAccount.accEmail);

                try
                {
                    connection.Open();
                    cmd_updateUser.ExecuteNonQuery();                    
                }
                catch(SqlException ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
                return "Account updated successfully";

            }
             public void checkBalance(){
            
            SqlCommand chkblnce = new SqlCommand("select accBalance from ACCOUNTS where accNo =@accNo",connection);
            chkblnce.Parameters.AddWithValue("@accNo",accNo);
            SqlDataReader _read;
            Accounts acco = new Accounts();
            try
            {
                connection.Open();
                _read = chkblnce.ExecuteReader();

                if(_read.Read())
                {
                    acco.accBalance = Convert.ToInt32(_read[0]);
                System.Console.WriteLine("Your balance is "+ acco.accBalance);
                
            }}
            catch (System.Exception es)
            {
                
                System.Console.WriteLine(es.Message);
            }
            finally
            {
                connection.Close();
            } 

            
        }
           
   public void withdraw()
   {
       System.Console.WriteLine("Enter an amount to withdraw");
       int wdraw = Convert.ToInt32(Console.ReadLine());
       System.Console.WriteLine("Please enter your account number");
        int accNo = Convert.ToInt32(Console.ReadLine());
        SqlCommand cmd_withdraw = new SqlCommand("update ACCOUNTS set accBalance=accBalance - @amt WHERE accNo = @accNo", connection);
        cmd_withdraw.Parameters.AddWithValue("@amt", wdraw);
        cmd_withdraw.Parameters.AddWithValue("@accNo", accNo);
 try
            {
                connection.Open();
                cmd_withdraw.ExecuteNonQuery();
                System.Console.WriteLine("The withdrawal was successful.");
            }
            catch (System.Exception es)
            {
                
                System.Console.WriteLine(es.Message);
            }
            finally
            {
                connection.Close();
            }
   }

  public void deposit()
   {
        System.Console.WriteLine("Enter an amount to deposit");
        int depo = Convert.ToInt32(Console.ReadLine());
       System.Console.WriteLine("Please enter your account number");
        int accNo = Convert.ToInt32(Console.ReadLine());
        SqlCommand cmd_deposit = new SqlCommand("update ACCOUNTS set accBalance=accBalance + @amt WHERE accNo = @accNo", connection);
        cmd_deposit.Parameters.AddWithValue("@amt", depo);
        cmd_deposit.Parameters.AddWithValue("@accNo", accNo);
 try
            {
                connection.Open();
                cmd_deposit.ExecuteNonQuery();
                System.Console.WriteLine("The deposit was successful.");            
                }
            catch (System.Exception es)
            {
                
                System.Console.WriteLine(es.Message);
            }
            finally
            {
                connection.Close();
            }
                
        }
    public void DeleteAccount()
        {
            SqlCommand cmd_deleteAccount = new SqlCommand("delete from ACCOUNTS where accNo = @accNo", connection);
            cmd_deleteAccount.Parameters.AddWithValue("@accNo",accNo);
            try
            {
                connection.Open();
                System.Console.WriteLine("Enter your account number");
                accNo = Convert.ToInt32(Console.ReadLine());
                cmd_deleteAccount.ExecuteNonQuery();
            }
            catch (System.Exception es)
            {
                
                System.Console.WriteLine(es.Message);
            }
            finally
            {
                connection.Close();
            }
            System.Console.WriteLine("Account deleted");
        }

   }
    }
    #endregion
    