using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Urhajo_13B_FR
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private List<Urhajo> urhajok = new List<Urhajo>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnBetoltes_Click(object sender, RoutedEventArgs e)
        {
            urhajok = new List<Urhajo>
            {
                new Urhajo { Nev = "Falcon-9", Legenyseg = 7, MaxHatotav = 550000, UzemanyagSzint = 87, Gyarto = "SpaceX", KuldetesStatusz = "Sikeres", InditasEve = 2020 },
                new Urhajo { Nev = "Orion-X1", Legenyseg = 4, MaxHatotav = 820000, UzemanyagSzint = 73, Gyarto = "NASA", KuldetesStatusz = "Folyamatban", InditasEve = 2023 },
                new Urhajo { Nev = "StarRider", Legenyseg = 12, MaxHatotav = 910000, UzemanyagSzint = 66, Gyarto = "Boeing", KuldetesStatusz = "Sikeres", InditasEve = 2019 },
                new Urhajo { Nev = "SolarWind", Legenyseg = 3, MaxHatotav = 300000, UzemanyagSzint = 92, Gyarto = "ESA", KuldetesStatusz = "Sikertelen", InditasEve = 2018 },
                new Urhajo { Nev = "Galaxy-Cruiser", Legenyseg = 18, MaxHatotav = 1200000, UzemanyagSzint = 54, Gyarto = "Blue Origin", KuldetesStatusz = "Sikeres", InditasEve = 2022 },
            };
            DataGrid.ItemsSource = urhajok;
        }

        private void BtnDarab_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Összesen {urhajok.Count} űrhajó van.");
        }

        private void BtnMaxHatotav_Click(object sender, RoutedEventArgs e)
        {
            var max = urhajok.OrderByDescending(u => u.MaxHatotav).FirstOrDefault();
            if (max != null) MessageBox.Show($"Legnagyobb hatótáv: {max.Nev} ({max.MaxHatotav})");
        }

        private void BtnSikeres_Click(object sender, RoutedEventArgs e)
        {
            var sikeresek = urhajok.Where(u => u.KuldetesStatusz == "Sikeres").Select(u => u.Nev);
            MessageBox.Show("Sikeres küldetések:\n" + string.Join(", ", sikeresek));
        }

        private void BtnAtlag_Click(object sender, RoutedEventArgs e)
        {
            if (urhajok.Any()) MessageBox.Show($"Átlagos legénységszám: {urhajok.Average(u => u.Legenyseg):F1}");
        }

        private void BtnCsoportositas_Click(object sender, RoutedEventArgs e)
        {
            var csoportok = urhajok.GroupBy(u => u.Gyarto).Select(g => $"{g.Key}: {g.Count()} db");
            MessageBox.Show(string.Join("\n", csoportok));
        }

        private void BtnKereses_Click(object sender, RoutedEventArgs e)
        {
            var talalat = urhajok.FirstOrDefault(u => u.Nev.ToLower().Contains(Textbox1.Text.ToLower()));
            Textbox2.Text = talalat != null ? $"{talalat.Nev} - {talalat.Gyarto} ({talalat.KuldetesStatusz})" : "Nincs találat";
        }
    }
}