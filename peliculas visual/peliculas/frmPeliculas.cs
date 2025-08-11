using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Modelos;

namespace peliculas
{
    public partial class frmPeliculas : Form
    {
        public frmPeliculas()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            MostrarPeliculas();
        
        }
        private void MostrarPeliculas()
        {
            dgvPeliculas.DataSource = null;
            dgvPeliculas.DataSource = Peliculas.CargarPeliculas();
        }

        private void btmAgregar_Click(object sender, EventArgs e)
        {
            Peliculas p = new Peliculas();
            p.NombrePeliculas = txtNombre.Text;
            p.FechaLanzamiento = dtpFechaEstreno.Value;
            p.Director = txtDirector.Text;
            p.InsertarPeliculas();
            MostrarPeliculas();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dgvPeliculas.CurrentRow.Cells[0].Value.ToString());
            Peliculas p = new Peliculas();
            if (p.eliminarPelicula(id) == true)
            {
                MessageBox.Show("Pelicula eliminada");
                MostrarPeliculas();
            }
            else
            {
                MessageBox.Show("No se pudo eliminar la pelicula");
            }   


        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Peliculas p = new Peliculas();

            p.NombrePeliculas = txtNombre.Text;
            p.Director = txtDirector.Text;
            p.FechaLanzamiento = dtpFechaEstreno.Value;
            p.Id = int.Parse(dgvPeliculas.CurrentRow.Cells[0].Value.ToString());

            if (p.ActualizarPeliculas() == true)
            {
                MessageBox.Show("Registro actualizado satisfactoriamente", "Éxito");
                MostrarPeliculas();
                txtDirector.Text = "";
                txtNombre.Text = "";
                dtpFechaEstreno.Value = DateTime.Now;
            }
            else
            {
                MessageBox.Show("Hubo un error", "Advertencia");
            }
        }

        private void dgvPeliculas_DoubleClick(object sender, EventArgs e)
        {
            txtNombre.Text = dgvPeliculas.CurrentRow.Cells[1].Value.ToString();
            txtDirector.Text = dgvPeliculas.CurrentRow.Cells[2].Value.ToString();
            dtpFechaEstreno.Value = DateTime.Parse(dgvPeliculas.CurrentRow.Cells[3].Value.ToString());
        }
    }
}
