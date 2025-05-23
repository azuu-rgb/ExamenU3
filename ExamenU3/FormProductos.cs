using CristalReports;
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
    public partial class FormProductos : Form
    {
        public FormProductos()
        {
            InitializeComponent();
        }
        ClassConexion c = new ClassConexion();
        
        public void actualizarProductos()
        {
            DataSet ds = c.cosulta("SELECT " +
                "p.id_producto AS ID, " +
                "p.nombre AS NOMBRE, " +
                "p.precio AS PRECIO, " +
                "c.nombre AS CATEGORIA, " +
                "pr.nombre AS PROVEEDOR " +
                "FROM Producto p " +
                "JOIN Categoria c ON p.id_categoria = c.id_categoria " +
                "JOIN Proveedor pr ON p.id_proveedor = pr.id_proveedor;");

            if (ds != null)
            {
                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void FormProductos_Activated(object sender, EventArgs e)
        {
            actualizarProductos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormInsertarProductos f = new FormInsertarProductos();
            f.Show();
        }

        private void FormProductos_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FormInsertarProductos formInsertar = new FormInsertarProductos(
     dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(),  // id_producto
     dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(),  // nombre
     dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString(),  // precio
     dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString(),  // id_categoria
     dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString()   // id_proveedor
 );
            formInsertar.Show();


        }
    }
}
