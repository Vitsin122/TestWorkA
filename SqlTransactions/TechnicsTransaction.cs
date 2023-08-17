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
                            Technic technic = new Technic { Id = reader.GetInt32(0), Xposition = reader.GetDouble(1), Yposition = reader.GetDouble(2) };
                            AllTechnics.Add(technic);
                        }
                    }

                    return AllTechnics;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Reading Data Error. Returned null");
                    return null;
                }
                finally { connection.Close(); }
            }
        }
        //public static bool SaveAllTechnics(List<Technic> technics)
        //{

        //}
    }
}
