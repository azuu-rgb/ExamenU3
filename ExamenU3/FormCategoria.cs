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
    public partial class FormCategoria : Form
    {
        public FormCategoria()
        {
            InitializeComponent();
        }
        ClassConexion c = new ClassConexion();
        public void actualizarCategorias()
        {
            DataSet ds = c.cosulta("SELECT " +
                "id_categoria AS ID, " +
                "nombre AS NOMBRE, " +
                "descripcion AS DESCRIPCION " +
                "FROM Categoria;");

            if (ds != null)
            {
                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void FormCategoria_Activated(object sender, EventArgs e)
        {
            actualizarCategorias();
        }
    }
}
