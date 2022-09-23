using MCCWebMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Data.SqlClient;

namespace MCCWebMVC.Controllers
{
    public class GajiController : Controller
    {
        SqlConnection conn;
        string connectionString = "Data Source=DESKTOP-V48IK6S; Initial Catalog=Penggajian; " +
            "User ID=mccdts;Password=mccdts;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;" +
            "ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        //READ
        public IActionResult Index()
        {
            string query = "SELECT * FROM Gaji";

            conn = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            List<Gaji> Gajis = new List<Gaji>();

            try
            {
                conn.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            Gaji gaji = new Gaji();

                            gaji.Id = Convert.ToInt32(sqlDataReader[0]);
                            gaji.Pokok = Convert.ToInt32(sqlDataReader[1]);
                            gaji.Tunjangan = Convert.ToInt32(sqlDataReader[2]);
                            gaji.Akomodasi = Convert.ToInt32(sqlDataReader[3]);
                            gaji.Bank = sqlDataReader[4].ToString();
                            gaji.Rekening = sqlDataReader[5].ToString();

                            Gajis.Add(gaji);
                        }
                    }
                    sqlDataReader.Close();
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View(Gajis);
        }
        //CREATE
        //get

        public IActionResult Create()
        {
            return View();
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Gaji gaji)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                SqlParameter sqlParameter1 = new SqlParameter();
                sqlParameter1.ParameterName = "@id";
                sqlParameter1.Value = gaji.Id;

                SqlParameter sqlParameter2 = new SqlParameter();
                sqlParameter2.ParameterName = "@pokok";
                sqlParameter2.Value = gaji.Pokok;

                SqlParameter sqlParameter3 = new SqlParameter();
                sqlParameter3.ParameterName = "@tunjangan";
                sqlParameter3.Value = gaji.Tunjangan;

                SqlParameter sqlParameter4 = new SqlParameter();
                sqlParameter4.ParameterName = "@akomodasi";
                sqlParameter4.Value = gaji.Akomodasi;

                SqlParameter sqlParameter5 = new SqlParameter();
                sqlParameter5.ParameterName = "@bank";
                sqlParameter5.Value = gaji.Bank;

                SqlParameter sqlParameter6 = new SqlParameter();
                sqlParameter6.ParameterName = "@rekening";
                sqlParameter6.Value = gaji.Rekening;


                sqlCommand.Parameters.Add(sqlParameter1);
                sqlCommand.Parameters.Add(sqlParameter2);
                sqlCommand.Parameters.Add(sqlParameter3);
                sqlCommand.Parameters.Add(sqlParameter4);
                sqlCommand.Parameters.Add(sqlParameter5);
                sqlCommand.Parameters.Add(sqlParameter6);

                try
                {
                    sqlCommand.CommandText = "INSERT INTO Gaji " +
                        "VALUES (@id, @pokok, @tunjangan, @akomodasi, @bank, @rekening)";

                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return View();
        }

        //GET
        public IActionResult Edit(int id)
        {
            string query = "SELECT * FROM Gaji WHERE Id_Gaji = @id";

            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = "@id";
            sqlParameter.Value = id;

            conn = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            sqlCommand.Parameters.Add(sqlParameter);
            Gaji gaji = new Gaji();
            try
            {
                conn.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            gaji.Id = Convert.ToInt32(sqlDataReader[0]);
                            gaji.Pokok = Convert.ToInt32(sqlDataReader[1]);
                            gaji.Tunjangan = Convert.ToInt32(sqlDataReader[2]);
                            gaji.Akomodasi = Convert.ToInt32(sqlDataReader[3]);
                            gaji.Bank = sqlDataReader[4].ToString();
                            gaji.Rekening = sqlDataReader[5].ToString();

                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Rows");
                    }
                    sqlDataReader.Close();
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View(gaji);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Gaji gaji)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                SqlParameter sqlParameter1 = new SqlParameter();
                sqlParameter1.ParameterName = "@id";
                sqlParameter1.Value = gaji.Id;

