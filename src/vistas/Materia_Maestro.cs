using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Escuela.src.vistas
{
    public partial class Materia_Maestro : Form
    {
        public Materia_Maestro()
        {
            InitializeComponent();
        }

        private void Materia_Maestro_Load(object sender, EventArgs e)
        {

            actualizarDatos();
            actualizarDatosProfesores();
            actualizarDatosMaterias();
        }


        private void actualizarDatos()
        {

            String query = " SELECT * FROM verMateriasProfesor";
            SqlDataAdapter ada = new SqlDataAdapter(query, Conexion.getInstance().getConexion());
            DataTable dataSet = new DataTable();

            dataGridView3.DataSource = null;
            dataGridView3.Rows.Clear();
            ada.Fill(dataSet);
            dataGridView3.DataSource = dataSet;
        }
        private void actualizarDatosMaterias()
        {

            String query = " SELECT * FROM verMateria";
            SqlDataAdapter ada = new SqlDataAdapter(query, Conexion.getInstance().getConexion());
            DataTable dataSet = new DataTable();

            dataGridView2.DataSource = null;
            dataGridView2.Rows.Clear();
            ada.Fill(dataSet);
            dataGridView2.DataSource = dataSet;
        }
        private void actualizarDatosProfesores()
        {

            String query = " SELECT * FROM verMaestro";
            SqlDataAdapter ada = new SqlDataAdapter(query, Conexion.getInstance().getConexion());
            DataTable dataSet = new DataTable();

            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            ada.Fill(dataSet);
            dataGridView1.DataSource = dataSet;
        }
        private void button1_Click(object sender, EventArgs e)
        {

            String query = "sp_AMateriaProfesor @materia, @profesor";
            SqlCommand cmd = new SqlCommand(query, Conexion.getInstance().getConexion());
            cmd.Parameters.AddWithValue("@profesor ", textBox1.Text);
            cmd.Parameters.AddWithValue("@materia", textBox2.Text);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Maestro asignado correctamente!");
                actualizarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String query = "sp_DMateriaProfesor @id";
            SqlCommand cmd = new SqlCommand(query, Conexion.getInstance().getConexion());
            cmd.Parameters.AddWithValue("@id ", id);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Maestro asignado correctamente!");
                actualizarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private int id;
        private void seleccionaFila(object sender, EventArgs e)
        {
            id = Convert.ToInt32(dataGridView3.CurrentRow.Cells[4].Value.ToString());
            label3.Text = "ID. " + id;
        }

        private void seleccionaFilaA(object sender, EventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }

        private void seleccionaFilaB(object sender, EventArgs e)
        {
            textBox2.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            textBox4.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
        }
    }
}
