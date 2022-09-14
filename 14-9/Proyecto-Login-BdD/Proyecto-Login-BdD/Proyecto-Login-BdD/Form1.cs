using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Proyecto_Login_BdD
{
    public partial class Form1 : Form
    {

        string Correo;
        string Contraseña;
        OleDbConnection BaseDeDatosProyecto;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            BaseDeDatosProyecto = new OleDbConnection();
            BaseDeDatosProyecto.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=BdD-Access.accdb;";
            BaseDeDatosProyecto.Open();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (TxtCorreo.Text == "" || TxtContra.Text == "")
            {
                MessageBox.Show("Dale, completá todos los campos");
            }

            {
                Correo = TxtCorreo.Text;
                Contraseña = TxtContra.Text;

                OleDbCommand query = new OleDbCommand("SELECT Nombre, Apellido FROM Tabla WHERE Correo = '" + Correo + "' AND Contra = '" + Contraseña + "'", BaseDeDatosProyecto);
                string dato = Convert.ToString(query);

                OleDbDataReader reader = query.ExecuteReader();

                int i = 0;

                while (reader.Read())
                {
                    MessageBox.Show("Bienvenido, " + reader.GetString(0));
                    i++;
                }

                if (i == 0)
                {
                    MessageBox.Show("Correo incorrecto o contraseña incorrecta.");
                }
               
            }

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
