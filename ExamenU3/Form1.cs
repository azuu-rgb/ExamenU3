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
    public partial class Form1 : Form
    {
        ClassConexion c = new ClassConexion();  
        public Form1()
        {
            InitializeComponent();
        }
        public void actualizar()
        {
            DataSet ds = c.cosulta("SELECT \r\n " +
                "   e.id_empleado AS ID,\r\n   " +
                " e.nombre AS NOMBRE,\r\n  " +
                "  e.puesto AS PUESTO,\r\n  " +
                "  e.salario AS SALARIO,\r\n " +
                "   t.nombre AS TIENDA\r\n" +
                "FROM Empleado e\r\n" +
                "JOIN Tienda t ON e.id_tienda = t.id_tienda;");
            if (ds != null)
            {
                dataGridView1.DataSource = ds.Tables[0];
            }
        }
        private void Form1_Activated(object sender, EventArgs e)
        {
            actualizar();
        }
    }
}
