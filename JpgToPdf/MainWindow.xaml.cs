
using Aspose.Pdf;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;


namespace JpgToPdf
{
    public partial class MainWindow : Window
    {
        private List<string> _imageStorage = new List<string>();
        private string _savePath = null;
        public MainWindow()
        {
            
            InitializeComponent();
            
         }

        private void ConvertButton_Click(object sender, RoutedEventArgs e)
        {
            Document doc = new Document();
            if (_imageStorage.Count > 0)
            {
                foreach (var imagePath in _imageStorage)
                {
                    Aspose.Pdf.Page page = doc.Pages.Add();
                    Aspose.Pdf.Image image = new Aspose.Pdf.Image();
                    image.File = (imagePath);
                    page.Paragraphs.Add(image);
                }

                int a = _imageStorage[0].GetHashCode();
                string path = a.ToString();
                doc.Save("C:\\Users\\Alexey\\Downloads\\" + path + ".pdf");

                textBox1.Text = "Успешно сохранено";

                _imageStorage.Clear();
            }
            else
            {
                textBox1.Text = "Картинки не загружены!";
            }
        }


        private void BtnLoadFromFile_Click(object sender, RoutedEventArgs e)
        {
            textBox1.Text = "";

            OpenFileDialog ofd = new OpenFileDialog 
            {
                Multiselect = true,
            };
            
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";

            ofd.ShowDialog();



            foreach(string file in ofd.FileNames)
            {
                if (_imageStorage.Count <= 4)
                {
                    _imageStorage.Add(file);
                }
                else
                {
                    textBox1.Text = "Aspose.Pdf поддерживает не более 4 картинок за раз";
                }
            }

            
        }

    }
}
