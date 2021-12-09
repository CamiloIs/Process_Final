using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using CapaSoporte.cache;
using System.Data;

namespace CapaAcessoDatos
{
    public class mantenedores : conexionMySQL
    {

        //USUARIOS
        public void insertarUsuario()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("insertarUsuario", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add("@idUsuario", MySqlDbType.Int32).Value = Usuario.idUsuario;
                    command.Parameters.Add("@rut", MySqlDbType.VarChar).Value = Usuario.rut;
                    command.Parameters.Add("@nombre", MySqlDbType.VarChar).Value = Usuario.nombre;
                    command.Parameters.Add("@apellidos", MySqlDbType.VarChar).Value = Usuario.apellidos;
                    command.Parameters.Add("@correo", MySqlDbType.VarChar).Value = Usuario.correo;
                    command.Parameters.Add("@telefono", MySqlDbType.Int32).Value = Usuario.telefono;
                    command.Parameters.Add("region", MySqlDbType.VarChar).Value = Usuario.region;
                    command.Parameters.Add("@comuna", MySqlDbType.VarChar).Value = Usuario.comuna;
                    command.Parameters.Add("@usuario", MySqlDbType.VarChar).Value = Usuario.usuario;
                    command.Parameters.Add("@cargo", MySqlDbType.VarChar).Value = Usuario.cargo;
                    command.ExecuteNonQuery();

                }
            }
        }


        public int rutUsuario()
        {
            using (var connection = GetConnection())
            {
                int id ;
                connection.Open();
                MySqlDataAdapter da = new MySqlDataAdapter("select max(idusuario) from usuario ", connection);
                DataSet ds = new DataSet();             
                id = da.Fill(ds);
                return id;
               
                

            }



        }


      
        public void insertarCuenta()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("insertarCuenta", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    
                    command.Parameters.Add("@idcuenta", MySqlDbType.Int32).Value = cuenta.idCuenta;
                    command.Parameters.Add("@usuario", MySqlDbType.VarChar).Value = cuenta.usuario;
                    command.Parameters.Add("@password", MySqlDbType.VarChar).Value = cuenta.password;
                    command.Parameters.Add("@rol", MySqlDbType.VarChar).Value = cuenta.rol;
                    command.ExecuteNonQuery();

                }
            }
        }

        public void eliminarUsuario(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("eliminarUsuario", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("@idusuario", MySqlDbType.Int32).Value = Usuario.idUsuario;
                    command.ExecuteNonQuery();

                }
            }
        }


        public void eliminarCuenta(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("eliminarCuenta", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("@idusuario", MySqlDbType.Int32).Value = Usuario.idUsuario;
                    command.ExecuteNonQuery();

                }
            }
        }

        public DataSet listarUsuarios()
        {

            using (var connection = GetConnection())
            {
                connection.Open();
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT u.rut, u.nombre,u.apellidos, u.correo, u.telefono, c.usuario, c.rol " +
                                                           "FROM usuario u JOIN cuenta c ON u.idusuario = c.idcuenta; ", connection);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;

                
            }
        }


        

        public void actualizarUsuario(string rut)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("actualizarUsuario", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("@idusuario", MySqlDbType.VarChar).Value = Usuario.idUsuario;
                    command.Parameters.Add("@rut", MySqlDbType.VarChar).Value = Usuario.rut;
                    command.Parameters.Add("@nombre", MySqlDbType.VarChar).Value = Usuario.nombre;
                    command.Parameters.Add("@apellidos", MySqlDbType.VarChar).Value = Usuario.apellidos;
                    command.Parameters.Add("@correo", MySqlDbType.VarChar).Value = Usuario.correo;
                    command.Parameters.Add("@telefono", MySqlDbType.Int32).Value = Usuario.telefono;
                    command.Parameters.Add("@region", MySqlDbType.VarChar).Value = Usuario.region;
                    command.Parameters.Add("@comuna", MySqlDbType.VarChar).Value = Usuario.comuna;
                    command.Parameters.Add("@usuario", MySqlDbType.VarChar).Value = Usuario.usuario;
                    command.Parameters.Add("@cargo", MySqlDbType.VarChar).Value = Usuario.cargo;
                    command.ExecuteNonQuery();

                }
            }
        }


        public void actualizarCuenta(string user)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("actualizarCuenta", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    //command.Parameters.Add("@idusuario", MySqlDbType.Int32).Value = Usuario.idUsuario;
                    command.Parameters.Add("@idcuenta", MySqlDbType.Int32).Value = cuenta.idCuenta;
                    command.Parameters.Add("@usuario", MySqlDbType.VarChar).Value = cuenta.usuario;
                    command.Parameters.Add("@password", MySqlDbType.VarChar).Value = cuenta.password;
                    command.Parameters.Add("@rol", MySqlDbType.VarChar).Value = cuenta.rol;
                    command.ExecuteNonQuery();

                }
            }
        }









        /// <summary>
        /// /////////
        /// 
        /// 
        /// 
        /// </summary>

        //PROYECTOS



        public void insertarProyecto()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("insertarProyecto", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add("@idProyecto", MySqlDbType.Int32).Value = Proyecto.idProyecto;
                    command.Parameters.Add("@nombreProyecto", MySqlDbType.VarChar).Value = Proyecto.nombreProyecto;
                    command.Parameters.Add("@inicioProyecto", MySqlDbType.Date).Value = Proyecto.inicio;
                    command.Parameters.Add("@terminoProyecto", MySqlDbType.Date).Value = Proyecto.termino;
                    command.Parameters.Add("@descripcionProyecto", MySqlDbType.VarChar).Value = Proyecto.descripcion;
                    command.Parameters.Add("@responsableProyecto", MySqlDbType.VarChar).Value = Proyecto.responsable;
                    command.Parameters.Add("empresa", MySqlDbType.VarChar).Value = Proyecto.empresa;
                    command.Parameters.Add("@unidad", MySqlDbType.VarChar).Value = Proyecto.unidad;
                    command.Parameters.Add("@creadorProyecto", MySqlDbType.VarChar).Value = Proyecto.creador;
                    command.ExecuteNonQuery();

                }
            }
        }



        public void eliminarProyecto(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("eliminarProyecto", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("@idProyecto", MySqlDbType.Int32).Value = Proyecto.idProyecto;
                    command.ExecuteNonQuery();

                }
            }
        }


        


        public DataSet listarProyecto()
        {

            using (var connection = GetConnection())
            {
                connection.Open();
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT u.rut, u.nombre,u.apellidos, u.correo, u.telefono, c.usuario, c.rol " +
                                                           "FROM usuario u JOIN cuenta c ON u.idusuario = c.idcuenta; ", connection);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;


            }
        }




        public void ActualizarProyecto(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("ActualizarProyecto", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("@idProyecto", MySqlDbType.Int32).Value = Proyecto.idProyecto;
                    command.Parameters.Add("@nombreProyecto", MySqlDbType.VarChar).Value = Proyecto.nombreProyecto;
                    command.Parameters.Add("@inicioProyecto", MySqlDbType.Date).Value = Proyecto.inicio;
                    command.Parameters.Add("@terminoProyecto", MySqlDbType.Date).Value = Proyecto.termino;
                    command.Parameters.Add("@descripcionProyecto", MySqlDbType.VarChar).Value = Proyecto.descripcion;
                    command.Parameters.Add("@responsableProyecto", MySqlDbType.VarChar).Value = Proyecto.responsable;
                    command.Parameters.Add("@empresa", MySqlDbType.VarChar).Value = Proyecto.empresa;
                    command.Parameters.Add("@unidad", MySqlDbType.VarChar).Value = Proyecto.unidad;
                    command.Parameters.Add("@creadorProyecto", MySqlDbType.VarChar).Value = Proyecto.creador;
                    
                    command.ExecuteNonQuery();

                }
            }
        }


        



        //UNIDADES

        public void ingresarUnidad()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("insertarUnidad", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add("@idUnidad", MySqlDbType.Int32).Value = unidadInterna.idUnidad;
                    command.Parameters.Add("@nombreUnidad", MySqlDbType.VarChar).Value = unidadInterna.nombreUnidad;
                    command.Parameters.Add("@nombreproyecto", MySqlDbType.VarChar).Value = unidadInterna.nombreProyecto;
                    command.ExecuteNonQuery();

                }
            }
        }

        public void eliminarUnidad(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("eliminarUnidad", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("@idUnidad", MySqlDbType.Int32).Value = unidadInterna.idUnidad;
                    command.ExecuteNonQuery();

                }
            }
        }


        public DataSet listarUnidades()
        {

            using (var connection = GetConnection())
            {
                connection.Open();
                //using (var command = new MySqlCommand("LISTAR_USUARIOS", connection))
                // {
                //   command.CommandType = System.Data.CommandType.StoredProcedure;               
                //  command.ExecuteNonQuery();
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM unidadInterna;", connection);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;

                //}
            }
        }

        public void actualizarUnidad(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("actualizarUnidad", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;


                    command.Parameters.Add("@idUnidad", MySqlDbType.Int32).Value = unidadInterna.idUnidad;
                    command.Parameters.Add("@nombreUnidad", MySqlDbType.VarChar).Value = unidadInterna.nombreUnidad;
                    command.Parameters.Add("@nombreproyecto", MySqlDbType.VarChar).Value = unidadInterna.nombreProyecto;
                    //command.Parameters.Add("@fechaCre", MySqlDbType.VarChar).Value = unidadInterna.fechaCre;
                    //command.Parameters.Add("@ultimaMod", MySqlDbType.VarChar).Value = unidadInterna.ultimaMod;
                    //command.Parameters.Add("@numTareas", MySqlDbType.VarChar).Value = unidadInterna.numTareas;
                    //command.Parameters.Add("@userCreador", MySqlDbType.VarChar).Value = unidadInterna.userCreador;
                    //command.Parameters.Add("@area", MySqlDbType.VarChar).Value = unidadInterna.area;
                    command.ExecuteNonQuery();

                }
            }
        }
    }
}
