using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Modelos
{
    public class Peliculas
    {
        private int id;
        private string nombrePeliculas;
        private string director;
        private DateTime fechaLanzamiento;

        public int Id { get => id; set => id = value; }

        public string Director { get => director; set => director = value; }
        public DateTime FechaLanzamiento { get => fechaLanzamiento; set => fechaLanzamiento = value; }
        public string NombrePeliculas { get => nombrePeliculas; set => nombrePeliculas = value; }

        public static DataTable CargarPeliculas()
        {
            SqlConnection con = conexion.Conectar();
            string comando = "select * from peliculas;";
            SqlDataAdapter ad = new SqlDataAdapter(comando, con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            return dt;
        }
        public bool InsertarPeliculas()
        {
            SqlConnection con = conexion.Conectar();
            string comando = "Insert into Peliculas (nombrePeliculas, director, fechaLanzamiento)" + "values (@nombre, @Director, @fechaLanzamiento);";
            SqlCommand cmd = new SqlCommand(comando, con);
            cmd.Parameters.AddWithValue("@nombre", nombrePeliculas);
            cmd.Parameters.AddWithValue("@director", director);
            cmd.Parameters.AddWithValue("@fechaLanzamiento", fechaLanzamiento);


            if (cmd.ExecuteNonQuery() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool eliminarPelicula(int id)
        {
            SqlConnection con = conexion.Conectar();
            string comando = "Delete from peliculas where idPeliculas = @idPeliculas";
            SqlCommand cmd = new SqlCommand(comando, con);
            cmd.Parameters.AddWithValue("@idPeliculas",id);
            if (cmd.ExecuteNonQuery() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool ActualizarPeliculas()

        {

            SqlConnection con = conexion.Conectar();

            //Creamos el comando necesario para actualizar datos

            string comando = "Update Peliculas set nombrePeliculas = @nombre, director = @director, fechaLanzamiento = @fechaLanzamiento where idPeliculas = @idPeliculas;";

            //Creamos un objeto de tipo SqlCommand

            SqlCommand cmd = new SqlCommand(comando, con);

            //Sustituimos los valores temporales por los valores reales

            cmd.Parameters.AddWithValue("@nombre", nombrePeliculas);

            cmd.Parameters.AddWithValue("@director", director);

            cmd.Parameters.AddWithValue("@fechaLanzamiento", fechaLanzamiento);

            cmd.Parameters.AddWithValue("@idPeliculas", id);

            //Enviamos el comando a SQL Server

            if (cmd.ExecuteNonQuery() > 0)

            {

                return true;

            }

            else

            {

                return false;

            }

        }

    }
}

