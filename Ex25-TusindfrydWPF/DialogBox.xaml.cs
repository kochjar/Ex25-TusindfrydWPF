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
using System.Windows.Shapes;

namespace Ex25_TusindfrydWPF
{
    /// <summary>
    /// Interaction logic for DialogBox.xaml
    /// </summary>
    public partial class DialogBox : Window
    {
        public DialogBox()
        {
            InitializeComponent();
        }

        private void OK_Click(object sender, RoutedEventArgs e)

        {
            

            tbError.Visibility = Visibility.Hidden;
            this.DialogResult = true; // Closes the dialog box
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void tbPictureLostFocus(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbPicture.Text))
            {
                try { 
                    img.Source = new BitmapImage(new Uri(tbPicture.Text));
                    tbError.Visibility = Visibility.Hidden;
                    OK_btn.IsEnabled = true;
                } 
                catch { 
                    tbError.Text = "Der er sket en fejl med billedestien. Er du sikker på, at stien findes?"; 
                    tbError.Visibility = Visibility.Visible;
                    OK_btn.IsEnabled = false;
                }
                
            }
            
        }

        private void handleButton(object sender, TextChangedEventArgs e)
        {
            if (!int.TryParse(tbProductionTime.Text, out _) ||
                !int.TryParse(tbHalfLifeTime.Text, out _) ||
                !int.TryParse(tbSize.Text, out _)
               )
            {
                tbError.Visibility = Visibility.Visible;
                tbError.Text = "Du skal indtaste et gyldigt tal i produktionstid, halveringstid og størrelse.";
                OK_btn.IsEnabled = false;
                return;
            }

            if (string.IsNullOrEmpty(tbName.Text) ||
                string.IsNullOrEmpty(tbPicture.Text) ||
                string.IsNullOrEmpty(tbProductionTime.Text) ||
                string.IsNullOrEmpty(tbHalfLifeTime.Text) ||
                string.IsNullOrEmpty(tbSize.Text)
                )
            {
                tbError.Visibility = Visibility.Visible;
                tbError.Text = "Alle felter skal være udfyldt.";
                OK_btn.IsEnabled = false;
                return;
            }
            
            tbError.Visibility = Visibility.Hidden;
            OK_btn.IsEnabled = true;
            
        }
    }
}
