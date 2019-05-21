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
using ClassLib;

namespace IrregularVocabularySimulator
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

        private void AddVocableToDatabase(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Infinitiv.Text) || string.IsNullOrWhiteSpace(SimplePast.Text) || string.IsNullOrWhiteSpace(PastParticiple.Text) || string.IsNullOrWhiteSpace(Translation.Text))
                    throw new Exception("Fields must NOT be empty!");

                var vokabel = new VokabelModel
                              {
                                  Infinitiv      = Infinitiv.Text,
                                  SimplePast     = SimplePast.Text,
                                  PastParticiple = PastParticiple.Text,
                                  Translation    = Translation.Text
                              };

                SqliteDataAccess.SpeichereVokabel(vokabel);

                Infinitiv.Text      = string.Empty;
                SimplePast.Text     = string.Empty;
                PastParticiple.Text = string.Empty;
                Translation.Text    = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An exception just occurred: " + ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
