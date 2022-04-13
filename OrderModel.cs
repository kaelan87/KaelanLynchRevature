using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TheParisCreperie.Models;

namespace TheParisCreperie
{
    public class OrdersModel
    {
        #region Orders Properties
        public int orderNo { get; set; }
        public DateTime orderdatetime { get; set; }
        public string orderstatus { get; set; }

        public int customerid { get; set; }

        #endregion



        SqlConnection connection = new SqlConnection("server= DESKTOP-L1CVGCU\\TRAININGINSTANCE; database= TheParisCreperie; integrated security=true");

       

        #region Read Data

        public List<OrdersModel> GetOrderlist()
        {

            SqlCommand cmd_allorders = new SqlCommand("select * from ORDERS", connection);
            List<OrdersModel> orders = new List<OrdersModel>();
            SqlDataReader readAllOrders = null;
            try
            {
                connection.Open();
                readAllOrders = cmd_allorders.ExecuteReader();

                while (readAllOrders.Read())
                {
                    orders.Add(new OrdersModel()
                    {
                        orderNo = Convert.ToInt32(readAllOrders[2]),
                        orderdatetime = Convert.ToDateTime(readAllOrders[0]),
                        orderstatus = readAllOrders[1].ToString(),
                        customerid = Convert.ToInt32(readAllOrders[3])


                });

                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                readAllOrders.Close();
                connection.Close();
            }
            return orders;


        }


        public OrdersModel GetOrderDetails(int orderNo)
        {

            SqlCommand cmd_searchByorderNo = new SqlCommand("select * from ORDERS where orderNo =@orderNo", connection);
            cmd_searchByorderNo.Parameters.AddWithValue("@orderNo", orderNo);
            SqlDataReader read_order = null;
            OrdersModel orders = new OrdersModel();
            CustomerModel customer = new CustomerModel();
            try
            {
                connection.Open();
                read_order = cmd_searchByorderNo.ExecuteReader();

                if (read_order.Read())
                {
                    orders.orderNo = Convert.ToInt32(read_order[2]);
                    orders.orderdatetime = Convert.ToDateTime(read_order[0]);
                    orders.orderstatus = read_order[1].ToString();
                    customer.customerid = Convert.ToInt32(read_order[3]);

                }
                else
                {
                    throw new Exception("Order Not Found");
                }
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);
            }
            finally
            {
                read_order.Close();
                connection.Close();
            }
            return orders;
        }
        #endregion


       /* public OrdersModel GetCustomerOrders(int customerid)
        {

            SqlCommand cmd_searchBycustomerid = new SqlCommand("select * from ORDERS where customerid =@customerid", connection);
            cmd_searchBycustomerid.Parameters.AddWithValue("@customerid", customerid);
            SqlDataReader read_order = null;
            OrdersModel orders = new OrdersModel();
            CustomerModel customer = new CustomerModel();

            try
            {
                connection.Open();
                read_order = cmd_searchBycustomerid.ExecuteReader();

                if (read_order.Read())
                {
                    orders.orderNo = Convert.ToInt32(read_order[2]);
                    orders.orderdatetime = Convert.ToDateTime(read_order[0]);
                    orders.orderstatus = read_order[1].ToString();
                    customer.customerid = Convert.ToInt32(read_order[3]);

                }
                else
                {
                    throw new Exception("Order Not Found");
                }
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);
            }
            finally
            {
                read_order.Close();
                connection.Close();
            }
            return orders;
        }*/

        public List<OrdersModel> GetCustomerOrders(int customerid)
        {

            SqlCommand cmd_searchBycustomerid = new SqlCommand("select * from ORDERS where customerid =@customerid", connection);
            List<OrdersModel> customerorders = new List<OrdersModel>();
            cmd_searchBycustomerid.Parameters.AddWithValue("@customerid", customerid);
            SqlDataReader readAllOrders = null;
           
            try
            {
                connection.Open();
                readAllOrders = cmd_searchBycustomerid.ExecuteReader();

                while (readAllOrders.Read())
                {
                    customerorders.Add(new OrdersModel()
                    {
                        orderNo = Convert.ToInt32(readAllOrders[2]),
                        orderdatetime = Convert.ToDateTime(readAllOrders[0]),
                        orderstatus = readAllOrders[1].ToString(),
                        customerid = Convert.ToInt32(readAllOrders[3])


                    });

                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                readAllOrders.Close();
                connection.Close();
            }
            return customerorders;


        }
        public string Addorder(OrdersModel newOrder)
        {
            SqlCommand cmd_addOrder = new SqlCommand("insert into ORDERS values(@orderdatetime,@orderstatus, @customerid)", connection);
            cmd_addOrder.Parameters.AddWithValue("@orderdatetime", newOrder.orderdatetime);
            cmd_addOrder.Parameters.AddWithValue("@orderstatus", newOrder.orderstatus);
            cmd_addOrder.Parameters.AddWithValue("@customerid", newOrder.customerid);

            try
            {
                connection.Open();
                cmd_addOrder.ExecuteNonQuery();
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);

            }
            finally
            {
                connection.Close();
            }
            return "Order Added Successfully";
        }

        public string CancelOrder(int orderNo)
        {
            SqlCommand cmd_cancel = new SqlCommand("delete from ORDERS where orderNo = @orderNo", connection);
            cmd_cancel.Parameters.AddWithValue("@orderNo", orderNo);
            try
            {
                connection.Open();
                cmd_cancel.ExecuteNonQuery();
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);
            }
            finally
            {
                connection.Close();
            }
            return "Order Cancelled Successfully";
        }

        public string Updateorder(OrdersModel updates)
        {

            SqlCommand cmd_update = new SqlCommand("update ORDERS set orderdatetime = @orderdatetime, orderstatus = @orderstatus where orderNo = @orderNo", connection);
            cmd_update.Parameters.AddWithValue("@orderdatetime", updates.orderdatetime);
            cmd_update.Parameters.AddWithValue("@orderstatus", updates.orderstatus);
            cmd_update.Parameters.AddWithValue("@orderNo", updates.orderNo);



            try
            {
                connection.Open();
                cmd_update.ExecuteNonQuery();
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);
            }
            finally
            {
                connection.Close();
            }
            return "Order updated successfully";
        }

    }

}
