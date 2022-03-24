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
using System.IO;

namespace MoonExp2022
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static Megoldas m = new Megoldas("minta.txt");
        public MainWindow()
        {
            InitializeComponent();
            f4Meresek.Content += m.MeresekSzama.ToString();
            f4Retegek.Content += m.RetegekSzama.ToString();
            for (int i = 1; i <= m.RetegekSzama; i++)
            {
                f5Retegek.Items.Add(i);
            }
            teszt.Content = m.TenylegesLencsekSzama(5);
        }

        private void f5Retegek_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            f5Legkisebb.Content += m.MaxVastagsag((int)f5Retegek.SelectedItem).ToString();
            f5Legnagyobb.Content += m.MinVastagsag((int)f5Retegek.SelectedItem).ToString();
        }
    }
}
