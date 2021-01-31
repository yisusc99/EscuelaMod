using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Escuela.src.vistas;
using System.Data.SqlClient;
using Escuela.src;

namespace Escuela
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            actualizarDatos();
        }

        private void actualizarDatos()
        {
            // TODO: This line of code loads data into the 'sistemaEscuelaDataSet1.Materia' table. You can move, or remove it, as needed.
           // this.materiaTableAdapter.Fill(this.sistemaEscuelaDataSet1.Materia);
            
        }


      

        private void button1_Click_1(object sender, EventArgs e)
        {
            new Maestros().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new FrMateria().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Alumno().Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new Materia_Maestro().Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new Curso().Show();
        }
    }
}
