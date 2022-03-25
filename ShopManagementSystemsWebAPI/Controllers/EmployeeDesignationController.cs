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
    public class EmployeeDesignationController : ApiController
    {
        public HttpResponseMessage Get()
        {
            DataTable table = new DataTable();

            string query = @"
                                SELECT DesignationName, RoleName, DepartmentName
                                FROM dbo.EmployeeDesignation
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

        public string Post(EmployeeDesignation epd)
        {
            try
            {
                DataTable table = new DataTable();

                string query = @"
                                insert into dbo.EmployeeDesignation values
                                (
                                '" + epd.DesignationName + @"'
                                ,'" + epd.RoleName + @"'
                                ,'" + epd.DepartmentName + @"'
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

        public string Put(EmployeeDesignation epd1)
        {
            try
            {
                DataTable table = new DataTable();

                string query = @"
                                update dbo.EmployeeDesignation set
                                RoleName = '" + epd1.RoleName + @"'
                                ,DepartmentName = '" + epd1.DepartmentName + @"'
                                where DesignationName = '" + epd1.DesignationName + @"'
                                ";

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["ShopAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da4 = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da4.Fill(table);
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
                                   delete from dbo.EmployeeDesignation where DesignationName =  " + id;

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
