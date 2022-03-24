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
        static Megoldas m = new Megoldas("retegek_lencsekkel.txt");
        public MainWindow()
        {
            InitializeComponent();
            f4Meresek.Content += m.MeresekSzama.ToString();
            f4Retegek.Content += m.RetegekSzama.ToString();
            for (int i = 1; i <= m.RetegekSzama; i++)
            {
                f5Retegek.Items.Add(i);
            }
            f6ElvekonyodottDb.Content = m.TeljesenElvekonyodottRetegekSzama + "db réteg vékonyodott el teljesen.";
            LehetsegesLencsek();
            ValodiLencsek();
        }

        private void f5Retegek_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            f5Legkisebb.Content = "Legkisebb rétegvastagság: ";
            f5Legnagyobb.Content = "Legnagyobb rétegvastagság: ";
            f5Legnagyobb.Content += m.MaxVastagsag((int)f5Retegek.SelectedItem).ToString() + "m";
            f5Legkisebb.Content += m.MinVastagsag((int)f5Retegek.SelectedItem).ToString() + "m";
        }

        private void chbLegmagasabb_Checked(object sender, RoutedEventArgs e)
        {
            f7Melyseg.Content = "Mélysége a felszíntől: ";
            f7Sorszam.Content = "Mérés sorszáma: ";
            f7Melyseg.Content += m.LegmagasabbAlsoLeghatar.ToString();
            f7Sorszam.Content += m.LegmagasabbAlsoLeghatarSorszama.ToString();
        }

        private void chbLegmélyebb_Checked(object sender, RoutedEventArgs e)
        {
            f7Melyseg.Content = "Mélysége a felszíntől: ";
            f7Sorszam.Content = "Mérés sorszáma: ";
            f7Sorszam.Content += m.LegmelyebbAlsoLeghatarSorszama.ToString();
            f7Melyseg.Content += m.LegmelyebbAlsoLeghatar.ToString();
        }
        private void LehetsegesLencsek()
        {
            for (int i = 1; i <= m.RetegekSzama; i++)
            {
                int top = 315;
                Label l = new Label();
                l.Content = i + ". réteg: " + m.LehetsegesLencsekSzama(i) + "db";
                Canvas.SetLeft(l, 62);
                Canvas.SetTop(l, top + (i * 17));
                main.Children.Add(l);
            }
        }
        private void ValodiLencsek()
        {
            for (int i = 1; i <= m.RetegekSzama; i++)
            {
                int top = 490;
                Label l = new Label();
                l.Content = i + ". réteg: " + m.TenylegesLencsekSzama(i) + "db";
                Canvas.SetLeft(l, 62);
                Canvas.SetTop(l, top + (i * 17));
                main.Children.Add(l);
            }
        }
    }
}
