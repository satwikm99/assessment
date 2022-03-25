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
    public class SalesController : ApiController
    {
        public HttpResponseMessage Get()
        {
            DataTable table = new DataTable();

            string query = @"
                                SELECT SalesID, Item, CustomerDetail, BillAmount
                                FROM dbo.Sales
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

        public string Post(Sales se)
        {
            try
            {
                DataTable table = new DataTable();

                string query = @"
                                insert into dbo.Sales values
                                (
                                '" + se.SalesID + @"'
                                ,'" + se.Item + @"'
                                ,'" + se.CustomerDetail + @"'
                                ,'" + se.BillAmount + @"'
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
            catch (Exception ex)
            {
                return "Failed to Add";
            }
        }


        public string Put(Sales ses)
        {
            try
            {
                DataTable table = new DataTable();

                string query = @"
                                update dbo.Sales set 
                                Item = '" + ses.Item + @"'
                                , CustomerDetail = '" + ses.CustomerDetail + @"'
                                , BillAmount = '" + ses.BillAmount + @"'  
                                where SalesID = '" + ses.SalesID + @"'
                               ";

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["ShopAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Updated Successfully";
            }
            catch (Exception ex)
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
                                   delete from dbo.Sales where SalesID =  " + id;

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
