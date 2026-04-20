using DomainModel;
using Logic;
using Services.Facade;
using Services.Facade.Extentions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
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

            List<string> idiomasDisponibles = new List<string>();

            foreach (CultureInfo idioma in IdiomaService.ObtenerIdiomas())
            {
                idiomasDisponibles.Add(idioma.DisplayName);
            }

            cmbIdiomas.DataSource = idiomasDisponibles;

            //Qué les queda? Armar un diccionario donde la key sea el Name del idioma 
            // y el value sea el display name, para luego setear el idioma seleccionado como el actual del hilo y que se traduzca toda la app a ese idioma

            // Obtener los idiomas disponibles, iría en un combobox o algo similar
            // Recordar que la selección debe quedar seteado como idioma por defecto del usuario
            foreach (CultureInfo idioma in IdiomaService.ObtenerIdiomas())
            {
                MessageBox.Show(idioma.DisplayName);
            }

            System.Globalization.CultureInfo culture = Thread.CurrentThread.CurrentCulture;

            MessageBox.Show($"El idioma actual es: {culture.DisplayName}");

            string traduccion = "Hola".Traducir();
            traduccion = "Holas".Traducir();

            btnAgregarCliente.Text = "Agregar Cliente".Traducir();
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
                cliente.IdCliente = Guid.NewGuid();
                cliente.CUIT = "27000";
                cliente.FechaNacimiento = DateTime.Now.AddYears(-15);
                cliente.Nombre = "Fulano";

                clientes.Agregar(cliente);

                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                string traduccion = "Hola".Traducir();
                MessageBox.Show($"El idioma actual es: {Thread.CurrentThread.CurrentCulture.DisplayName}");
                MessageBox.Show(traduccion);

                btnAgregarCliente.Text = "Agregar Cliente".Traducir();
            }
            catch (ArgumentException ex)
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