                SqlParameter sqlParameter2 = new SqlParameter();
                sqlParameter2.ParameterName = "@pokok";
                sqlParameter2.Value = gaji.Pokok;

                SqlParameter sqlParameter3 = new SqlParameter();
                sqlParameter3.ParameterName = "@tunjangan";
                sqlParameter3.Value = gaji.Tunjangan;

                SqlParameter sqlParameter4 = new SqlParameter();
                sqlParameter4.ParameterName = "@akomodasi";
                sqlParameter4.Value = gaji.Akomodasi;

                SqlParameter sqlParameter5 = new SqlParameter();
                sqlParameter5.ParameterName = "@bank";
                sqlParameter5.Value = gaji.Bank;

                SqlParameter sqlParameter6 = new SqlParameter();
                sqlParameter6.ParameterName = "@rekening";
                sqlParameter6.Value = gaji.Rekening;


                sqlCommand.Parameters.Add(sqlParameter1);
                sqlCommand.Parameters.Add(sqlParameter2);
                sqlCommand.Parameters.Add(sqlParameter3);
                sqlCommand.Parameters.Add(sqlParameter4);
                sqlCommand.Parameters.Add(sqlParameter5);
                sqlCommand.Parameters.Add(sqlParameter6);

                try
                {
                    sqlCommand.CommandText =
                    "UPDATE Gaji " +
                        "SET Gaji_Pokok = @pokok, Tunjangan_Jabatan = @tunjangan, Uang_Akomodasi = @akomodasi, " +
                        "Nama_Bank = @bank, No_Rekening = @rekening WHERE Id_Gaji = @id ";
                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                    Console.WriteLine($"Produk berhasil diedit!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return View();
            }
        }

        //DELETE
        //get
        public IActionResult Delete(int id) {
            string query = "SELECT * FROM Gaji WHERE Id_Gaji = @id";

            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = "@id";
            sqlParameter.Value = id;

            conn = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            sqlCommand.Parameters.Add(sqlParameter);
            Gaji gaji = new Gaji();
            try
            {
                conn.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            gaji.Id = Convert.ToInt32(sqlDataReader[0]);
                            gaji.Pokok = Convert.ToInt32(sqlDataReader[1]);
                            gaji.Tunjangan = Convert.ToInt32(sqlDataReader[2]);
                            gaji.Akomodasi = Convert.ToInt32(sqlDataReader[3]);
                            gaji.Bank = sqlDataReader[4].ToString();
                            gaji.Rekening = sqlDataReader[5].ToString();

                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Rows");
                    }
                    sqlDataReader.Close();
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View(gaji);
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Gaji gaji) 
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                SqlParameter sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@id";
                sqlParameter.Value = gaji.Id;

                sqlCommand.Parameters.Add(sqlParameter);

                try
                {
                    sqlCommand.CommandText =
                    "DELETE FROM Gaji WHERE Id_Gaji = @id";

                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Data tidak boleh dihapus");
                }
            }
            return View();
        }

        //DETAILS
        public IActionResult Details(int id)
        {
            string query = "SELECT * FROM Gaji WHERE Id_Gaji = @id";

            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = "@id";
            sqlParameter.Value = id;

            conn = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            sqlCommand.Parameters.Add(sqlParameter);
            Gaji gaji = new Gaji();
            try
            {
                conn.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            gaji.Id = Convert.ToInt32(sqlDataReader[0]);
                            gaji.Pokok = Convert.ToInt32(sqlDataReader[1]);
                            gaji.Tunjangan = Convert.ToInt32(sqlDataReader[2]);
                            gaji.Akomodasi = Convert.ToInt32(sqlDataReader[3]);
                            gaji.Bank = sqlDataReader[4].ToString();
                            gaji.Rekening = sqlDataReader[5].ToString();

                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Rows");
                    }
                    sqlDataReader.Close();
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View(gaji);
        }

    }
}
