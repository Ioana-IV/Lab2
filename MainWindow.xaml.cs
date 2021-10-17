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

namespace Ivanov_Ioana_Lab2
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

        private void btnRemoveItem_Click(object sender, RoutedEventArgs e)
        {

        }
        private DoughnutMachine myDoughnutMachine;
        private void frmMain_Loaded(object sender, RoutedEventArgs e)
        {
            myDoughnutMachine = new DoughnutMachine();
            myDoughnutMachine.DoughnutComplete += new DoughnutMachine.DoughnutCompleteDelegate(DoughnutCompleteHandler);
        }

        private int mRaisedGlazed;
        private int mRaisedSugar;
        private int mFilledLemon;
        private int mFilledChocolate;
        private int mFilledVanilla;

        private void exitToolsStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void makeMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void raisedMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void filledMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void stopToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            myDoughnutMachine.Enabled = false;
            glazedToolStripMenuItem.IsChecked = false;
            sugarToolStripMenuItem.IsChecked = false;
            lemonToolStripMenuItem.IsChecked = false;
            chocolateToolStripMenuItem.IsChecked = false;
            vanillaToolStripMenuItem.IsChecked = false;
        }

        private void vanillaToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            glazedToolStripMenuItem.IsChecked = false;
            sugarToolStripMenuItem.IsChecked = false;
            lemonToolStripMenuItem.IsChecked = false;
            chocolateToolStripMenuItem.IsChecked = false;
            vanillaToolStripMenuItem.IsChecked = true;
            myDoughnutMachine.MakeDoughnuts(DoughnutType.Vanilla);
        }

        private void chocolateToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            glazedToolStripMenuItem.IsChecked = false;
            sugarToolStripMenuItem.IsChecked = false;
            lemonToolStripMenuItem.IsChecked = false;
            chocolateToolStripMenuItem.IsChecked = true;
            vanillaToolStripMenuItem.IsChecked = false;
            myDoughnutMachine.MakeDoughnuts(DoughnutType.Chocolate);
        }

        private void lemonToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            glazedToolStripMenuItem.IsChecked = false;
            sugarToolStripMenuItem.IsChecked = false;
            lemonToolStripMenuItem.IsChecked = true;
            chocolateToolStripMenuItem.IsChecked = false;
            vanillaToolStripMenuItem.IsChecked = false;
            myDoughnutMachine.MakeDoughnuts(DoughnutType.Lemon);
        }

        private void filledToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void sugarToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            glazedToolStripMenuItem.IsChecked = false;
            sugarToolStripMenuItem.IsChecked = true;
            lemonToolStripMenuItem.IsChecked = false;
            chocolateToolStripMenuItem.IsChecked = false;
            vanillaToolStripMenuItem.IsChecked = false;
            myDoughnutMachine.MakeDoughnuts(DoughnutType.Sugar);
        }

        private void glazedToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            glazedToolStripMenuItem.IsChecked = true;
            sugarToolStripMenuItem.IsChecked = false;
            lemonToolStripMenuItem.IsChecked = false;
            chocolateToolStripMenuItem.IsChecked = false;
            vanillaToolStripMenuItem.IsChecked = false;
            myDoughnutMachine.MakeDoughnuts(DoughnutType.Glazed);
        }

        private void raisedToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void makeToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void doughnutsToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void fileToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DoughnutCompleteHandler()
        {
            switch(myDoughnutMachine.Flavor)
            {
                case DoughnutType.Glazed:
                    mRaisedGlazed++;
                    txtGlazedRaised.Text = mRaisedGlazed.ToString();
                    break;
                case DoughnutType.Sugar:
                    mRaisedSugar++;
                    txtSugarRaised.Text = mRaisedSugar.ToString();
                    break;

                case DoughnutType.Lemon:
                    mFilledLemon++;
                    txtLemonFilled.Text = mFilledLemon.ToString();
                    break;

                case DoughnutType.Chocolate:
                    mFilledChocolate++;
                    txtChocolateFilled.Text = mFilledChocolate.ToString();
                    break;

                case DoughnutType.Vanilla:
                    mFilledVanilla++;
                    txtVanillaFilled.Text = mFilledVanilla.ToString();
                    break;
            }
        }

        private void txtQuantity_KeyPress(object sender, KeyEventArgs e)
        {
            if(!((e.Key>=Key.D0 && e.Key<=Key.D9)||(e.Key==Key.Back)||(e.Key==Key.Delete)))    // am adaugat si tastele Backspace / Delete ca fiind allowed, altfel primesti eroare cand vrei sa stergi 0 ca sa pui alte valori
            {
                MessageBox.Show("Numai cifre se pot introduce !", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
