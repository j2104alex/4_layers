using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibConexionBD;
using LibLlenarGrid;
using System.Windows.Forms;

namespace Lib_LN_Cliente
{
    public class Cliente
    {
        #region Atributos
        private string id_Cliente;
        private string nombre;
        private string apellido;
        private string telefono;
        private string direccion;
        private string email;
        private string error;

        public string Id_Cliente { get => id_Cliente; set => id_Cliente = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Email { get => email; set => email = value; }
        public string Error { get => error; set => error = value; }

        #endregion

        #region Metodos Publicos
        public bool grabar_Cliente()
        {
            ClsConexion Objc = new ClsConexion();
            string sentencia = "execute USP_insertar_cliente '" + Id_Cliente + "','" + Nombre + "','" + Apellido + "','" + Telefono + "','" + Direccion + "','" + Email+ "'";
            if (!Objc.EjecutarSentencia(sentencia, false))
            {
                Error = Objc.Error;
                //destruir para un objeto para vaciar el objeto
                Objc = null;
                return false;
            }
            Error = "Se guardo exitosamente";
            Objc = null;
            return true;
        }
        public bool actualizar_Cliente()
        {
            ClsConexion Objc = new ClsConexion();
            string sentencia = "execute USP_actualizar_Cliente '" + Nombre + "','" + Apellido + "','" + Telefono + "','" + Direccion + "','" + Email + "','" + Id_Cliente+ "'";
            if (!Objc.EjecutarSentencia(sentencia, false))
            {
                Error = Objc.Error;
                //destruir para un objeto para vaciar el objeto
                Objc = null;
                return false;
            }
            Error = "Se actualizó exitosamente";
            Objc = null;
            return true;
        }

        public bool eliminar_Cliente()
        {
            ClsConexion Objc = new ClsConexion();
            string sentencia = "execute USP_eliminar_cliente '" + id_Cliente+ "'";
            if (!Objc.EjecutarSentencia(sentencia, false))
            {
                Error = Objc.Error;
                //destruir para un objeto para vaciar el objeto
                Objc = null;
                return false;
            }
            Error = "Se eliminó exitosamente";
            Objc = null;
            return true;
        }
        public bool listar_Cliente(DataGridView objGdV)
        {
            ClsLlenarGrid objLlenarGrid = new ClsLlenarGrid();
            objLlenarGrid.NombreTabla = "Datos Cliente";

            objLlenarGrid.SQL = "execute USP_listar_clientes";

            if (!objLlenarGrid.LlenarGrid(objGdV))
            {
                error = objLlenarGrid.Error;
                objLlenarGrid = null;
                return false;
            }
            objLlenarGrid = null;
            return true;

        }
        #endregion
    }
}