using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lib_LN_Cliente;
using System.Windows.Forms;

namespace App_Cliente
{
    public partial class Form1 : Form
    {
        

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                //Instanciar la logica de negocio
                Cliente objCliente = new Cliente();
                //Definir variables
                string idCliente, nombre, apellido, telefono, direccion, email;
                //Capturar los datos
                idCliente = txtIdentificacion.Text;
                //enviar datos a la logica de negocio mediante el get y set
                objCliente.Id_Cliente = idCliente;
                //Llamar el metodo de la libreria
                if (!objCliente.eliminar_Cliente())
                {
                    MessageBox.Show(objCliente.Error);
                    objCliente = null;
                    return;
                }
                else
                {
                    MessageBox.Show(objCliente.Error);
                    objCliente = null;
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                //Instanciar la logica de negocio
                Cliente objCliente = new Cliente();
                //Definir variables
                string idCliente, nombre, apellido, telefono, direccion, email;
                //Capturar los datos
                idCliente = txtIdentificacion.Text;
                nombre = txtNombre.Text;
                apellido = txtApellido.Text;
                telefono = txtTelefono.Text;
                direccion = txtDireccion.Text;
                email = txtEmail.Text;
                //enviar datos a la logica de negocio mediante el get y set
                objCliente.Id_Cliente = idCliente;
                objCliente.Nombre = nombre;
                objCliente.Apellido = apellido;
                objCliente.Telefono = telefono;
                objCliente.Direccion = direccion;
                objCliente.Email= email;
                //Llamar el metodo de la libreria
                if (!objCliente.actualizar_Cliente())
                {
                    MessageBox.Show(objCliente.Error);
                    objCliente = null;
                    return;
                }
                else
                {
                    MessageBox.Show(objCliente.Error);
                    objCliente = null;
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public Form1()
        {
            InitializeComponent();
        }



        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                //Instanciar la logica de negocio
                Cliente objCliente = new Cliente();
                //Definir variables
                string idCliente, nombre, apellido, telefono, direccion, email;
                // Capturar los datos
                idCliente = txtIdentificacion.Text;
                nombre = txtNombre.Text;
                apellido = txtApellido.Text;
                telefono = txtTelefono.Text;
                direccion = txtDireccion.Text;
                email = txtEmail.Text;
                //enviar datos a la logica de negocio mediante el get y set
                objCliente.Id_Cliente = idCliente;
                objCliente.Nombre = nombre;
                objCliente.Apellido = apellido;
                objCliente.Telefono = telefono;
                objCliente.Direccion = direccion;
                objCliente.Email = email;
                //Llamar el metodo de la libreria
                if (!objCliente.grabar_Cliente())
                {
                    MessageBox.Show(objCliente.Error);
                    objCliente = null;
                    return;
                }
                else
                {
                    MessageBox.Show(objCliente.Error);
                    objCliente = null;
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}