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
        private string connectionString = "Data Source= den1.mssql7.gear.host; Initial Catalog=gettingreal ; User Id=gettingreal; Password=Kx8ig9R5w~h-;";

        public void InsertToEmployee(string employeeNavn)
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
            if (CheckEmployee(employeeNavn) == true)
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
            else
            {
                Console.WriteLine("Forkert navn");
            }
            
        }

        public bool CheckEmployee(string employeeNavn)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
               
            {
                conn.Open();
                try
                {
                    SqlCommand checkEmployee = new SqlCommand("CheckMedarbejder", conn);
                    checkEmployee.CommandType = CommandType.StoredProcedure;
                    checkEmployee.Parameters.Add(new SqlParameter("@Medarbejder", employeeNavn));

                    string Medarbejder = checkEmployee.ExecuteScalar()?.ToString();
                    string lower = Medarbejder.ToLower();
                    string inputToLower = employeeNavn.ToLower();


                    if (lower == inputToLower)
                    {
                        return true;
           

                    }
                    else
                    {
                        return false;
                   
                    }
                }
                catch (SqlException p)
                {
                    Console.WriteLine("Puha" + p.Message);
                    return false;
                }
            }
        }




        public void InsertToShift(DateTime dato, DateTime startTid, DateTime slutTid, double antalTimer)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                try
                {
                    SqlCommand insertToShift = new SqlCommand("InsertToVagt", conn);
                    insertToShift.CommandType = CommandType.StoredProcedure;
                    insertToShift.Parameters.Add(new SqlParameter("@date", dato));
                    insertToShift.Parameters.Add(new SqlParameter("@startTid", startTid));
                    insertToShift.Parameters.Add(new SqlParameter("@slutTid", slutTid));
                    insertToShift.Parameters.Add(new SqlParameter("@antalTimer", antalTimer));

                }
                catch (SqlException e)
                {
                    Console.WriteLine("Insert to shift fejl" + e.Message);
                }
            }


        }
    }
}