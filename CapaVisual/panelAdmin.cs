using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaSoporte.cache;
using CapaNegocio;
using CapaAcessoDatos;
using MySql.Data.MySqlClient;
using System.Net.Mail;

namespace CapaVisual
{
    public partial class panelAdmin : Form
    {
        public panelAdmin()
        {
            InitializeComponent();
            cbxRol.DataSource = Enum.GetValues(typeof(EnumRol));          
            cbxregion.DataSource = Enum.GetValues(typeof(enuReg));
            cbxcomuna.DataSource = Enum.GetValues(typeof(comuna));
            
        }
        modeloUsuario man = new modeloUsuario();
        private bool Editar = false;
        private int id;

        MySqlConnection conectar = new MySqlConnection("Server=localhost; Database=process; User=root; port=3306; password=Root; SSL Mode=0;");
        DataSet ds;

        DataSet resultado = new DataSet();
        DataView miFiltro;

        public void combo()
        {
            if (cbxregion.SelectedIndex == 1)
            {
                cbxcomuna.DataSource = Enum.GetValues(typeof(comuna1));
            }

            if (cbxregion.SelectedIndex == 2)
            {
                cbxcomuna.DataSource = Enum.GetValues(typeof(comuna2));
            }

            if (cbxregion.SelectedIndex == 3)
            {
                cbxcomuna.DataSource = Enum.GetValues(typeof(comuna3));
            }

            if (cbxregion.SelectedIndex == 4)
            {
                cbxcomuna.DataSource = Enum.GetValues(typeof(comuna4));
            }

            if (cbxregion.SelectedIndex == 5)
            {
                cbxcomuna.DataSource = Enum.GetValues(typeof(comuna5));
            }

            if (cbxregion.SelectedIndex == 6)
            {
                cbxcomuna.DataSource = Enum.GetValues(typeof(comuna6));
            }

            if (cbxregion.SelectedIndex == 7)
            {
                cbxcomuna.DataSource = Enum.GetValues(typeof(comuna7));
            }

            if (cbxregion.SelectedIndex == 8)
            {
                cbxcomuna.DataSource = Enum.GetValues(typeof(comuna8));
            }

            if (cbxregion.SelectedIndex == 9)
            {
                cbxcomuna.DataSource = Enum.GetValues(typeof(comuna9));
            }

            if (cbxregion.SelectedIndex == 10)
            {
                cbxcomuna.DataSource = Enum.GetValues(typeof(comuna10));
            }

            if (cbxregion.SelectedIndex == 11)
            {
                cbxcomuna.DataSource = Enum.GetValues(typeof(comuna11));
            }

            if (cbxregion.SelectedIndex == 12)
            {
                cbxcomuna.DataSource = Enum.GetValues(typeof(comuna12));
            }

            if (cbxregion.SelectedIndex == 13)
            {
                cbxcomuna.DataSource = Enum.GetValues(typeof(comuna13));
            }
            if (cbxregion.SelectedIndex == 14)
            {
                cbxcomuna.DataSource = Enum.GetValues(typeof(comuna14));
            }
            if (cbxregion.SelectedIndex == 15)
            {
                cbxcomuna.DataSource = Enum.GetValues(typeof(comuna15));
            }
            if (cbxregion.SelectedIndex == 16)
            {
                cbxcomuna.DataSource = Enum.GetValues(typeof(comuna16));
            }
        }

        private void MostrarTabla()
        {
            conectar.Open();
            MySqlCommand comm = new MySqlCommand("SELECT u.idusuario, u.rut, u.nombre,u.apellidos, u.correo, u.telefono, u.region, u.comuna, " +
                                                 "c.usuario, c.password, u.cargo, c.rol FROM usuario u JOIN cuenta c ON u.idusuario = c.idcuenta; ", conectar);

            MySqlDataAdapter con = new MySqlDataAdapter(comm);
            ds = new DataSet();
            con.Fill(ds);
            dtUsuarios.DataSource = ds.Tables[0];
            conectar.Close();

        }

        private void MostrarId()
        {
            conectar.Open();
            MySqlCommand comm = new MySqlCommand("select max(idusuario) as id from usuario", conectar);

            MySqlDataAdapter con = new MySqlDataAdapter(comm);
            ds = new DataSet();
            con.Fill(ds);
            dtcargo.DataSource = ds.Tables[0];
            conectar.Close();
            


        }

        private void LoadUserData()
        {
            lblUser.Text = cacheUsuario.nombre;
            lblRol.Text = cuenta.rol;
            lblCorreo.Text = cacheUsuario.correo;
        }

