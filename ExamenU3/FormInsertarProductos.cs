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
    public partial class FormInsertarProductos : Form
    {
        public FormInsertarProductos()
        {
            InitializeComponent();
            button2.Visible = false;
            textBoxID.ReadOnly = true;
        }
        bool estado = false;
        
        public FormInsertarProductos(string id, string nombre, string precio, string categria, string proveedor)
        {

            InitializeComponent();
            estado = true;
            textBoxID.ReadOnly = true;
            button2.Visible = true;
            //button1.Text = "Actualizar";
            textBoxID.Text = id;
            textBoxNombre.Text = nombre;
            textBoxPrecio.Text = precio;
            textBoxCategoria.Text = categria;
            textBoxProveedor.Text = proveedor;
        }
        ClassConexion conexion = new ClassConexion();
        private void FormInsertarProductos_Load(object sender, EventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (estado != true)
            {
                button2.Visible = false;
                try
                {
                    string comando = "INSERT INTO Producto (nombre, precio, id_categoria, id_proveedor) " +
                 "VALUES ('" + textBoxNombre.Text + "', " + textBoxPrecio.Text + ", " +
                 "(SELECT id_categoria FROM Categoria WHERE nombre = '" + textBoxCategoria.Text + "'), " +
                 "(SELECT id_proveedor FROM Proveedor WHERE nombre = '" + textBoxProveedor.Text + "'))";




                    int filas = conexion.comando(comando);
                    MessageBox.Show("Producto insertado correctamente. Se agregaron" + filas + "filas");
                    this.Close();
                }
                catch (Exception EX)
                {
                    MessageBox.Show("Error al insertar producto", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {

                    if (conexion != null && conexion.conectar().State == ConnectionState.Open)
                    {
                        conexion.conectar().Close();
                        Console.WriteLine("Conexión cerrada.");
                    }
                }
            }
            else
            {
                button2.Visible = true;
                try
                {
                    string comando = "UPDATE Producto SET " +
                 "nombre = '" + textBoxNombre.Text + "', " +
                 "precio = " + textBoxPrecio.Text + ", " +
                 "id_categoria = (SELECT id_categoria FROM Categoria WHERE nombre = '" + textBoxCategoria.Text + "'), " +
                 "id_proveedor = (SELECT id_proveedor FROM Proveedor WHERE nombre = '" + textBoxProveedor.Text + "') " +
                 "WHERE id_producto = " + textBoxID.Text;

                    conexion.comando(comando);
                    MessageBox.Show("Producto actualizado correctamente. ");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar producto", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (conexion != null && conexion.conectar().State == ConnectionState.Open)
                    {
                        conexion.conectar().Close();
                        Console.WriteLine("Conexión cerrada.");
                    }

                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM Producto WHERE id_producto = " + textBoxID.Text + " ;";
            try
            {
                
                conexion.comando(query);

                MessageBox.Show("Producto eliminado correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el producto: " + ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conexion != null && conexion.conectar().State == ConnectionState.Open)
                {
                    conexion.conectar().Close();
                    Console.WriteLine("Conexión cerrada.");
                    this.Close();
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
