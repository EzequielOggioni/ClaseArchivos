using System.IO;
using Clase19;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Chat
{
    public partial class frmChat : Form
    {

        List<Mensaje> mensajes;
        public frmChat()
        {
            InitializeComponent();            
            mensajes = new List<Mensaje>();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            Mensaje mensaje = new Mensaje();
            mensaje.Texto = this.txtMensaje.Text;
            mensaje.Usuario = this.txtUsuario.Text;
            mensaje.Hora = DateTime.Now;
            try
            {
                mensaje.Serializar();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
            this.limpiar();
            this.cargar();
        }

        void limpiar()
        {
            this.txtMensaje.Text = "";
            this.txtUsuario.Text = "";
        }
        void cargar()
        {

            try
            {
                mensajes = Mensaje.Deserializar();
                this.lstMensajes.DataSource = null;
                this.lstMensajes.DataSource = mensajes;
                StreamWriter sw = new StreamWriter("archivo.log");
                sw.WriteLine(DateTime.Now.ToString("yyyMMddhhmmssttt") + ":  Se actualizaron los mensajes");
                sw.Close();
            }
            catch(Exception e)
            { MessageBox.Show (e.Message); }

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.cargar();
        }
    }
}
