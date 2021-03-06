﻿using System;
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
using System.IO;
using Microsoft.Win32;
using System.Text.RegularExpressions;

namespace Daniel_Kasprow_lista_4
{
    /// <summary>
    /// Interaction logic for AddPacjent.xaml
    /// </summary>
    public partial class AddPacjent : Window
    {
        Pacjent kln;

        MainWindow mainwindow;

        private string picture;
       // Uri uri;
        public AddPacjent()
        {
            InitializeComponent();
            //TextPesel.MaxLength = 11;
        }

        public AddPacjent(MainWindow mainwindow) : this()
        {
            this.mainwindow = mainwindow;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                {
                    openFileDialog.Title = "Select picture of patient";
                    openFileDialog.Filter = "Image files(*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
                    openFileDialog.InitialDirectory = Environment.CurrentDirectory;
                    openFileDialog.Multiselect = false;
                }
                if (openFileDialog.ShowDialog() == true)
                {
                    picture = openFileDialog.FileName;
                }
                if (TextPesel.Text.Length == 11)
                {
                    kln = new Pacjent(TextImie.Text, TextNazwisko.Text,TextUlica.Text,TextUlica.Text,TextKraj.Text,Convert.ToInt32(TextNr.Text),Convert.ToInt32(TextWiek.Text), Convert.ToInt64(TextPesel.Text),picture);
                    MainWindow.klient.Add(kln);
                    this.Hide();
                }
                else MessageBox.Show("zla dlugosc pesela");
            }
            catch
            {
                MessageBox.Show("nr ulicy,wiek i pesel musi byc liczba");
            }
        }
        public void refresh()
        {
            TextImie.Text = "";
            TextNazwisko.Text = "";
            TextUlica.Text = "";
            TextNr.Text = "";
            TextMiasto.Text = "";
            TextNazwisko.Text = "";
            TextKraj.Text = "";
            TextWiek.Text = "";
            TextPesel.Text = "";
        }
        private void TextIntinput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }
        private void TextStringinput(object sender,TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^A-z]+").IsMatch(e.Text);
        }
    }
 }

