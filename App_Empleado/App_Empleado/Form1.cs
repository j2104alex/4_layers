using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lib_LN_Empleado;

namespace App_Empleado
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listarEmpleado();
            llenarEmp();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            listarEmpleado();
        }

        private void listarEmpleado()
        {
            //Instanciar la logica de negocio
            Empleado objEmpleado = new Empleado();
            //Definir variables
            string idEmpleado, nombre, apellido, telefono;
            double salario;
            if (!objEmpleado.listar_Empleado(dgvEmpleado))
            {
                MessageBox.Show(objEmpleado.Error);
                objEmpleado = null;
                return;
            }
            objEmpleado = null;
            return;
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            listarEmpleado();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                //Instanciar la logica de negocio
                Empleado objEmpleado = new Empleado();
                //Definir variables
                string idEmpleado, nombre, apellido, telefono;
                double salario;
                //Capturar los datos
                idEmpleado = txtIdentificacion.Text;
                //enviar datos a la logica de negocio mediante el get y set
                objEmpleado.Id_Emp = idEmpleado;
                //Llamar el metodo de la libreria
                if (!objEmpleado.eliminar_Empleado())
                {
                    MessageBox.Show(objEmpleado.Error);
                    objEmpleado = null;
                    return;
                }
                else
                {
                    MessageBox.Show(objEmpleado.Error);
                    listarEmpleado();
                    objEmpleado = null;
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
            //Instanciar la logica de negocio
            Empleado objEmpleado = new Empleado();
            //Definir variables
            string idEmpleado, nombre, apellido, telefono;
            double salario;
            //Capturar los datos
            idEmpleado = txtIdentificacion.Text;
            nombre = txtNombre.Text;
            apellido = txtApellido.Text;
            telefono = txtTelefono.Text;
            salario = Convert.ToDouble(txtSalario.Text);
            //enviar datos a la logica de negocio mediante el get y set
            objEmpleado.Id_Emp = idEmpleado;
            objEmpleado.Nombre = nombre;
            objEmpleado.Apellido = apellido;
            objEmpleado.Telefono = telefono;
            objEmpleado.Salario = salario;
            //Llamar el metodo de la libreria
            if (!objEmpleado.grabar_Empleado())
            {
                MessageBox.Show(objEmpleado.Error);
                objEmpleado = null;
                return;
            }
            else
            {
                MessageBox.Show(objEmpleado.Error);
                listarEmpleado();
                objEmpleado = null;
                return;
            }

            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
            //Instanciar la logica de negocio
            Empleado objEmpleado = new Empleado();
            //Definir variables
            string idEmpleado, nombre, apellido, telefono;
            double salario;
            //Capturar los datos
            idEmpleado = txtIdentificacion.Text;
            nombre = txtNombre.Text;
            apellido = txtApellido.Text;
            telefono = txtTelefono.Text;
            salario = Convert.ToDouble(txtSalario.Text);
            //enviar datos a la logica de negocio mediante el get y set
            objEmpleado.Id_Emp = idEmpleado;
            objEmpleado.Nombre = nombre;
            objEmpleado.Apellido = apellido;
            objEmpleado.Telefono = telefono;
            objEmpleado.Salario = salario;
            //Llamar el metodo de la libreria
            if (!objEmpleado.actualizar_Empleado())
            {
                MessageBox.Show(objEmpleado.Error);
                objEmpleado = null;
                return;
            }
            else
            {
                MessageBox.Show(objEmpleado.Error);
                listarEmpleado();
                objEmpleado = null;
                return;
            }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnConsultar1_Click(object sender, EventArgs e)
        {
            Empleado objEmpleado = new Empleado();
            try
            {
            String idEmpleado = txtIdentificacion.Text;
                objEmpleado.Id_Emp = idEmpleado;
                if (!objEmpleado.consultar_Empleados())
                {
                    MessageBox.Show(objEmpleado.Error);
                    objEmpleado = null;
                    return;
                }
                SqlDataReader reader; 
                reader = objEmpleado.Reader;
                if (reader.HasRows)
                {
                reader.Read();
                    txtIdentificacion.Text = reader.GetString(0);
                    txtNombre.Text = reader.GetString(1);
                    txtApellido.Text = reader.GetString(2);
                    txtTelefono.Text = reader.GetString(3);
                    txtSalario.Text =Convert.ToString(reader.GetDouble(4));
                    reader.Close();
                    objEmpleado = null;
                    return;
                }
                else
                {
                    MessageBox.Show("El usuario no existe");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                objEmpleado = null;
            }
        }
        private void llenarEmp()
        {
            Empleado obEm=new Empleado();
            if (!obEm.llenarComboEmpleado(comboxEmp))
            {
                MessageBox.Show(obEm.Error);
                obEm = null;
                return;
            }
        }
    }
}
