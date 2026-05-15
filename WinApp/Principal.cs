using Composite;
using Services.DomainModel;
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
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        public Usuario usuario = new Usuario();


        private void Principal_Load(object sender, EventArgs e)
        {
            CargarUsuario();

            foreach (ToolStripItem item in menuStrip.Items)
            {
                //Acá tenemos todos los items del menú
                if(usuario.TodasPatentes().Exists(o => o.Nombre == item.Name))
                {
                    item.Visible = true;
                }
                else
                {
                    item.Visible = false;
                }
            }
        }

        private void CargarUsuario()
        {
            Patente pantallaGestionVentas = new Patente();
            pantallaGestionVentas.Nombre = "frmVentas";

            Patente pantallaVisualizacionVentas = new Patente();
            pantallaVisualizacionVentas.Nombre = "frmVisualizacionVentas";

            Patente pantallaPerfil = new Patente();
            pantallaPerfil.Nombre = "frmPerfil";

            Familia familiaVentas = new Familia(pantallaGestionVentas);
            familiaVentas.Nombre = "Familia de ventas";

            Familia administrador = new Familia(familiaVentas);
            administrador.Nombre = "Administrador";

            usuario.Nombre = "jorgito";
            usuario.Privilegios.Add(familiaVentas);
            usuario.Privilegios.Add(pantallaVisualizacionVentas);
            usuario.Privilegios.Add(pantallaGestionVentas); //Pantalla gestión ya está dentro de la familia
            usuario.Privilegios.Add(administrador);
            usuario.Privilegios.Add(pantallaPerfil);
        }
    }
}
