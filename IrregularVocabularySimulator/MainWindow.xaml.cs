using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public List<VokabelModel> Vokabeln { get; set; } = new List<VokabelModel>();

        public void LadeVokabelListe()
        {
            Vokabeln = SqliteDataAccess.LadeVokabeln();

            VerbindeVokabelListe();
        }

        public void VerbindeVokabelListe()
        {
            VokabelListBox.ItemsSource       = null;
            VokabelListBox.ItemsSource       = Vokabeln;
        }

        private void RefreshList(object sender, RoutedEventArgs e)
        {
            LadeVokabelListe();
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
                var ausgewählteVokabeln = VokabelListBox.SelectedItems;

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