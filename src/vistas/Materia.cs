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
using Escuela.src;

namespace Escuela.src.vistas
{
    public partial class FrMateria : Form
    {
        public FrMateria()
        {
            InitializeComponent();
        }

        

        private void Principal_Load(object sender, EventArgs e)
        {
            actualizarDatos();

        }

        private void actualizarDatos()
        {
            String query = " SELECT * FROM verMateria";
            SqlDataAdapter ada = new SqlDataAdapter(query, Conexion.getInstance().getConexion());
            DataTable dataSet = new DataTable();

            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            ada.Fill(dataSet);
            dataGridView1.DataSource = dataSet;

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            String query = "sp_AMateria @nombre, @descripcion";
            SqlCommand cmd = new SqlCommand(query, Conexion.getInstance().getConexion());
            cmd.Parameters.AddWithValue("@nombre", textBox1.Text);
            cmd.Parameters.AddWithValue("@descripcion", textBox2.Text);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Materia agregada correctamente!");
                actualizarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String query = "sp_DMateria @id";
            SqlCommand cmd = new SqlCommand(query, Conexion.getInstance().getConexion());
            cmd.Parameters.AddWithValue("@id", comboBox1.Text);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Materia eliminada correctamente!");
                actualizarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            String query = "";
            SqlDataAdapter ada = new SqlDataAdapter(query, Conexion.getInstance().getConexion());
            DataSet dataSet = new DataSet();

            ada.Fill(dataSet, "Materia");

            dataGridView1.DataSource = dataSet;
            dataGridView1.DataMember = "Materia";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String query = "sp_UMateria @id, @nombre, @descripcion ";
            SqlCommand cmd = new SqlCommand(query, Conexion.getInstance().getConexion());
            cmd.Parameters.AddWithValue("@nombre", textBox1.Text);
            cmd.Parameters.AddWithValue("@descripcion", textBox2.Text);
            cmd.Parameters.AddWithValue("@id", comboBox1.Text);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Materia actualizada correctamente!");
                actualizarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox5.Enabled = true;
        }

        private void textBox5_TextChanged_1(object sender, EventArgs e)
        {
            String query = null;
            if (comboBox2.SelectedIndex == 0)
                query = "SELECT * FROM dbo.selectMateriasNom('" + textBox5.Text + "' )";
            else if (comboBox2.SelectedIndex == 1)
                query = "SELECT * FROM dbo.selectMateriasId('" + textBox5.Text + "' )";
            else
                MessageBox.Show("Selecciona un filtro.");

            SqlDataAdapter ada = new SqlDataAdapter(query, Conexion.getInstance().getConexion());
            DataSet dataSet = new DataSet();

            ada.Fill(dataSet, "Alumno");

            dataGridView1.DataSource = dataSet;
            dataGridView1.DataMember = "Alumno";
        }

        private void seleccionaFila(object sender, EventArgs e)
        {
            comboBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }
    }
}
