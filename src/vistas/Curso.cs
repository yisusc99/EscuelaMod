using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escuela.src.vistas
{
    public partial class Curso : Form
    {
        public Curso()
        {
            InitializeComponent();
            actualizarDatos();
            actualizarDatosC();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String query = "sp_AModalidad @nombre, @descripcion ";
            SqlCommand cmd = new SqlCommand(query, Conexion.getInstance().getConexion());
            cmd.Parameters.AddWithValue("@nombre ", textBox5.Text);
            cmd.Parameters.AddWithValue("@descripcion", textBox6.Text);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Modalidad creada correctamente!");
                actualizarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void actualizarDatos()
        {
            String query = " SELECT * FROM dbo.selectModalidad()";
            SqlDataAdapter ada = new SqlDataAdapter(query, Conexion.getInstance().getConexion());
            DataTable dataSet = new DataTable();

            dataGridView2.DataSource = null;
            dataGridView2.Rows.Clear();
            ada.Fill(dataSet);
            dataGridView2.DataSource = dataSet;
        }
        private void actualizarDatosC()
        {
            String query = " SELECT * FROM dbo.selectCurso()";
            SqlDataAdapter ada = new SqlDataAdapter(query, Conexion.getInstance().getConexion());
            DataTable dataSet = new DataTable();

            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            ada.Fill(dataSet);
            dataGridView1.DataSource = dataSet;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            String query = "sp_UModalidad @id, @nombre, @descripcion ";
            SqlCommand cmd = new SqlCommand(query, Conexion.getInstance().getConexion());
            cmd.Parameters.AddWithValue("@nombre ", textBox5.Text);
            cmd.Parameters.AddWithValue("@descripcion", textBox6.Text);
            cmd.Parameters.AddWithValue("@id", id);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Modalidad actualizada correctamente!");
                actualizarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String query = "sp_DModalidad @id ";
            SqlCommand cmd = new SqlCommand(query, Conexion.getInstance().getConexion());
            cmd.Parameters.AddWithValue("@id", id);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Modalidad  eliminada correctamente!");
                actualizarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void modalidades_Enter(object sender, EventArgs e)
        {

        }
        private int id;
        private void seleccionaFilaA(object sender, EventArgs e)
        {
           id = Convert.ToInt32( dataGridView2.CurrentRow.Cells[0].Value.ToString());
            textBox1.Text = id.ToString();
            textBox5.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            textBox6.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            String query = "sp_ACurso @modalidad, @grado, @jornada ";
            SqlCommand cmd = new SqlCommand(query, Conexion.getInstance().getConexion());
            cmd.Parameters.AddWithValue("@modalidad ", textBox1.Text);
            cmd.Parameters.AddWithValue("@grado", textBox2.Text);
            cmd.Parameters.AddWithValue("@jornada", textBox3.Text);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Curso creado correctamente!");
                actualizarDatosC();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private int idcurso;
        private void button5_Click(object sender, EventArgs e)
        {
            String query = "sp_UCurso @id, @modalidad, @grado, @jornada ";
            SqlCommand cmd = new SqlCommand(query, Conexion.getInstance().getConexion());
            cmd.Parameters.AddWithValue("@modalidad ", textBox1.Text);
            cmd.Parameters.AddWithValue("@grado", textBox2.Text);
            cmd.Parameters.AddWithValue("@jornada", textBox3.Text);
            cmd.Parameters.AddWithValue("@id", idcurso);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Curso modificado correctamente!");
                actualizarDatosC(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String query = "sp_DCurso @id ";
            SqlCommand cmd = new SqlCommand(query, Conexion.getInstance().getConexion());
            cmd.Parameters.AddWithValue("@id ", idcurso);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Curso eliminado correctamente!");
                actualizarDatosC();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void seleccionaFilaB(object sender, EventArgs e)
        {
            idcurso = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }
    }
}
