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
    public partial class Maestros : Form
    {
        public Maestros()
        {
            InitializeComponent();
            dataGridView1.ClearSelection();
        }

        private void Maestros_Load(object sender, EventArgs e)
        {
            
            actualizarDatos();

        }

        private void actualizarDatos() 
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
            String query = "sp_AMaestro @nombre, @apellido, @fechaNac, @identidad, @contrasena";
            SqlCommand cmd = new SqlCommand(query, Conexion.getInstance().getConexion());
            cmd.Parameters.AddWithValue("@nombre", textBox1.Text);
            cmd.Parameters.AddWithValue("@apellido", textBox2.Text);
            cmd.Parameters.AddWithValue("@identidad", textBox3.Text);
            cmd.Parameters.AddWithValue("@contrasena", textBox4.Text);
            cmd.Parameters.AddWithValue("@fechaNac", dateTimePicker1.Value);

            try 
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Maestro agregado correctamente!");
                actualizarDatos();
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String query = " sp_UMaestro @id, @nombre, @apellido, @fechaNac, @identidad, @contrasena";
            SqlCommand cmd = new SqlCommand(query, Conexion.getInstance().getConexion());
            cmd.Parameters.AddWithValue("@nombre", textBox1.Text);
            cmd.Parameters.AddWithValue("@apellido", textBox2.Text);
            cmd.Parameters.AddWithValue("@identidad", textBox3.Text);
            cmd.Parameters.AddWithValue("@contrasena", textBox4.Text);
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
            String query = "sp_DMaestro @id";
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            String query = null;
            if (comboBox2.SelectedIndex == 0)
                query = "SELECT * FROM dbo.selectMaestroNom('" + textBox5.Text + "' )";
            else if (comboBox2.SelectedIndex == 1)
                query = "SELECT * FROM dbo.selectMaestroape('" + textBox5.Text + "' )";
            else if (comboBox2.SelectedIndex == 2)
                query = "SELECT * FROM dbo.selectMaestroid('" + textBox5.Text + "' )";
            else
                MessageBox.Show("Selecciona un filtro.");

            SqlDataAdapter ada = new SqlDataAdapter(query, Conexion.getInstance().getConexion());
            DataSet dataSet = new DataSet();

            ada.Fill(dataSet, "Maestro");

            dataGridView1.DataSource = dataSet;
            dataGridView1.DataMember = "Maestro";
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void seleccioneFila(object sender, EventArgs e)
        {
            comboBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString(); 
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString(); 
            textBox3.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString(); 
            textBox4.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString(); 
            dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[3].Value);
        }

        private void habilitaBusqueda(object sender, EventArgs e)
        {
            textBox5.Enabled = true;
        }
    }
}
