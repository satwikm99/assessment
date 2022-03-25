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
    public class CustomerLedgerController : ApiController
    {
        public HttpResponseMessage Get()
        {
            DataTable table = new DataTable();

            string query2 = @"
                                SELECT InvoicePaymentID, InvoiceID, GrandTotalAmount, PaidAmount, DueAmount, BalanceAmount
                                FROM dbo.CustomerLedger
                               ";

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["ShopAppDB"].ConnectionString))
            using (var cmd = new SqlCommand(query2, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        public string Post(CustomerLedger csl)
        {
            try
            {
                DataTable table = new DataTable();

                string query = @"
                                insert into dbo.CustomerLedger values
                                (
                                '" + csl.InvoicePaymentID + @"'
                                ,'" + csl.InvoiceID + @"'
                                ,'" + csl.GrandTotalAmount + @"'
                                ,'" + csl.PaidAmount + @"'
                                ,'" + csl.DueAmount + @"'
                                ,'" + csl.BalanceAmount + @"'
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

        public string Put(CustomerLedger csl)
        {
            try
            {
                DataTable table = new DataTable();

                string query = @"
                                update dbo.CustomerLedger set 
                                InvoiceID = '" + csl.InvoiceID + @"'
                                ,GrandTotalAmount = '" + csl.GrandTotalAmount + @"'
                                ,PaidAmount = '" + csl.PaidAmount + @"'
                                ,DueAmount = '" + csl.DueAmount + @"' 
                                ,BalanceAmount = '" + csl.BalanceAmount + @"' 
                                where InvoicePaymentID = '" + csl.InvoicePaymentID + @"' 
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
                                   delete from dbo.CustomerLedger where InvoicePaymentID =  " + id;

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
