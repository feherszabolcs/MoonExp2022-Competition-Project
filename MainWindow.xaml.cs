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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace MoonExp2022
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            Megoldas m = new Megoldas("retegek_lencsekkel.txt");
            f4Meresek.Content += m.MeresekSzama.ToString();
            f4Retegek.Content += m.RetegekSzama.ToString();
            teszt.Content = m.TenylegesLencsekSzama(2);
        }
    }
}
