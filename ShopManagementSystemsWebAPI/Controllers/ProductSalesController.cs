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
    public class ProductSalesController : ApiController
    {
        public HttpResponseMessage Get()
        {
            DataTable table = new DataTable();

            string query = @"
                                SELECT ProductID, ProductName, HSNNumber, Unit, SalesPrice, GST
                                FROM dbo.ProductSales
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


        public string Post(ProductSales ps)
        {
            try
            {
                DataTable table = new DataTable();

                string query = @"
                                insert into dbo.ProductSales values
                                (
                                '" + ps.ProductID + @"'
                                ,'" + ps.ProductName + @"'
                                ,'" + ps.HSNNumber + @"'
                                ,'" + ps.Unit + @"'
                                ,'" + ps.SalesPrice + @"'
                                ,'" + ps.GST + @"'
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

        public string Put(ProductSales ps)
        {
            try
            {
                DataTable table = new DataTable();

                string query = @"
                                update dbo.ProductSales set  
                                ProductName = '" + ps.ProductName + @"'
                                ,HSNNumber = '" + ps.HSNNumber + @"'
                                ,Unit = '" + ps.Unit + @"'
                                ,SalesPrice = '" + ps.SalesPrice + @"'
                                ,GST = '" + ps.GST + @"'  
                                where ProductID = '" + ps.ProductID + @"' 
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

        public string Delete(int id)
        {
            try
            {
                DataTable table = new DataTable();

                string query = @"
                                   delete from dbo.ProductSales where ProductID =  " + id;

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
