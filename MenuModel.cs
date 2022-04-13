using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace TheParisCreperie.Models
{
    public class MenuModel
    {
        #region Menu Properties
        public int itemNo { get; set; }
        public string item { get; set; }

        [Range(0, 999.99)]
        public float price { get; set; }
        
        [Required]
        [StringLength(1000)]
        public string description { get; set; }



        #endregion
        SqlConnection connection = new SqlConnection("server= DESKTOP-L1CVGCU\\TRAININGINSTANCE; database= TheParisCreperie; integrated security=true");

       /* public MenuModel GetMenuItem(int itemNo)
        {

                SqlCommand cmd_searchByitemNo = new SqlCommand("select * from MENU where itemNo = @itemNo", connection);
                cmd_searchByitemNo.Parameters.AddWithValue("@itemNo", itemNo);
                SqlDataReader read_item = null;
                MenuModel menu = new MenuModel();
                try
                {
                    connection.Open();
                    read_item = cmd_searchByitemNo.ExecuteReader();

                    if (read_item.Read())
                    {
                        menu.itemNo = Convert.ToInt32(read_item[0]);
                        menu.item = read_item[1].ToString();
                        menu.price = Convert.ToSingle (read_item[2]);
                        menu.description = read_item[3].ToString();
                      

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
                    read_item.Close();
                    connection.Close();
                }
                return menu;

               
           
        }*/
        public List<MenuModel> GetMenulist()
        {
            List<MenuModel> menu = new List<MenuModel>();
            SqlCommand cmd_allitems = new SqlCommand("select * from MENU", connection);
            
            SqlDataReader readAllItems = null;
            try
            {
                connection.Open();
                readAllItems = cmd_allitems.ExecuteReader();

                while (readAllItems.Read())
                {
                    menu.Add(new MenuModel()
                    {
                        itemNo = Convert.ToInt32(readAllItems[0]),
                        item = readAllItems[1].ToString(),
                        price = Convert.ToSingle(readAllItems[2]),
                        description = readAllItems[3].ToString(),
                    });
                }

            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                readAllItems.Close();
                connection.Close();
            }
            return menu;
        }
       
        public string Additem(MenuModel newitem)
        {
            SqlCommand cmd_additem = new SqlCommand("insert into MENU values(@itemNo, @item, @price, @description)", connection);
            cmd_additem.Parameters.AddWithValue("@itemNo", newitem.itemNo);
            cmd_additem.Parameters.AddWithValue("@item", newitem.item);
            cmd_additem.Parameters.AddWithValue("@price", newitem.price);
            cmd_additem.Parameters.AddWithValue("@description", newitem.description);

            try
            {
                connection.Open();
                cmd_additem.ExecuteNonQuery();
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);

            }
            finally
            {
                connection.Close();
            }
            return "Item Added Successfully";
        }

        public string Deleteitem(int itemNo)
        {
            SqlCommand cmd_delete = new SqlCommand("delete from MENU where itemNo = @itemNo", connection);
            cmd_delete.Parameters.AddWithValue("@itemNo", itemNo);
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
            return "Item Deleted Successfully";
        }

        public string Updateitem(MenuModel updates)
        {

            SqlCommand cmd_update = new SqlCommand("update MENU set item = @item, price = @price, description = @description where itemNo = @itemNo", connection);
            cmd_update.Parameters.AddWithValue("@item", updates.item);
            cmd_update.Parameters.AddWithValue("@price", updates.price);
            cmd_update.Parameters.AddWithValue("@description", updates.description);
            cmd_update.Parameters.AddWithValue("@itemNo", updates.itemNo);



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
            return "Menu Updated successfully";
        }

    }

}

