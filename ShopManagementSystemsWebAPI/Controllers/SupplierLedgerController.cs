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
    public class SupplierLedgerController : ApiController
    {
        public HttpResponseMessage Get()
        {
            DataTable table = new DataTable();

            string query = @"
                                SELECT SupplierPaymentID, ChalanID, TotalAmount, PaidAmount, DueAmount, BalanceAmount
                                FROM dbo.SupplierLedger
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

        public string Post(SupplierLedger sl)
        {
            try
            {
                DataTable table = new DataTable();

                string query = @"
                                insert into dbo.SupplierLedger values
                                (
                                '" + sl.SupplierPaymentID + @"'
                                ,'" + sl.ChalanID + @"'
                                ,'" + sl.TotalAmount + @"'
                                ,'" + sl.PaidAmount + @"'
                                ,'" + sl.DueAmount + @"'
                                ,'" + sl.BalanceAmount + @"'
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


        public string Put(SupplierLedger slr)
        {
            try
            {
                DataTable table = new DataTable();

                string query = @"
                                update dbo.SupplierLedger set 
                                ChalanID = '" + slr.ChalanID + @"'
                                , TotalAmount = '" + slr.TotalAmount + @"'
                                , PaidAmount = '" + slr.PaidAmount + @"'
                                , DueAmount = '" + slr.DueAmount + @"'
                                , BalanceAmount = '" + slr.BalanceAmount + @"'  
                                where SupplierPaymentID = '" + slr.SupplierPaymentID + @"'
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
                                   delete from dbo.SupplierLedger where SupplierPaymentID =  " + id;

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
