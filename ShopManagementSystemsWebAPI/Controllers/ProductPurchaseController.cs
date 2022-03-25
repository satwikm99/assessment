using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using ShopManagementSystems.Models;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;


namespace ShopManagementSystems.Controllers
{
    public class ProductPurchaseController : ApiController
    {
        public HttpResponseMessage Get()
        {
            DataTable table = new DataTable();

            string query = @"
                                SELECT ItemID, ProductName, Department, Size, Length, Price
                                FROM dbo.ProductPurchase
                               ";

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["ShopAppDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }


        public string Post(ProductPurchase pp)
        {
            try
            {
                DataTable table = new DataTable();

                string query = @"
                                insert into dbo.ProductPurchase values
                                (
                                '" + pp.ItemID + @"'
                                ,'" + pp.ProductName + @"'
                                ,'" + pp.Department + @"'
                                ,'" + pp.Size + @"'
                                ,'" + pp.Length + @"'
                                ,'" + pp.Price + @"'
                                )
                               ";

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["ShopAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Added Successfully";
            }
            catch (Exception)
            {
                return "Failed to Add";
            }
        }

        public string Put(ProductPurchase pp)
        {
            try
            {
                DataTable table = new DataTable();

                string query = @"
                                update dbo.ProductPurchase set  
                                ProductName = '" + pp.ProductName + @"'
                                ,Department = '" + pp.Department + @"'
                                ,Size = '" + pp.Size + @"'
                                ,Length = '" + pp.Length + @"'
                                ,Price = '" + pp.Price + @"' 
                                where ItemID = '" + pp.ItemID + @"' 
                               ";

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["ShopAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Update Successfully";
            }
            catch (Exception)
            {
                return "Failed to Update";
            }
        }


        public string Delete(string id)
        {
            try
            {
                DataTable table = new DataTable();

                string query = @"
                                   delete from dbo.ProductPurchase where ItemID =  " + id;

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["ShopAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Deleted Successfully";
            }
            catch (Exception ex)
            {
                return "Failed to Delete";
            }
        }
    }
}
