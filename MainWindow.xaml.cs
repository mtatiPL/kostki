using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Gra_w_kosci_tutorial
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Dice> results { get; set; }
        public ObservableCollection<Score> scores { get; set; }
        public int NumberOfDice { get; set;}
        public int NumberOfTries { get; set;}
        public MainWindow()
        {
            InitializeComponent();
            NumberOfDice = 5;
            results = new ObservableCollection<Dice>();
            scores = new ObservableCollection<Score>();
            DataContext = this;
            preparegame();

        }

        private void preparegame()
        {
            scores.Add(new Score("jedynki"));
            scores.Add(new Score("dwojki"));
            scores.Add(new Score("trojki"));
            scores.Add(new Score("czworki"));
            scores.Add(new Score("piatki"));
            scores.Add(new Score("szóstki"));
            scores.Add(new Score("trzy"));
            scores.Add(new Score("cztery"));
            scores.Add(new Score("full"));
            scores.Add(new Score("mały strit"));
            scores.Add(new Score("duzy strit"));
            scores.Add(new Score("generał"));
            scores.Add(new Score("szansa"));
            NumberOfTries = 3;


        }

        private void rollbtn_Click(object sender, RoutedEventArgs e)
        {
           if (NumberOfTries > 0)
            {
                var random = new Random();
                foreach (var item in results)
                {
                    if (!item.IsSelected)
                        item.Value = random.Next(1,7);
                }
                NumberOfTries--;
                showpoints();
            }
           else
                rollbtn.IsEnabled = false;
           
        }

        private void showpoints()
        {  if (scores[0].IsSet == false)
                scores[0].Points = suma(results, 1);
            if (scores[1].IsSet == false)
                scores[1].Points = suma(results, 2);
            if (scores[2].IsSet == false)
                scores[2].Points = suma(results, 3);
            if (scores[3].IsSet == false)
                scores[3].Points = suma(results, 4);
            if (scores[4].IsSet == false)
                scores[4].Points = suma(results, 5);
            if (scores[5].IsSet == false)
                scores[5].Points = suma(results, 6);

            scores[12].Points = sumaall(results);
        }

        private int sumaall(ObservableCollection<Dice> tablica)
        {
            int s = 0;
            foreach (Dice d in tablica)
                s = s + d.Value;
            return s;

        }

        private int suma(ObservableCollection<Dice> tablica, int nr)
        {
            int s = 0;
            foreach (Dice d in tablica)
                if (d.Value == nr)
                     s = s + d.Value;
            return s;

        }

        private void Button_Dice_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;  
            var dice = button.DataContext as Dice;
            dice.IsSelected = !dice.IsSelected;            
        }

        private void zatwierdzbtn_Click(object sender, RoutedEventArgs e)
        {
            NumberOfTries = 3;
            rollbtn.IsEnabled = true;
            results.Clear();
            for (int i = 0; i < NumberOfDice; i++)
            {
                results.Add(new Dice());
            }
        }

        private void startbtn_Click(object sender, RoutedEventArgs e)
        {
            results.Clear();
            for (int i = 0; i < NumberOfDice; i++)
            {
                results.Add(new Dice());
            }

        }
    }
}

