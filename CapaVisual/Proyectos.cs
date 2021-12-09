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
using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;

namespace CapaVisual
{
    public partial class Proyectos : Form
    {
        public Proyectos()
        {
            InitializeComponent();
            MostrarTabla();
            combopro();           
        }

        modeloProyecto man = new modeloProyecto();
        private bool Editar = false;
        private int id;
        

        MySqlConnection conectar = new MySqlConnection("Server=localhost; Database=process; User=root; port=3306; password=Root; SSL Mode=0;");
        DataSet ds;

        DataSet resultado = new DataSet();
        DataView miFiltro;

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (Editar == false)
            {
                try
                {
                    if (txtNombre.Text == String.Empty)
                    {
                        MessageBox.Show("Ingrese un Nombre", "Mensaje de Sistema");
                    }
                    else
                    {
                        if (txtDes.Text == String.Empty)
                        {
                            MessageBox.Show("Ingrese una breve Descripción", "Mensaje de Sistema");
                        }
                        else
                        {
                            
                                if (txtEmp.Text == String.Empty)
                                {
                                    MessageBox.Show("Ingrese una Empresa", "Mensaje de Sistema");
                                }
                                else
                                {
                                    if (txtUni.Text == String.Empty)
                                    {
                                        MessageBox.Show("Ingrese una Unidad Inical", "Mensaje de Sistema");
                                    }
                                    else
                                    {
                                        if (txtCre.Text == String.Empty)
                                        {
                                            MessageBox.Show("Ingrese el Nombre del Creador del Proyecto", "Mensaje de Sistema");
                                        }
                                        else
                                        {                                            
                                            modeloProyecto man = new modeloProyecto();

                                            Proyecto.nombreProyecto = this.txtNombre.Text;
                                            Proyecto.inicio = this.dtin.Value;
                                            Proyecto.termino = this.dtter.Value;
                                            Proyecto.descripcion = this.txtDes.Text;
                                            Proyecto.responsable = this.cbxRe.Text;
                                            Proyecto.empresa = this.txtEmp.Text;
                                            Proyecto.unidad = this.txtUni.Text;
                                            Proyecto.creador = this.txtCre.Text;
                                            man.insertProyecto();

                                            MostrarTabla();
                                            Limpiar();
                                            MessageBox.Show("Proyecto Creado Exitosamente");
                                                                                                                                                                                                                                                                                                                              
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

        private void MostrarTabla()
        {
            
            conectar.Open();
            MySqlCommand comm = new MySqlCommand("SELECT * FROM proyecto;", conectar);

            MySqlDataAdapter con = new MySqlDataAdapter(comm);
            ds = new DataSet();
            con.Fill(ds);
            dtProyecto.DataSource = ds.Tables[0];
            conectar.Close();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtProyecto.SelectedRows.Count == 1)
                {
                    modeloProyecto man = new modeloProyecto();
                    Proyecto.idProyecto = Convert.ToInt32(dtProyecto.CurrentRow.Cells["idProyecto"].Value.ToString());
                    man.eliminarProyecto(Proyecto.idProyecto);
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

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (Editar == true)
            {
                try
                {
                    if (txtNombre.Text == String.Empty)
                    {
                        MessageBox.Show("Ingrese un Nombre", "Mensaje de Sistema");
                    }
                    else
                    {
                        if (txtDes.Text == String.Empty)
                        {
                            MessageBox.Show("Ingrese una breve Descripción", "Mensaje de Sistema");
                        }
                        else
                        {
                            
                                if (txtEmp.Text == String.Empty)
                                {
                                    MessageBox.Show("Ingrese una Empresa", "Mensaje de Sistema");
                                }
                                else
                                {
                                    if (txtUni.Text == String.Empty)
                                    {
                                        MessageBox.Show("Ingrese una Unidad Inical", "Mensaje de Sistema");
                                    }
                                    else
                                    {
                                        if (txtCre.Text == String.Empty)
                                        {
                                            MessageBox.Show("Ingrese el Nombre del Creador del Proyecto", "Mensaje de Sistema");
                                        }
                                        else
                                        {
                                            modeloProyecto pro = new modeloProyecto();

                                            Proyecto.idProyecto = Convert.ToInt32(this.txtid.Text);
                                            Proyecto.nombreProyecto = this.txtNombre.Text;
                                            Proyecto.inicio = this.dtin.Value;
                                            Proyecto.termino = this.dtter.Value;
                                            Proyecto.descripcion = this.txtDes.Text;
                                            Proyecto.responsable = this.cbxRe.Text;
                                            Proyecto.empresa = this.txtEmp.Text;
                                            Proyecto.unidad = this.txtUni.Text;
                                            Proyecto.creador = this.txtCre.Text;
                                            pro.updatePro(Proyecto.idProyecto);


                                            MostrarTabla();
                                            Limpiar();
                                            MessageBox.Show("Proyecto Actualizado Exitosamente");

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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dtProyecto.SelectedRows.Count == 1)
            {
                Editar = true;
                txtid.Text = dtProyecto.CurrentRow.Cells["idProyecto"].Value.ToString();
                txtNombre.Text = dtProyecto.CurrentRow.Cells["nombreProyecto"].Value.ToString();
                dtin.Value = Convert.ToDateTime(dtProyecto.CurrentRow.Cells["inicioProyecto"].Value);
                dtter.Value = Convert.ToDateTime(dtProyecto.CurrentRow.Cells["terminoProyecto"].Value);
                txtDes.Text = dtProyecto.CurrentRow.Cells["descripcionProyecto"].Value.ToString();
                txtEmp.Text = dtProyecto.CurrentRow.Cells["empresa"].Value.ToString();
                txtUni.Text = dtProyecto.CurrentRow.Cells["unidad"].Value.ToString();
                txtCre.Text = dtProyecto.CurrentRow.Cells["creadorProyecto"].Value.ToString();

            }
            else
            {
                MessageBox.Show("Seleccione una fila por favor", "Mensaje de Sistema");
            }
        }


        private void Limpiar()
        {
            txtid.Clear();
            txtNombre.Clear();
            txtDes.Clear();
            txtEmp.Clear();
            txtUni.Clear();
            txtCre.Clear();
        
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            string salidaDatos = string.Empty;
            string[] palabras_busqueda = this.txtBuscar.Text.Split(' ');

            foreach (string palabra in palabras_busqueda)
            {
                if (salidaDatos.Length == 0)
                {
                    salidaDatos = "(nombreproyecto LIKE '%" + palabra + "%' OR descripcionProyecto LIKE '%" + palabra + "%' OR responsableProyecto LIKE '%" + palabra
                                + "%' OR unidad LIKE '%" + palabra + "%' OR empresa LIKE '%" + palabra + "%' OR creadorProyecto LIKE '%" + palabra + "%')";
                }
                else
                {
                    salidaDatos += " AND (nombreProyecto LIKE '%" + palabra + "%' OR descripcionProyecto LIKE '%" + palabra + "%' OR responsableProyecto LIKE '%" + palabra
                                + "%' OR unidad LIKE '%" + palabra + "%' OR empresa LIKE '%" + palabra + "%' OR creadorProyecto LIKE '%" + palabra + "%')";
                }
            }

            this.miFiltro.RowFilter = salidaDatos;
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

        private void Proyectos_Load(object sender, EventArgs e)
        {
            this.leerDatos("SELECT * FROM proyecto; ", ref resultado, "proyecto");
            this.miFiltro = ((DataTable)resultado.Tables["proyecto"]).DefaultView;
            this.dtProyecto.DataSource = miFiltro;
        }


        private void combopro()
        {

            conectar.Open();
            MySqlCommand comm = new MySqlCommand("SELECT idusuario, CONCAT_WS(' ', nombre, apellidos) AS nombre FROM usuario", conectar);
            MySqlDataAdapter con = new MySqlDataAdapter(comm);
            ds = new DataSet();
            con.Fill(ds);
            cbxRe.ValueMember = "idusuario";
            cbxRe.DisplayMember = "nombre";
            cbxRe.DataSource = ds.Tables[0];
            conectar.Close();



        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            reporte();
        }

        public void reporte()
        {
            if (Editar == true)
            {
                /// Crear el String de conexion
                MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
                builder.Server = "localhost";
                builder.UserID = "root";
                builder.Password = "Root";
                builder.Database = "process";

                /// Abrir la conexion y ejecutar la consulta SQL
                MySqlConnection con = new MySqlConnection(builder.ToString());
                con.Open();
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "select * from proyecto where idProyecto = @idProyecto";
                cmd.Parameters.Add(new MySqlParameter("@idProyecto", Convert.ToInt32(txtid.Text)));
                MySqlDataReader reader = cmd.ExecuteReader();

                ///////////////////////////////////

                Document doc = new Document();
                PdfWriter.GetInstance(doc, new FileStream("reporteProyecto.pdf", FileMode.Create)); // asignamos el nombre de archivo hola.pdf
                doc.Open();
                Paragraph title = new Paragraph();
                title.Font = FontFactory.GetFont(FontFactory.TIMES, 28f, BaseColor.BLUE);
                title.Add("Reporte Proyecto");
                doc.Add(title);
                // Agregamos un parrafo vacio como separacion.
                doc.Add(new Paragraph(" "));
                doc.Add(new Paragraph(" "));
                doc.Add(new Paragraph(" "));

                // Empezamos a crear la tabla, definimos una tabla de 6 columnas
                PdfPTable table = new PdfPTable(9);
                // Esta es la primera fila
                table.AddCell("idProyecto");
                table.AddCell("nombreProyecto");
                table.AddCell("inicioProyecto");
                table.AddCell("terminoProyecto");
                table.AddCell("descripcionProyecto");
                table.AddCell("responsableProyecto");
                table.AddCell("empresa");
                table.AddCell("unidad");
                table.AddCell("creadorProyecto");
                while (reader.Read())
                {
                    // Filas N depende de la base de datos
                    table.AddCell(reader.GetString("idProyecto"));
                    table.AddCell(reader.GetString("nombreProyecto"));
                    table.AddCell(reader.GetString("inicioProyecto"));
                    table.AddCell(reader.GetString("terminoProyecto"));
                    table.AddCell(reader.GetString("descripcionProyecto"));
                    table.AddCell(reader.GetString("responsableProyecto"));
                    table.AddCell(reader.GetString("empresa"));
                    table.AddCell(reader.GetString("unidad"));
                    table.AddCell(reader.GetString("creadorProyecto"));

                }
                // Agregamos la tabla al documento
                doc.Add(table);
                // Ceramos el documento
                doc.Close();
                ///////////////////////////////////
                con.Close();

                MessageBox.Show("Reporte Generado");
            }
            else
            {
                MessageBox.Show("Seleccione un Proyecto");
            }

        }
    }
}
