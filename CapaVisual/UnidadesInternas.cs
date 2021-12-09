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

namespace CapaVisual
{
    public partial class UnidadesInternas : Form
    {
        public UnidadesInternas()
        {
            InitializeComponent();
            MostrarTabla();
            combopro();
        }

        private bool Editar = false;
        private Int32 id = 0;

        MySqlConnection conectar = new MySqlConnection("Server=localhost; Database=process; User=root; port=3306; password=Root; SSL Mode=0;");
        DataSet ds;

        DataSet resultado = new DataSet();
        DataView miFiltro;

        private void MostrarTabla()
        {
            conectar.Open();
            MySqlCommand comm = new MySqlCommand("SELECT * FROM unidadtrabajo ", conectar);

            MySqlDataAdapter con = new MySqlDataAdapter(comm);
            ds = new DataSet();
            con.Fill(ds);
            dtUnidad.DataSource = ds.Tables[0];
            conectar.Close();

            
        }

        private void combopro()
        {
            
                conectar.Open();
                MySqlCommand comm = new MySqlCommand("SELECT idProyecto, nombreProyecto FROM proyecto", conectar);
                MySqlDataAdapter con = new MySqlDataAdapter(comm);
                ds = new DataSet();
                con.Fill(ds);
                cbxPro.ValueMember = "idProyecto";
                cbxPro.DisplayMember = "nombreProyecto";
                cbxPro.DataSource = ds.Tables[0];
                conectar.Close();


            
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (Editar == false)
            {
                try
                {                   
                    if (txtnom.Text == String.Empty)
                    {
                        MessageBox.Show("Ingrese un Nombre", "Mensaje de Sistema");
                    }
                    else
                    {
                        modeloUnidad man = new modeloUnidad();

                        unidadInterna.nombreUnidad = this.txtnom.Text;
                        unidadInterna.nombreProyecto = cbxPro.Text;


                        man.insertUnidad();
                        MostrarTabla();
                        Limpiar();
                        MessageBox.Show("Unidad Creada Exitosamente");

                    }                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unidad no Creada" + ex.Message, "Mensaje de Sistema");
                }
            }
        }

        private void Limpiar()
        {
            txtId.Clear();
            txtnom.Clear();
           
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (Editar == true)
            {
                try
                {
                    if (txtnom.Text == String.Empty)
                    {
                        MessageBox.Show("Ingrese un Nombre", "Mensaje de Sistema");
                    }
                    else
                    {
                        modeloUnidad man = new modeloUnidad();
                        unidadInterna.idUnidad = Convert.ToInt32(this.txtId.Text);
                        unidadInterna.nombreUnidad = this.txtnom.Text;
                        unidadInterna.nombreProyecto = this.cbxPro.Text;


                        man.updateUnidad(unidadInterna.idUnidad);
                        MostrarTabla();
                        Limpiar();
                        MessageBox.Show("Unidad Actualizada Exitosamente");

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unidad no Actualizada" + ex.Message, "Mensaje de Sistema");
                }
            }           
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtUnidad.SelectedRows.Count == 1)
                {
                    modeloUnidad man = new modeloUnidad();
                    unidadInterna.idUnidad = Convert.ToInt32(dtUnidad.CurrentRow.Cells["idUnidad"].Value);
                    man.eliminarUnidad(unidadInterna.idUnidad);
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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dtUnidad.SelectedRows.Count == 1)
            {
                Editar = true;
                txtId.Text = dtUnidad.CurrentRow.Cells["idUnidad"].Value.ToString();
                txtnom.Text = dtUnidad.CurrentRow.Cells["nombreUnidad"].Value.ToString();
                
                

            }
            else
            {
                MessageBox.Show("Seleccione una fila por favor", "Mensaje de Sistema");
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

        private void UnidadesInternas_Load(object sender, EventArgs e)
        {
            this.leerDatos("SELECT * FROM unidadtrabajo", ref resultado, "nombreUnidad");
            this.miFiltro = ((DataTable)resultado.Tables["nombreUnidad"]).DefaultView;
            this.dtUnidad.DataSource = miFiltro;
        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            string salidaDatos = string.Empty;
            string[] palabras_busqueda = this.txtBuscar.Text.Split(' ');

            foreach (string palabra in palabras_busqueda)
            {
                if (salidaDatos.Length == 0)
                {
                    salidaDatos = "(nombreUnidad LIKE '%" + palabra + "%' OR nombreproyecto LIKE '%" + palabra + "%')";
                }
                else
                {
                    salidaDatos += " AND (nombreUnidad LIKE '%" + palabra + "%' OR nombreproyecto LIKE '%" + palabra + "%')";
                }
            }

            this.miFiltro.RowFilter = salidaDatos;
        }
    }
}
