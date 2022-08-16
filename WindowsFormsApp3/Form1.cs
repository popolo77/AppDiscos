using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {

        private  List<Disco>listaDiscos ;
        public Form1()
        {
            InitializeComponent();
        }

        //EN EL EVENTO DEL LOAD() VOY A INVOCAR EL MI METODO Listar()
        private void Form1_Load(object sender, EventArgs e)
        {
            DiscoNegocio negocio = new DiscoNegocio();
            List<Disco> listaDiscos = negocio.Listar();
            dgv.DataSource = listaDiscos;//dgv (DataGridView) recibe Datos, El objeto tipo DiscoNegocio negocio ya instanciado le aplico el metodo listar(que conecta a sql) y se lo asigno a dvg para mostrar la Base de datos
            pictureBoxDiscos.Load(listaDiscos[0].UrlImagenTapa);
            dgv.Columns[2].Visible = false;
        
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            Disco seleccionado = (Disco)dgv.CurrentRow.DataBoundItem;
            pictureBoxDiscos.Load(seleccionado.UrlImagenTapa);
        }
    }
}
