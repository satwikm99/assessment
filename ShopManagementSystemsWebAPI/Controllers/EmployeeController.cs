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
    public class EmployeeController : ApiController
    {
        public HttpResponseMessage Get()
        {
            DataTable table = new DataTable();

            string query = @"
                                SELECT EmployeeID, EmployeeName, PhoneNo, MailID, Address
                                FROM dbo.Employee
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

        public string Post(Employee ep)
        {
            try
            {
                DataTable table = new DataTable();

                string query = @"
                                insert into dbo.Employee values
                                (
                                '" + ep.EmployeeID + @"'
                                ,'" + ep.EmployeeName + @"'
                                ,'" + ep.PhoneNo + @"'
                                ,'" + ep.MailID + @"'
                                ,'" + ep.Address + @"'
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


        public string Put(Employee epd)
        {
            try
            {
                DataTable table = new DataTable();

                string query = @"
                                update dbo.Employee set 
                                EmployeeName = '" + epd.EmployeeName + @"'
                                , PhoneNo = '" + epd.PhoneNo + @"'
                                , MailID = '" + epd.MailID + @"'
                                , Address = '" + epd.Address + @"'  
                                where EmployeeID = '" + epd.EmployeeID + @"'
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

        public string Delete(string id)
        {
            try
            {
                DataTable table = new DataTable();

                string query = @"
                                   delete from dbo.Employee where EmployeeID =  " + id;

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
