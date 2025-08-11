using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace Modelos
{
    public class conexion
    {
        private static string servidor = "LAB03-DS-EQ06\\SQLEXPRESS";
        private static string baseDeDatos = "Cine";
        private static string cadena;

        public static SqlConnection Conectar()
        {
            string Cadena = 
            $"Data Source = {servidor}; " +
            $"Initial Catalog = { baseDeDatos};" +
            $"Integrated Security = true;";

            SqlConnection con = new SqlConnection(Cadena);

            con.Open();

            return con;

        }



    }
}