        private void panelAdmin_Load(object sender, EventArgs e)
        {
            this.leerDatos("SELECT u.idusuario, u.rut, u.nombre, u.apellidos, u.correo, u.telefono, u.region, u.comuna, c.usuario, c.password, u.cargo, c.rol " +
                           "FROM usuario u JOIN cuenta c ON u.idusuario = c.idcuenta; ", ref resultado, "usuario");
            this.miFiltro = ((DataTable)resultado.Tables["usuario"]).DefaultView;
            this.dtUsuarios.DataSource = miFiltro;
      
        }

        
    
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (Editar == false)
            {
                try
                {
                    if (txtRut.Text == String.Empty)
                    {
                        MessageBox.Show("Ingrese un Rut", "Mensaje de Sistema");                     
                    }
                    else
                    {
                        if (txtNombre.Text == String.Empty)
                        {
                             MessageBox.Show("Ingrese un Nombre", "Mensaje de Sistema");
                        }
                        else
                        {
                            if (txtApellido.Text == String.Empty)
                            {
                                MessageBox.Show("Ingrese un Apellido", "Mensaje de Sistema");
                            }
                            else
                            {
                                if (txtCorreo.Text == String.Empty)
                                {
                                    MessageBox.Show("Ingrese un Correo", "Mensaje de Sistema");
                                }
                                else
                                {                                                           
                                    if (txtTelefono.Text == String.Empty)
                                    {
                                        MessageBox.Show("Ingrese un Telefono", "Mensaje de Sistema");
                                    }
                                    else
                                    {
                                        if (cbxregion.SelectedIndex == 0)
                                        {
                                            MessageBox.Show("Seleccione una Region", "Mensaje de Sistema");
                                        }
                                        else
                                        {
                                            if (cbxcomuna.SelectedIndex == 0)
                                            {
                                                MessageBox.Show("Seleccione una Comuna", "Mensaje de Sistema");
                                            }
                                            else
                                            {
                                                if (txtUser.Text == String.Empty)
                                                {
                                                    MessageBox.Show("Ingrese un Nombre de Usuario", "Mensaje de Sistema");
                                                }
                                                else
                                                {
                                                    if (txtPass.Text == String.Empty)
                                                    {
                                                        MessageBox.Show("Ingrese una Contraseña", "Mensaje de Sistema");
                                                    }
                                                    else
                                                    {
                                                        if (txtCargo.Text == String.Empty)
                                                        {
                                                            MessageBox.Show("Ingrese un Cargo", "Mensaje de Sistema");
                                                        }
                                                        else
                                                        {
                                                            if (cbxRol.SelectedIndex == 0)
                                                            {
                                                                MessageBox.Show("Seleccione un Rol", "Mensaje de Sistema");
                                                            }
                                                            else
                                                            {
                                                                if (validarEmail(txtCorreo.Text) == true)
                                                                {
                                                                    modeloUsuario man = new modeloUsuario();

                                                                    Usuario.rut = this.txtRut.Text;
                                                                    Usuario.nombre = this.txtNombre.Text;
                                                                    Usuario.apellidos = this.txtApellido.Text;
                                                                    Usuario.correo = this.txtCorreo.Text;
                                                                    Usuario.telefono = Convert.ToInt32(this.txtTelefono.Text);
                                                                    Usuario.region = this.cbxregion.SelectedItem.ToString();
                                                                    Usuario.comuna = this.cbxcomuna.SelectedItem.ToString();
                                                                    Usuario.usuario = this.txtUser.Text;
                                                                    Usuario.cargo = this.txtCargo.Text;
                                                                    man.insert();

                                                                    id = man.idUser(Usuario.idUsuario);
                                                                    MostrarId();
                                                                    MostrarTabla();
                                                                    txtid.Text = dtcargo.CurrentRow.Cells[0].Value.ToString();

                                                                    cuenta.idCuenta = Convert.ToInt32(this.txtid.Text);
                                                                    cuenta.usuario = this.txtUser.Text;
                                                                    cuenta.password = this.txtPass.Text;
                                                                    cuenta.rol = this.cbxRol.SelectedItem.ToString();
                                                                    man.insertCuenta();
                                                                    MostrarTabla();

                                                                    Limpiar();
                                                                    MessageBox.Show("Usuario Creado Exitosamente");

                                                                }
                                                                else
                                                                {
                                                                    MessageBox.Show("Formato de Correo no Valido", "Mensaje de Sistema");

                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }                                  
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Datos no guardados" + ex.Message, "Mensaje de Sistema");
                }
            }         
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (Editar == true)
            {
                try
                {
                    if (txtRut.Text == String.Empty)
                    {
                        MessageBox.Show("Ingrese un Rut", "Mensaje de Sistema");
                    }
                    else
                    {
                        if (txtNombre.Text == String.Empty)
                        {
                            MessageBox.Show("Ingrese un Nombre", "Mensaje de Sistema");
                        }
                        else
                        {
                            if (txtApellido.Text == String.Empty)
                            {
                                MessageBox.Show("Ingrese un Apellido", "Mensaje de Sistema");
                            }
                            else
                            {
                                if (txtCorreo.Text == String.Empty)
                                {
                                    MessageBox.Show("Ingrese un Correo", "Mensaje de Sistema");
                                }
                                else
                                {
                                    if (txtTelefono.Text == String.Empty)
                                    {
                                        MessageBox.Show("Ingrese un Telefono", "Mensaje de Sistema");
                                    }
                                    else
                                    {
                                        if (cbxregion.SelectedIndex == 0)
                                        {
                                            MessageBox.Show("Seleccione una Region", "Mensaje de Sistema");
                                        }
                                        else
                                        {
                                            if (cbxcomuna.SelectedIndex == 0)
                                            {
                                                MessageBox.Show("Seleccione una Comuna", "Mensaje de Sistema");
                                            }
                                            else
                                            {
                                                if (txtUser.Text == String.Empty)
                                                {
                                                    MessageBox.Show("Ingrese un Nombre de Usuario", "Mensaje de Sistema");
                                                }
                                                else
                                                {
                                                    if (txtPass.Text == String.Empty)
                                                    {
                                                        MessageBox.Show("Ingrese una Contraseña", "Mensaje de Sistema");
                                                    }
                                                    else
                                                    {
                                                        if (txtCargo.Text == String.Empty)
                                                        {
                                                            MessageBox.Show("Ingrese un Cargo", "Mensaje de Sistema");
                                                        }
                                                        else
                                                        {
                                                            if (cbxRol.SelectedIndex == 0)
                                                            {
                                                                MessageBox.Show("Seleccione un Rol", "Mensaje de Sistema");
                                                            }
                                                            else
                                                            {
                                                                if (validarEmail(txtCorreo.Text) == true)
                                                                {
                                                                    modeloUsuario man = new modeloUsuario();


                                                                    Usuario.idUsuario = Convert.ToInt32(txtid.Text);
                                                                    Usuario.rut = txtRut.Text;
                                                                    Usuario.nombre = txtNombre.Text;
                                                                    Usuario.apellidos = txtApellido.Text;
                                                                    Usuario.correo = txtCorreo.Text;
                                                                    Usuario.telefono = Convert.ToInt32(txtTelefono.Text);
                                                                    Usuario.region = cbxregion.SelectedItem.ToString();
                                                                    Usuario.comuna = cbxcomuna.SelectedItem.ToString();
                                                                    Usuario.usuario = txtUser.Text;
                                                                    Usuario.cargo = txtCargo.Text;


                                                                    cuenta.idCuenta = Convert.ToInt32(this.txtid.Text);
                                                                    cuenta.usuario = this.txtUser.Text;
                                                                    cuenta.password = this.txtPass.Text;
                                                                    cuenta.rol = this.cbxRol.SelectedItem.ToString();
                                                                    man.updateUser(Usuario.rut);
                                                                    man.updateCuenta(cuenta.usuario);
                                                                    MostrarTabla();
                                                                    Limpiar();
                                                                    MessageBox.Show("Usuario Actualizado Exitosamente");

                                                                }
                                                                else
                                                                {
                                                                    MessageBox.Show("Formato de Correo no Valido", "Mensaje de Sistema");

                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Usuario no Actualizado" + ex.Message, "Mensaje de Sistema");
                }
            }

            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtUsuarios.SelectedRows.Count == 1)
                {
                    modeloUsuario man = new modeloUsuario();
                    Usuario.idUsuario = Convert.ToInt32(dtUsuarios.CurrentRow.Cells["idusuario"].Value.ToString());
                    man.eliminarCuenta(id);
                    man.eliminarUser(id);
                    MostrarTabla();
                    Limpiar();

                    

                    MessageBox.Show("Eliminado correctamente", "Mensaje de Sistema");
                    
                }
                else
                    MessageBox.Show("Seleccione una fila por favor", "Mensaje de Sistema");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }

        
        private void leerDatos(string query, ref DataSet dtsprincipal, string tabla)
        {
            try
            {
                string cadena = "Server = localhost; Database = process; User = root; port = 3306; password =Root; SSL Mode = 0; ";
                MySqlConnection cn = new MySqlConnection(cadena);
                MySqlCommand cmd = new MySqlCommand(query, cn);
                cn.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dtsprincipal, tabla);
                da.Dispose();
                cn.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            string salidaDatos = string.Empty;
            string[] palabras_busqueda = this.txtBuscar.Text.Split(' ');

            foreach (string palabra in palabras_busqueda)
            {
                if(salidaDatos.Length == 0)
                {
                    salidaDatos = "(nombre LIKE '%" + palabra + "%' OR apellidos LIKE '%" + palabra + "%' OR rut LIKE '%" + palabra
                                + "%' OR usuario LIKE '%" + palabra + "%' OR correo LIKE '%" + palabra + "%' OR rol LIKE '%" + palabra + "%')";
                }
                else
                {
                    salidaDatos += " AND (nombre LIKE '%" + palabra + "%' OR apellidos LIKE '%" + palabra + "%' OR rut LIKE '%" + palabra
                                + "%' OR usuario LIKE '%" + palabra + "%' OR correo LIKE '%" + palabra + "%' OR rol LIKE '%" + palabra + "%')";
                }
            }

            this.miFiltro.RowFilter = salidaDatos;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dtUsuarios.SelectedRows.Count == 1)
            {
                Editar = true;
                txtid.Text = dtUsuarios.CurrentRow.Cells["idusuario"].Value.ToString();
                txtRut.Text = dtUsuarios.CurrentRow.Cells["rut"].Value.ToString();
                txtNombre.Text = dtUsuarios.CurrentRow.Cells["nombre"].Value.ToString();
                txtApellido.Text = dtUsuarios.CurrentRow.Cells["apellidos"].Value.ToString();
                txtCorreo.Text = dtUsuarios.CurrentRow.Cells["correo"].Value.ToString();
                txtTelefono.Text = dtUsuarios.CurrentRow.Cells["telefono"].Value.ToString();
                cbxregion.Text = dtUsuarios.CurrentRow.Cells["region"].Value.ToString();
                cbxcomuna.Text = dtUsuarios.CurrentRow.Cells["comuna"].Value.ToString();
                txtUser.Text = dtUsuarios.CurrentRow.Cells["usuario"].Value.ToString();
                txtPass.Text = dtUsuarios.CurrentRow.Cells["password"].Value.ToString();
                txtCargo.Text = dtUsuarios.CurrentRow.Cells["cargo"].Value.ToString();
                cbxRol.Text = dtUsuarios.CurrentRow.Cells["rol"].Value.ToString();
                
            }
            else
            {
                MessageBox.Show("Seleccione una fila por favor", "Mensaje de Sistema");
            }
        }

        

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void Limpiar()
        {
            txtid.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtRut.Clear();
            txtUser.Clear();
            txtCorreo.Clear();
            cbxRol.SelectedIndex = 0;
            txtPass.Clear();
            cbxregion.SelectedIndex = 0;
            cbxcomuna.SelectedIndex = 0;
            txtPass.Clear();
            txtCargo.Clear();
            txtTelefono.Clear();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void dtcargo_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {
           
        }

        private void cbxregion_SelectedIndexChanged(object sender, EventArgs e)
        {
            combo();
        }


        static bool validarEmail(string email)
        {
            try
            {
                new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private void txtRut_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.K)
            {
                e.Handled = false;
            }

            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar.ToString().ToUpper().Equals("K"))
            {
                e.Handled = false;
            }
            else if (e.KeyChar.ToString().ToUpper().Equals("-"))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso 
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan 
                e.Handled = true;
            }
        }

        private void txtRut_KeyUp(object sender, KeyEventArgs e)
        {
            txtRut.Text = FormatearRut(txtRut.Text);
            txtRut.SelectionStart = txtRut.Text.Length;
            txtRut.SelectionLength = 0;
        }

        public static string FormatearRut(string rut)
        {
            string rutFormateado = string.Empty;

            if (rut.Length == 0)
            {
                rutFormateado = "";
            }
            else
            {
                string rutTemporal;
                string dv;
                Int64 rutNumerico;

                rut = rut.Replace("-", "").Replace(".", "");

                if (rut.Length == 1)
                {
                    rutFormateado = rut;
                }
                else
                {
                    rutTemporal = rut.Substring(0, rut.Length - 1);
                    dv = rut.Substring(rut.Length - 1, 1);

                    //aqui convierto a un numero el RUT si ocurre un error lo deja en CERO
                    if (!Int64.TryParse(rutTemporal, out rutNumerico))
                    {
                        rutNumerico = 0;
                    }

                    //este comando es el que formatea con los separadores de miles
                    rutFormateado = rutNumerico.ToString("N0");

                    if (rutFormateado.Equals("0"))
                    {
                        rutFormateado = string.Empty;
                    }
                    else
                    {
                        //si no hubo problemas con el formateo agrego el DV a la salida
                        rutFormateado += "-" + dv;

                        //y hago este replace por si el servidor tuviese configuracion anglosajona y reemplazo las comas por puntos
                        rutFormateado = rutFormateado.Replace(",", ".");
                    }
                }
            }

            return rutFormateado;
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
