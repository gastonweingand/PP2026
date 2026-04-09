using DomainModel;
using Logic;
using Services.Facade;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinApp
{
    public partial class Clientes : Form
    {
        private ClienteService clientes = new ClienteService();
        public Clientes()
        {
            InitializeComponent();
        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            RefrescarGrilla();

            foreach (string idioma in IdiomaService.ObtenerIdiomas())
            {
                MessageBox.Show(idioma);
            }

            string traduccion = IdiomaService.Traducir("es-AR", "Hola");
            traduccion = IdiomaService.Traducir("en-US", "Hola");
            traduccion = IdiomaService.Traducir("fr-FR", "Holas");
        }

        private void RefrescarGrilla()
        {
            dgvClientes.DataSource = null;
            dgvClientes.DataSource = clientes.ObtenerTodos();
        }

        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente cliente = new Cliente();
                cliente.Codigo = 10;
                cliente.CUIT = "260000";
                cliente.FechaNacimiento = DateTime.Now.AddYears(-15);
                cliente.Nombre = "Fulano";

                clientes.Agregar(cliente); 
            }
            catch(ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTraerTodos_Click(object sender, EventArgs e)
        {
            RefrescarGrilla();
        }
    }
}
