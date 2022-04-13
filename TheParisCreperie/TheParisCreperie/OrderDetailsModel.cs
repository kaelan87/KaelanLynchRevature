using System;
using System.Data.SqlClient;
using TheParisCreperie.Models;

namespace TheParisCreperie
{
    public class OrderDetailsModel
    {
        public float totalprice { get; set; }
        public int orderqty { get; set; }
       

        OrdersModel omodel = new OrdersModel();
        MenuModel mmodel = new MenuModel();


        SqlConnection connection = new SqlConnection("server= DESKTOP-L1CVGCU\\TRAININGINSTANCE; database= TheParisCreperie; integrated security=true");

        #region Read Data

        public OrderDetailsModel GetOrderDetails(int orderNo)
        {


            SqlCommand cmd_searchByorderNo = new SqlCommand("select * from ORDERDETAILS where orderNo =@orderNo", connection);
            cmd_searchByorderNo.Parameters.AddWithValue("@orderNo", omodel.orderNo);
            SqlDataReader read_OrderDetails = null;
            OrderDetailsModel OrderDetails = new OrderDetailsModel();
            try
            {
                connection.Open();
                read_OrderDetails = cmd_searchByorderNo.ExecuteReader();

                if (read_OrderDetails.Read())
                {


                    OrderDetails.totalprice = Convert.ToSingle(read_OrderDetails[0]);
                    OrderDetails.orderqty = Convert.ToInt32(read_OrderDetails[1]);
                   
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
                read_OrderDetails.Close();
                connection.Close();
            }
            return OrderDetails;
        }
        #endregion
        //OrdersModel orderNo, MenuModel itemNo
        public string AddOrderDetails(OrderDetailsModel newOrderDetails)
        {
            SqlCommand cmd_addOrderDetails = new SqlCommand("insert into ORDERDETAILS values(@totalprice,@orderqty, @orderNo, @itemNo)", connection);
            cmd_addOrderDetails.Parameters.AddWithValue("@totalprice", newOrderDetails.totalprice);
            cmd_addOrderDetails.Parameters.AddWithValue("@orderqty", newOrderDetails.orderqty);
            cmd_addOrderDetails.Parameters.AddWithValue("@orderNo", newOrderDetails.omodel.orderNo);
            cmd_addOrderDetails.Parameters.AddWithValue("@itemNo", newOrderDetails.mmodel.itemNo);


            try
            {
                connection.Open();
                cmd_addOrderDetails.ExecuteNonQuery();
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);

            }
            finally
            {
                connection.Close();
            }
            return "Order Details Added Successfully";
        }

        public string DeleteOrderDetails(int orderNo)
        {
            SqlCommand cmd_delete = new SqlCommand("delete from ORDERDETAILS where orderNo = @orderNo", connection);
            cmd_delete.Parameters.AddWithValue("@orderNo", orderNo);
            try
            {
                connection.Open();
                cmd_delete.ExecuteNonQuery();
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);
            }
            finally
            {
                connection.Close();
            }
            return "Order Details Deleted Successfully";
        }

        public string UpdateOrderDetails(OrderDetailsModel updates)
        {

            SqlCommand cmd_update = new SqlCommand("update ORDERDETAILS set totalprice = @totalprice, orderqty = @orderqty where itemNo = @itemNo AND orderNo = @orderNo", connection);
            cmd_update.Parameters.AddWithValue("@totalprice", updates.totalprice);
            cmd_update.Parameters.AddWithValue("@orderqty", updates.orderqty);
            cmd_update.Parameters.AddWithValue("@orderNo", updates.omodel.orderNo);
            cmd_update.Parameters.AddWithValue("@itemNo", updates.mmodel.itemNo);


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
            return "Order Details updated successfully";
        }

    }
}
