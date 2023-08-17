using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestWorkA.Models;

namespace TestWorkA.SqlTransactions
{
    public static class TechnicsTransaction
    {
        public static List<Technic> GetAllTechnics()
        {
            List<Technic> AllTechnics = new List<Technic>();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["TechnicDB"].ConnectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM Technics", connection);
                
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Technic technic = new Technic { Id = reader.GetInt32(0), Xposition = reader.GetFloat(1), Yposition = reader.GetFloat(2) };
                            AllTechnics.Add(technic);
                        }
                    }

                    return AllTechnics;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Reading Data Error. Returned null : {ex.Message}");
                    return null;
                }
                finally { connection.Close(); }
            }
        }
        public static bool SaveAllTechnics(List<Technic> technics)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["TechnicDB"].ConnectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

                try
                {
                    var updateTechnics = technics.Where(m => m.isModifide == true);

                    foreach (var tech in updateTechnics)
                    {
                        cmd.CommandText = string.Format($"UPDATE TechnicsDB.dbo.Technics SET XPosition = @Xpos, YPosition = @Ypos WHERE Id = @id");
                        cmd.Parameters.AddWithValue("@Xpos", tech.Xposition);
                        cmd.Parameters.AddWithValue("@Ypos", tech.Yposition);
                        cmd.Parameters.AddWithValue("@id", tech.Id);
                        cmd.ExecuteNonQuery();
                    }

                    return true;
                }
                catch(Exception ex)
                {
                    MessageBox.Show($"Data Saving exception: {ex.Message}");

                    return false;
                }
                finally { connection.Close(); }
            }
        }
        public static void UpdateOneUser(Technic tech)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["TechnicDB"].ConnectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

                try
                {
                    cmd.CommandText = "UPDATE TechnicsDB.dbo.Technics SET XPosition = @Xpos, YPosition = @Ypos WHERE Id = @id";
                    cmd.Parameters.AddWithValue("@Xpos", tech.Xposition);
                    cmd.Parameters.AddWithValue("@Ypos", tech.Yposition);
                    cmd.Parameters.AddWithValue("@id", tech.Id);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Data Saving exception: {ex.Message}");
                }
                finally { connection.Close(); }
            }
        }
    }
}
