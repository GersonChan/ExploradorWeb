using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ExploradorWeb
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<URL> urls = new List<URL>();

        private void haciaAtrasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void buttonIr_Click(object sender, EventArgs e)
        {
            string buscarTexto = comboBox1.Text;
            int pocicion = urls.FindIndex(b => b.Url == buscarTexto);
            URL buscar = new URL();
            buscar.Url = comboBox1.Text;
            webBrowser1.Navigate(new Uri(buscar.pagina()));

            if (pocicion == -1)
            {
                buscar.fechaVisitada = DateTime.Now;
                urls.Add(buscar);
                guardarUrl("historial.txt");
            }
            else
            {
                urls[pocicion].contador++;
                guardarUrl("historial.txt");
            }
            comboBox1.DataSource = null;
            comboBox1.Items.Clear();
            leerUrl("historial.txt");

        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.GoHome();
        }

        private void haciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            webBrowser1.GoHome();
            leerUrl("historial.txt");
        }

        private void guardarUrl(String fileNombre) 
        {
            FileStream stream = new FileStream(fileNombre, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            foreach (var url in urls)
            {
                writer.WriteLine(url.Url);
            }
            writer.Close();
        }

        private void leerUrl(String fileNombre) 
        {
            FileStream stream = new FileStream(fileNombre, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
            {
                comboBox1.Items.Add(reader.ReadLine());
            }
            reader.Close();
        }

        private void másVisitadasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            urls = urls.OrderByDescending(c => c.contador).ToList();
            guardarUrl("historial.txt");
            comboBox1.DataSource = null;
            comboBox1.Items.Clear();
            leerUrl("historial.txt");
        }

        private void másRecientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            urls = urls.OrderByDescending(f => f.fechaVisitada).ToList();
            guardarUrl("historial.txt");
            comboBox1.DataSource = null;
            comboBox1.Items.Clear();
            leerUrl("historial.txt");
        }

        private void eliminarPáginaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EliminarHistorial eliminar = new EliminarHistorial();
            eliminar.Show();
        }
    }
}
