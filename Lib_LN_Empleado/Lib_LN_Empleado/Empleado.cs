using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//usar libreria conexion
using LibConexionBD;
//usar libreria llenar grid
using LibLlenarGrid;
//usaria libreria windowa
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
//usar libreria llenar combos
using LibLlenarCombos;

namespace Lib_LN_Empleado
{
    public class Empleado
    {
        #region Atributos
        private string id_Emp;
        private string nombre;
        private string apellido;
        private string telefono;
        private double salario;
        private string error;
        //reader es el lector de la base de datos
        private SqlDataReader reader;

        public string Id_Emp { get => id_Emp; set => id_Emp = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public double Salario { get => salario; set => salario = value; }
        public string Error { get => error; set => error = value; }
        public SqlDataReader Reader { get => reader; set => reader = value; }
        #endregion
        #region Propiedades

        #endregion
        #region Metodos Publicos
        public bool consultar_Empleados()
        {
            ClsConexion Objc = new ClsConexion();
            string sentencia = "execute USP_consultar_emp '" + id_Emp+"'";
            if(!Objc.Consultar(sentencia, false))
            {
                error = Objc.Error;
                Objc = null;
                return false;
            }
            Reader = Objc.Reader;
            Objc = null;
            return true;
        }
        public bool grabar_Empleado()
        {
            ClsConexion Objc= new ClsConexion();
            string sentencia = "execute USP_insertar_emp '"+id_Emp+"','"+Nombre+"' ,'"+Apellido+"','"+Telefono+"',"+Salario + "'";
            if(!Objc.EjecutarSentencia(sentencia,false))
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
        public bool actualizar_Empleado()
        {
            ClsConexion Objc = new ClsConexion();
            string sentencia = "execute USP_actualizar_emp '" + Nombre + "' ,'" + Apellido + "','" + Telefono + "','" + Salario+ "',"+Id_Emp + "'";
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

        public bool eliminar_Empleado()
        {
            ClsConexion Objc = new ClsConexion();
            string sentencia = "execute USP_eliminar_emp '"+id_Emp+"'";
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
        public bool listar_Empleado(DataGridView objGdV)
        {
            ClsLlenarGrid objLlenarGrid = new ClsLlenarGrid();
            objLlenarGrid.NombreTabla = "Datos Empleado";

            objLlenarGrid.SQL = "execute USP_listar_empleado";

            if (!objLlenarGrid.LlenarGrid(objGdV))
            {
                error= objLlenarGrid.Error;
                objLlenarGrid = null;
                return false;
            }
                objLlenarGrid = null;
                return true;

        }

        public bool llenarComboEmpleado(ComboBox objCb)
        {
            /*objCb y obC es diferente, el primero es un objeto de comboBox y el otro de la clase
            llenar combos*/
            ClsLlenarCombos objC = new ClsLlenarCombos();
            objC.NombreTabla = "DatosEmpleado";
            objC.SQL = "execute USP_ListaComboEmp";
            objC.ColumnaTexto = "nombre completo";
            objC.ColumnaValor = "id_Emp";
            try
            {
            if (!objC.LlenarCombo(objCb))
            {
                error=objC.Error;
                objC=null;
                return false;
            }
            objC = null;
            return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                objC = null;
                return false;
            }
        }
        #endregion
    }
}
