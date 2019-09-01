using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Renamer
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

        private void RunBTN_Click(object sender, RoutedEventArgs e)
        {
            //Check static textbox has been populated
            if (!string.IsNullOrWhiteSpace(textBoxStatic.Text))
            {
                //check if count textbox has been populated
                if (!string.IsNullOrWhiteSpace(textBoxCount.Text))
                {
                    try
                    {
                        //File open Dialog box
                        Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
                        dlg.FileName = "Document";
                        Nullable<bool> result = dlg.ShowDialog();
                        //If file selected to modify then continue else cancel dialog.
                        if (result == true)
                        {
                            textRenamer.TextImport(textBoxStatic.Text,
                                textBoxCount.Text, dlg.FileName,
                                checkBox.IsChecked.Value);
                            //Program runs fast, prompt the user that has completed.
                            MessageBox.Show("Finished");
                        }
                    }
                    catch
                    {
                        MessageBox.Show("There was an error, try again.");
                    }
                }
                else
                {
                    MessageBox.Show("Enter count.");
                }
            }
            else
            {
                MessageBox.Show("Enter Facility");
            }
        }

        //number input only into count textbox
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
            
    }
}
