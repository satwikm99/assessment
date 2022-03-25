﻿using System;
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
    public class CustomerController : ApiController
    {
        public HttpResponseMessage Get()
        {
            DataTable table = new DataTable();

            string query = @"
                                SELECT CustomerID, CustomerCompanyName, ContactPerson, Address 
                                FROM dbo.Customer
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


        public string Post(Customer cs)
        {
            try
            {
                DataTable table = new DataTable();

                string query = @"
                                insert into dbo.Customer values
                                (
                                '"+ cs.CustomerID + @"'
                                ,'" + cs.CustomerCompanyName + @"'
                                ,'" + cs.ContactPerson + @"'
                                ,'" + cs.Address + @"'
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
            catch(Exception)
            {
                return "Failed to Add";
            }
        }

        public string Put(Customer cs)
        {
            try
            {
                DataTable table = new DataTable();

                string query = @"
                                update dbo.Customer set 
                                CustomerCompanyName = '" + cs.CustomerCompanyName + @"' 
                                ,ContactPerson = '" + cs.ContactPerson + @"' 
                                ,Address = '" + cs.Address + @"'  
                                where CustomerID = '" + cs.CustomerID + @"' 
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
                                   delete from dbo.Customer where CustomerID =  " + id;

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