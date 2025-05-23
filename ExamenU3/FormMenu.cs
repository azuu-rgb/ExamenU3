using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamenU3
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTiendas f = new FormTiendas();
            f.Show();
        }

        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
        }

        private void categoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCategoria f = new FormCategoria();
            f.Show();
        }

        private void productosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormProductos f = new FormProductos();
            f.Show();
        }

        private void prodcutosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void productosToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FormReporteProducto f = new FormReporteProducto();
            f.Show();
        }
    }
}
