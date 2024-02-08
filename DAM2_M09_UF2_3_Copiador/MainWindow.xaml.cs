using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DAM2_M09_UF2_3_Copiador
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnOrigen_Click(object sender, RoutedEventArgs e)
        {
            // var ofd = OpenFolderDialog(); .net 8

            var ofd = new FolderBrowserDialog(); // doble click en el projecto y ponemos a true el useWindowsForms
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.tbOrigen.Text = ofd.SelectedPath; // para seleccionar un directorio
            }
        }

        private void btnDesti_Click(object sender, RoutedEventArgs e)
        {
            var ofd = new FolderBrowserDialog(); // doble click en el projecto y ponemos a true el useWindowsForms
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.tbDesti.Text = ofd.SelectedPath; // para seleccionar un directorio 
            }
        }

        private void btnCopia_Click(object sender, RoutedEventArgs e) // copia async
        {
            // ejecutra cmd o poweshell

            var pathOrigen = this.tbOrigen.Text;
            var pathDesti = this.tbDesti.Text;

            if (!(Directory.Exists(pathOrigen) && Directory.Exists(pathDesti)))
            {
                throw new Exception("no existen los directorios, wey");
            }

            Process p = new Process();
            p.StartInfo.FileName = "powershell";
            p.StartInfo.Arguments = $" -command xcopy {pathOrigen} {pathDesti} /s /y"; // modo sobreescribir 
            p.StartInfo.UseShellExecute = false;
            p.Start();
            p.WaitForExit(60000);

            if (p.HasExited)
            {
                if (p.ExitCode != 0) lbStatus.Content = "Copia incorrecta";
                else lbStatus.Content = "Copia correcta";
            }
            else lbStatus.Content = "Has tardado mas de 1 min en copiar";
        }

        private void btnEvents_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAsincrona_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCopiar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
