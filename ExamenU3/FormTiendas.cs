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
    public partial class FormTiendas : Form
    {
        ClassConexion c = new ClassConexion();
        public FormTiendas()
        {
            InitializeComponent();
        }
        public void actualizarTiendas()
        {
            DataSet ds = c.cosulta("SELECT " +
                "id_tienda AS ID, " +
                "nombre AS NOMBRE, " +
                "direccion AS DIRECCION, " +
                "ciudad AS CIUDAD " +
                "FROM Tienda;");

            if (ds != null)
            {
                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void FormTiendas_Activated(object sender, EventArgs e)
        {
            actualizarTiendas();
        }
    }
}
