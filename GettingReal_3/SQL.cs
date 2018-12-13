﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace GettingReal_3
{
    public class SQL

    {
        private static string connectionString = "Data Source= den1.mssql7.gear.host; Initial Catalog=gettingreal ; User Id=gettingreal; Password=Kx8ig9R5w~h-;";

        public void insertToEmployee(string employeeNavn)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                try
                {
                    SqlCommand insertToEmployee = new SqlCommand("InsertToMedarbejder", conn);
                    insertToEmployee.CommandType = CommandType.StoredProcedure;
                    insertToEmployee.Parameters.Add(new SqlParameter("@Navn", employeeNavn));
                    
                    insertToEmployee.ExecuteNonQuery();
                }

                catch (SqlException e)
                {
                    Console.WriteLine("Insert to employee fejl" + e.Message);
                }
            }
        }
        public void DeleteEmployee(string employeeNavn)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                try
                {
                    SqlCommand deleteEmployee = new SqlCommand("DeleteEmployee", conn);
                    deleteEmployee.CommandType = CommandType.StoredProcedure;
                    deleteEmployee.Parameters.Add(new SqlParameter("@Medarbejder", employeeNavn));

                    deleteEmployee.ExecuteNonQuery();
                }
                catch (SqlException n)
                {
                    Console.WriteLine("Feeeeeeeeeejl" + n.Message);
                
                }
            }
        }
        

        //public void DeleteEmployee(string employeeNavn)
        //{
        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        conn.Open();
        //        if (employeeNavn == )
        //        {
        //            SqlCommand DeleteEmployee = new SqlCommand("delete InsertToMedarbejder where ID=@id", conn);
        //            DeleteEmployee.Parameters.AddWithValue("@id", employeeNavn);
        //            DeleteEmployee.ExecuteNonQuery();

        //        }
        //        else (employeeNavn != )
        //            Console.WriteLine("Indtastet navn er forkert");
        //        }
             

        //}
        
        
          
        }

        public void insertToShift(DateTime dato, DateTime startTid, DateTime slutTid, double antalTimer)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                try
                {
                    SqlCommand InsertToShift = new SqlCommand("InsertToVagt", conn);
                    InsertToShift.CommandType = CommandType.StoredProcedure;
                    InsertToShift.Parameters.Add(new SqlParameter("@date", dato));
                    InsertToShift.Parameters.Add(new SqlParameter("@startTid", startTid));
                    InsertToShift.Parameters.Add(new SqlParameter("@slutTid", slutTid));
                    InsertToShift.Parameters.Add(new SqlParameter("@antalTimer", antalTimer));

                }
                catch(SqlException e)
                {
                    Console.WriteLine("Insert to shift fejl" + e.Message);
                }
            }
        }
    }
}
