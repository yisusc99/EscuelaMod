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
    public partial class Alumno : Form
    {
        public Alumno()
        {
            InitializeComponent();
        }

        private void Alumno_Load(object sender, EventArgs e)
        {
           
            actualizarDatos();
        }

        private void actualizarDatos()
        {
            String query = " SELECT * FROM verAlumno";
            SqlDataAdapter ada = new SqlDataAdapter(query, Conexion.getInstance().getConexion());
            DataTable dataSet = new DataTable();

            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            ada.Fill(dataSet);
            dataGridView1.DataSource = dataSet;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            String query = "sp_AAlumno @nombre, @apellido,@fechaNac, @RN ";
            SqlCommand cmd = new SqlCommand(query, Conexion.getInstance().getConexion());
            cmd.Parameters.AddWithValue("@nombre", textBox1.Text);
            cmd.Parameters.AddWithValue("@apellido", textBox2.Text);
            cmd.Parameters.AddWithValue("@RN", textBox3.Text);
            cmd.Parameters.AddWithValue("@fechaNac", dateTimePicker1.Value);
            int ids = 0;

            try
            {
                cmd.ExecuteNonQuery();
                actualizarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            String query = "sp_uAlumno @id, @nombre, @apellido, @fechaNac, @RN";
            SqlCommand cmd = new SqlCommand(query, Conexion.getInstance().getConexion());
            cmd.Parameters.AddWithValue("@nombre", textBox1.Text);
            cmd.Parameters.AddWithValue("@apellido", textBox2.Text);
            cmd.Parameters.AddWithValue("@RN", textBox3.Text);
            cmd.Parameters.AddWithValue("@fechaNac", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@id", comboBox1.Text);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Alumno actualizado correctamente!");
                actualizarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String query = "sp_DAlumno @id";
            SqlCommand cmd = new SqlCommand(query, Conexion.getInstance().getConexion());
            cmd.Parameters.AddWithValue("@id", comboBox1.Text);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Alumno eliminado correctamente!");
                actualizarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void seleccioneFila(object sender, EventArgs e)
        {
            comboBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[3].Value);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox5.Enabled = true;
        }

        private void textBox5_TextChanged_1(object sender, EventArgs e)
        {
            String query = null;
            if (comboBox2.SelectedIndex == 0)
                query = "SELECT * FROM dbo.selectAlumnoNom('" + textBox5.Text + "' )";
            else if (comboBox2.SelectedIndex == 1)
                query = "SELECT * FROM dbo.selectAlumnooape('" + textBox5.Text + "' )";
            else if (comboBox2.SelectedIndex == 2)
                query = "SELECT * FROM dbo.selectAlumnoid('" + textBox5.Text + "' )";
            else
                MessageBox.Show("Selecciona un filtro.");

            SqlDataAdapter ada = new SqlDataAdapter(query, Conexion.getInstance().getConexion());
            DataSet dataSet = new DataSet();

            ada.Fill(dataSet, "Alumno");

            dataGridView1.DataSource = dataSet;
            dataGridView1.DataMember = "Alumno";
        }

        private void seleccionaFilaA(object sender, EventArgs e)
        {

        }
    }
}
