using System;
using System.Collections.Generic;
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

namespace Ex25_TusindfrydWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<FlowerSort> flowerSorts;
        public MainWindow()
        {
            InitializeComponent();
            flowerSorts = new List<FlowerSort>();
        }

        private void Opret_Click(object sender, RoutedEventArgs e)
        {
            DialogBox dialogBox = new DialogBox();
            
            if (dialogBox.ShowDialog() == true)
            {
                FlowerSort flowerSort = new FlowerSort(
                    dialogBox.tbName.Text,
                    dialogBox.tbPicture.Text,
                    Convert.ToInt32(dialogBox.tbProductionTime.Text),
                    Convert.ToInt32(dialogBox.tbHalfLifeTime.Text),
                    Convert.ToInt32(dialogBox.tbSize.Text)
                );
                flowerSorts.Add(flowerSort);
            }
            UpdateTextBlock();
        }

        private void UpdateTextBlock()
        {
            string lines = "";
            foreach (FlowerSort flowerSort in flowerSorts)
            {
                lines += $"{flowerSort.Name}, {flowerSort.HalfLifeTime}, {flowerSort.ProductionTime}, {flowerSort.Size}, {flowerSort.PicturePath}\n";
            }
            tbFlowers.Text = lines;
        }
    }
}
