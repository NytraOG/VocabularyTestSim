using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using ClassLib;
using ClassLib.Models;

namespace IrregularVocabularySimulator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public List<VokabelModel> Vokabeln          { get; set; } = new List<VokabelModel>();
        public Dictionary<int, string> ZuPrüfendeVokabeln { get; set; }
        public TestModel          AktuellerTestlauf { get; set; }

        public void LadeVokabelListe()
        {
            Vokabeln = SqliteDataAccess.LadeVokabeln();

            VerbindeVokabelListe();
        }

        public void VerbindeVokabelListe()
        {
            VokabelListGrid.ItemsSource = null;
            VokabelListGrid.ItemsSource = Vokabeln;
        }

        private void RefreshList(object sender, RoutedEventArgs e)
        {
            LadeVokabelListe();
        }

        private void TestStarten(object sender, RoutedEventArgs e)
        {
            AktuellerTestlauf = new TestModel();
            AktuellerTestlauf.TestStarten();

            var rng = new Random();
            Vokabeln = SqliteDataAccess.LadeVokabeln();

            for (int i = 0; i < 5; i++)
            {
                var randomVokabel = Vokabeln[rng.Next(0, Vokabeln.Count)].Infinitiv;

                foreach (var vokabel in ZuPrüfendeVokabeln)
                {
                    if(vokabel.Value == randomVokabel)
                        continue;

                    ZuPrüfendeVokabeln.Add(i, vokabel.Value);
                }

                if (ZuPrüfendeVokabeln.Select(x => x.Value).Where(x => x != null && x.Equals(randomVokabel)) == null)
                {
                    //TODO fixmepls
                }
            }
        }

        private void AntwortAbgeben(object sender, RoutedEventArgs e)
        {
            var antwort = new AntwortenModel
                          {
                              Infinitiv             = VocableDisplay.Text,
                              SimplePastEingabe     = SimplePastEingabe.Text,
                              PastParticipleEingabe = PastParticipleEingabe.Text,
                              ÜbersetzungEingabe    = TranslationEingabe.Text,
                              TestrunOid            = AktuellerTestlauf.Oid
                          };

            SqliteDataAccess.SpeichereAntwort(antwort, AktuellerTestlauf.Oid);
        }

        private void AddVocableToDatabase(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Infinitiv.Text)      || string.IsNullOrWhiteSpace(SimplePast.Text) ||
                    string.IsNullOrWhiteSpace(PastParticiple.Text) || string.IsNullOrWhiteSpace(Translation.Text))
                    throw new Exception("Fields must NOT be empty FOOL!");

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
                MessageBox.Show("An exception just occurred: " + ex.Message, "ERROR", MessageBoxButton.OK,
                                MessageBoxImage.Error);
            }
        }

        private void RemoveVocableFromList(object sender, RoutedEventArgs e)
        {
            try
            {
                var ausgewählteVokabeln = VokabelListGrid.SelectedItems;

                if (ausgewählteVokabeln.Count == 0)
                    throw new Exception("You need to select Data, if you want to delete it LOL scrub");

                var listOfVocabulary = new List<VokabelModel>();

                foreach (VokabelModel vokabel in ausgewählteVokabeln)
                {
                    var retValVokabel = new VokabelModel
                                        {
                                            Infinitiv      = vokabel.Infinitiv,
                                            SimplePast     = vokabel.SimplePast,
                                            PastParticiple = vokabel.PastParticiple,
                                            Translation    = vokabel.Translation
                                        };

                    listOfVocabulary.Add(retValVokabel);
                }

                SqliteDataAccess.LöscheVokabeln(listOfVocabulary);

                RefreshList(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An exception just occurred: " + ex.Message, "ERROR", MessageBoxButton.OK,
                                MessageBoxImage.Error);
            }
        }
    }
}