using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExploradorWeb
{
    public partial class EliminarHistorial : Form
    {
        public EliminarHistorial()
        {
            InitializeComponent();
        }

        private void EliminarHistorial_Load(object sender, EventArgs e)
        {
            leerUrl("historial.txt");
        }

        private void leerUrl(String fileNombre)
        {
            FileStream stream = new FileStream(fileNombre, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
            {
                richTextBox1.AppendText(reader.ReadLine());
                richTextBox1.AppendText("\n");
            }
            reader.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string texto = richTextBox1.Text;
            guardarUrl("historial.txt", texto);
        }

        private void guardarUrl(String fileNombre, string texto)
        {
            FileStream stream = new FileStream(fileNombre, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            writer.WriteLine(texto);
            writer.Close();
        }
    }
}
