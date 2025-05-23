using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace CristalReports
{

    internal class ClassConexion
    {
        String cadenaConexion = "Data Source = VWNC71429;" + "integrated security=true; initial catalog=TiendasDB; encrypt=false";
        SqlConnection conexion;
        public SqlConnection conectar()
        {
            try
            {
                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();
                return conexion;

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error al Conectar la Base de Datos" + ex.Message);
                return null;
            }

        }
        public DataSet cosulta(string consulta)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(consulta, conectar());
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error al realizar la consulta" + ex.Message);
                return null;
            }
        }
        public int comando(string comando)
        {
            try
            {
                SqlCommand comadno = new SqlCommand(comando, conectar());
               int filas = comadno.ExecuteNonQuery();
               return filas;


            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error al ejecutar el comando" + ex.Message);
                return -1;
            }
        }
    }
}
