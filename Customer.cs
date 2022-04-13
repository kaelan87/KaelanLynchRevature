using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace TheParisCreperie.Models
{
    public class CustomerModel
    {
        public int customerid { get; set; }
        [Required]
        [StringLength(100)]
        public string customername { get; set; }
        public int customerphone { get; set; }
        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string customeremail { get; set; }
        public string address { get; set; }


        SqlConnection con = new SqlConnection("server= DESKTOP-L1CVGCU\\TRAININGINSTANCE; database= TheParisCreperie; integrated security=true");

        #region Read Data
        public List<CustomerModel> GetCustomerList()
        {
            List<CustomerModel> customerlist = new List<CustomerModel>();
            SqlCommand cmd_allcustomers = new SqlCommand("select * from CUSTOMERS", con);

            SqlDataReader readAllcustomers = null;
            try
            {
                con.Open();
                readAllcustomers = cmd_allcustomers.ExecuteReader();

                while (readAllcustomers.Read())
                {
                    customerlist.Add(new CustomerModel()
                    {
                        customerid = Convert.ToInt32(readAllcustomers[3]),
                        customername = readAllcustomers[0].ToString(),
                        customerphone = Convert.ToInt32(readAllcustomers[1]),
                        customeremail = readAllcustomers[2].ToString(),
                        address = readAllcustomers[4].ToString()
                    });
                }

            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                readAllcustomers.Close();
                con.Close();
            }
            return customerlist;


        }


        public CustomerModel GetCustomerDetails(int customerid)
        {

            SqlCommand cmd_searchByid = new SqlCommand("select * from CUSTOMERS where customerid = @customerid", con);
            cmd_searchByid.Parameters.AddWithValue("@customerid", customerid);
            SqlDataReader read_customer = null;
            CustomerModel customer = new CustomerModel();
            try
            {
                con.Open();
                read_customer = cmd_searchByid.ExecuteReader();

                if (read_customer.Read())
                {
                    customer.customerid = Convert.ToInt32(read_customer[3]);
                    customer.customername = read_customer[0].ToString();
                    customer.customerphone = Convert.ToInt32(read_customer[1]);
                    customer.customeremail = read_customer[2].ToString();
                    customer.address = read_customer[4].ToString();

                }
                else
                {
                    throw new Exception("Customer Not Found");
                }
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);
            }
            finally
            {
                read_customer.Close();
                con.Close();
            }
            return customer;
        }
        #endregion

        public string Addcustomer(CustomerModel newCustomer)
        {
            SqlCommand cmd_addCustomer = new SqlCommand("insert into CUSTOMERS values(@customername,@customerphone,@customeremail, @address)", con);
            cmd_addCustomer.Parameters.AddWithValue("@customername", newCustomer.customername);
            cmd_addCustomer.Parameters.AddWithValue("@customerphone", newCustomer.customerphone);
            cmd_addCustomer.Parameters.AddWithValue("@customeremail", newCustomer.customeremail);
            cmd_addCustomer.Parameters.AddWithValue("@address", newCustomer.address);


            try
            {
                con.Open();
                cmd_addCustomer.ExecuteNonQuery();
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);

            }
            finally
            {
                con.Close();
            }
            return "Customer Added Successfully";
        }

        public string Deletecustomer(int customerid)
        {
            SqlCommand cmd_delete = new SqlCommand("delete from CUSTOMERS where customerid = @customerid", con);
            cmd_delete.Parameters.AddWithValue("@customerid", customerid);
            try
            {
                con.Open();
                cmd_delete.ExecuteNonQuery();
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);
            }
            finally
            {
                con.Close();
            }
            return "Customer Deleted Successfully";
        }

        public string Updatecustomer(CustomerModel updates)
        {

            SqlCommand cmd_update = new SqlCommand("update CUSTOMERS set customername = @customername, customerphone = @customerphone, customeremail = @customeremail, address = @address where customerid = @customerid", con);
            cmd_update.Parameters.AddWithValue("@customername", updates.customername);
            cmd_update.Parameters.AddWithValue("@customerphone", updates.customerphone);
            cmd_update.Parameters.AddWithValue("@customeremail", updates.customeremail);
            cmd_update.Parameters.AddWithValue("@address", updates.address);
            //cmd_update.Parameters.AddWithValue("@customerid", updates.customerid);



            try
            {
                con.Open();
                cmd_update.ExecuteNonQuery();
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);
            }
            finally
            {
                con.Close();
            }
            return "Customer updated successfully";
        }

    }
}

