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
    public class PurchaseController : ApiController
    {
        public HttpResponseMessage Get()
        {
            DataTable table = new DataTable();

            string query = @"
                                SELECT PurchaseID, Item, SupplierDetail, BillAmount
                                FROM dbo.Purchase
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

        public string Post(Purchase ph)
        {
            try
            {
                DataTable table = new DataTable();

                string query = @"
                                insert into dbo.Purchase values
                                (
                                '" + ph.PurchaseID + @"'
                                ,'" + ph.Item + @"'
                                ,'" + ph.SupplierDetail + @"'
                                ,'" + ph.BillAmount + @"'
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


        public string Put(Purchase phs)
        {
            try
            {
                DataTable table = new DataTable();

                string query = @"
                                update dbo.Purchase set 
                                Item = '" + phs.Item + @"'
                                , SupplierDetail = '" + phs.SupplierDetail + @"'
                                , BillAmount = '" + phs.BillAmount + @"'  
                                where PurchaseID = '" + phs.PurchaseID + @"'
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
                                   delete from dbo.Purchase where PurchaseID =  " + id;

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
