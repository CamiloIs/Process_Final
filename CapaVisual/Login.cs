using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;
using CapaNegocio;
using CapaSoporte.cache;
using MySql.Data.MySqlClient;

namespace CapaVisual
{
    public partial class Login : Form
    {
        MySqlConnection conexion =  new MySqlConnection("Server=localhost; Database=process; User=root; port=3306; password=Root; SSL Mode=0;");
        public Login()
        {
            InitializeComponent();
            txtPass.UseSystemPasswordChar = true;
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUser.Text != "user" && txtUser.TextLength > 2)
                {
                    if (txtPass.Text != "pass")
                    {
                        modeloUsuario user = new modeloUsuario();
                        var validLogin = user.LoginUsuario(txtUser.Text, txtPass.Text);
                        if (validLogin == true)
                        {
                            if (cuenta.rol == "Administrador")
                            {

                                Base mainMenu = new Base();
                                MessageBox.Show("Bienvenido " + cuenta.usuario);
                                mainMenu.Show();
                                mainMenu.FormClosed += Logout;
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Usuario no es Administrador");

                            }

                        }
                        else
                        {
                            MessageBox.Show("Error Usuario/Contraseña Incorrectos", "Mensaje de Sistema");
                            txtPass.Text = "";

                            txtUser.Focus();
                        }
                    }
                    else MessageBox.Show("Ingrese una Contraseña", "Mensaje de Sistema");
                }
                else MessageBox.Show("Ingrese un Nombre de Usuario", "Mensaje de Sistema");
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error :" + exception.Message);
            }


        }
        
        private void Logout(object sender, FormClosedEventArgs e)
        {
            txtPass.Text = "";
            txtPass.UseSystemPasswordChar = true;
            txtUser.Text = "";
            //lblError.Visible = false;
            this.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            const string message = "Se Cerrara la Aplicacion \n Seguro Desea Salir?";
            const string caption = "Mensaje de sistema";
            var result = MessageBox.Show(this, message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Exclamation);


            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
