using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;


    
    class SqlAdapetr
    {
            static void Main(string[] args) {
        string cs = "Data Source=GOPALAKRISHNA\\SQLEXPRESS;Initial Catalog = TrainingDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;";
        string sql = "SELECT EmployeeId, FullName, Department, Salary FROM dbo.Employees ORDER BY EmployeeId;SELECT EmployeeId, FullName FROM dbo.Employees ";
            DataSet ds = new DataSet();
            using (var con = new SqlConnection(cs))
            using (var cmd = new SqlCommand(sql, con))
            {
                con.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
            }
            ds.WriteXml("TestData");
        }
    }

