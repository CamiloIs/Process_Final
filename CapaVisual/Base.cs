using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaVisual
{
    public partial class Base : Form
    {
        public Base()
        {
            InitializeComponent();

            openChildFormInPanel(new panelAdmin());
        }

        private Form activeForm = null;
        private void openChildFormInPanel(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelContenedor.Controls.Add(childForm);
            panelContenedor.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void bntRegistrar_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new panelAdmin());
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            const string message = "Si Cierra la Aplicion se Cerrara su Sesion \n Seguro Desea Salir?";
            const string caption = "Mensaje de sistema";
            var result = MessageBox.Show(this, message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Exclamation);


            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new UnidadesInternas());
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new Proyectos());
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            const string message = "Seguro que desea cerrar la sesion? \n Volvéra a la Ventana de Inicio";
            const string caption = "Mensaje de Sistema";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);


            if (result == DialogResult.Yes)
            {
                this.Hide();
                Login plogin = new Login();
                plogin.ShowDialog();
            }
        }
    }
}
