using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaAcessoDatos;

namespace CapaNegocio
{
    public class modeloProyecto
    {
        public void insertProyecto()
        {
            mantenedores man = new mantenedores();
            man.insertarProyecto();
        }

        public void eliminarProyecto(int id)
        {
            mantenedores man = new mantenedores();
            man.eliminarProyecto(id);
        }

        public void updatePro(int id)
        {
            mantenedores man = new mantenedores();
            man.ActualizarProyecto(id);
        }
    }
}
