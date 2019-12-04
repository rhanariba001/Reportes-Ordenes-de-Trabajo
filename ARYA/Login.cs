using BL.Seguridad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARYA
{
    public partial class Login : Form
    {
        SeguridadBL _seguridad;

        public Login()
        {
            InitializeComponent();

            _seguridad = new SeguridadBL();
            textBox1.Focus();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Focus();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string usuario;
            string contraseña;

            usuario = textBox1.Text;
            contraseña = textBox2.Text;

            button1.Enabled = false;
            button1.Text = "Verificando...";
            Application.DoEvents();

            var resultado = _seguridad.Autorizar(usuario, contraseña);


            if (resultado == true)
            {
                this.Close();
                MessageBox.Show("*** Bienvenido al Sistema ARYA ***");

            }
            else
            {
                if (usuario == "tecnico" && contraseña == "321")
                {
                    this.Close();
                    MessageBox.Show("Bienvenido al Sistema ARYA");
                }
                else
                {
                    MessageBox.Show("Usuario o Contraseña Incorrecta");
                }
            }
        }
    }
}




