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

            // creare obiect binding pentru comanda
            CommandBinding cmd1 = new CommandBinding();

            // asociere comanda
            cmd1.Command = ApplicationCommands.Print;

            //input gesture Alt + I
            ApplicationCommands.Print.InputGestures.Add(new KeyGesture(Key.I, ModifierKeys.Alt));

            // asociem un handler
            cmd1.Executed += new ExecutedRoutedEventHandler(CtrlP_CommandHandler);

            //adaugam la colectia CommandBindings
            this.CommandBindings.Add(cmd1);

            // Doughnuts > Stop
            // comanda custom

            CommandBinding cmd2 = new CommandBinding();
            cmd2.Command = CustomCommands.StopCommand.Launch;
            cmd2.Executed += new ExecutedRoutedEventHandler(CtrlS_CommandHandler); // asociem handler
            this.CommandBindings.Add(cmd2);

        }

        private void CtrlS_CommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            // handler pentru comanda Ctrl+S -> se va executa stopToolStripMenuItem_Click
            MessageBox.Show("Ctrl+S was pressed! The doughnut machine will stop!");
            this.stopToolStripMenuItem_Click(sender, e);

        }


        private DoughnutMachine myDoughnutMachine;
        private void frmMain_Loaded(object sender, RoutedEventArgs e)
        {
            myDoughnutMachine = new DoughnutMachine();
            myDoughnutMachine.DoughnutComplete += new DoughnutMachine.DoughnutCompleteDelegate(DoughnutCompleteHandler);

            cmbType.ItemsSource = Pricelist;
            cmbType.DisplayMemberPath = "Key";
            cmbType.SelectedValuePath = "Value";
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
            this.Title = "Virtual Doughnuts Factory";
            e.Handled = true;
            // reseteaza tick-urile 
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
            switch (myDoughnutMachine.Flavor)
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
            if (!((e.Key >= Key.D0 && e.Key <= Key.D9) || (e.Key == Key.Back) || (e.Key == Key.Delete)))    // am adaugat si tastele Backspace / Delete ca fiind allowed, altfel primesti eroare cand vrei sa stergi 0 ca sa pui alte valori
            {
                MessageBox.Show("Numai cifre se pot introduce !", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void filledToolStripMenuItems_Click(object sender, RoutedEventArgs e)
        {
            string DoughnutFlavour;

            MenuItem SelectedItem = (MenuItem)e.OriginalSource;
            DoughnutFlavour = SelectedItem.Header.ToString();

            Enum.TryParse(DoughnutFlavour, out DoughnutType myFlavour);
            myDoughnutMachine.MakeDoughnuts(myFlavour);
        }

        private void FilledItemsShow_Click(object sender, RoutedEventArgs e)
        {
            string mesaj;

            MenuItem SelectedItem = (MenuItem)e.OriginalSource;

            // reseteaza toate tickurile care existau anterior in meniu
            glazedToolStripMenuItem.IsChecked = false;
            sugarToolStripMenuItem.IsChecked = false;
            lemonToolStripMenuItem.IsChecked = false;
            chocolateToolStripMenuItem.IsChecked = false;
            vanillaToolStripMenuItem.IsChecked = false;
            // seteaza tick-ul doar pe meniul care a fost selectat
            SelectedItem.IsChecked = true;

            //seteaza mesajul in bara de titlu a ferestrei, in loc de "Virtual Doughnuts Factory"
            mesaj = SelectedItem.Header.ToString() + " doughnuts are being cooked! ";
            this.Title = mesaj;
        }

        KeyValuePair<DoughnutType, double>[] Pricelist =
        {
            new KeyValuePair<DoughnutType, double>(DoughnutType.Glazed, 3),
            new KeyValuePair<DoughnutType, double>(DoughnutType.Sugar, 2.5),
            new KeyValuePair<DoughnutType, double>(DoughnutType.Lemon, 3.5),
            new KeyValuePair<DoughnutType, double>(DoughnutType.Chocolate, 4.5),
            new KeyValuePair<DoughnutType, double>(DoughnutType.Vanilla, 4)
        };

        DoughnutType selectedDoughnut;

        private void cmbType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtPrice.Text = cmbType.SelectedValue.ToString();
            KeyValuePair<DoughnutType, double> selectedEntry = (KeyValuePair<DoughnutType, double>)cmbType.SelectedItem;
            selectedDoughnut = selectedEntry.Key;
        }

        int basketGlazed=0;
        int basketSugar=0;
        int basketLemon=0;
        int basketVanilla=0;
        int basketChocolate=0;

        private int ValidateQuantity(DoughnutType selectedDoughnut)
        {
            int q = int.Parse(txtQuantity.Text);
            int r = 1;
            
            switch(selectedDoughnut)
            {
                case DoughnutType.Glazed:
                    if (q > mRaisedGlazed-basketGlazed)                 // verific daca cantitatea pe care vreau sa o adaug in cos (q) este mai mare decat numarul de produse care le mai am disponibile care nu sunt deja in cos
                        r = 0;                                          // daca cantitatea e mai mare inseamna ca nu mai am destule produse disponibile, si nu pot sa adaug mai multe in cos
                    else
                        basketGlazed += q;                             // daca cantitatea este mai mica, atunci incrementez cantitatea produselor de acel tip din cos
                    break;
                case DoughnutType.Sugar:
                    if (q > mRaisedSugar-basketSugar)
                        r = 0;
                    else
                        basketSugar += q;
                    break;
                case DoughnutType.Lemon:
                    if (q > mFilledLemon-basketLemon)
                        r = 0;
                    else
                        basketLemon += q;
                    break;
                case DoughnutType.Vanilla:
                    if (q > mFilledVanilla-basketVanilla)
                        r = 0;
                    else
                        basketVanilla += q;
                    break;
                case DoughnutType.Chocolate:
                    if (q > mFilledChocolate-basketChocolate)
                        r = 0;
                    else
                        basketChocolate += q;
                    break;
            }
            return r;
        }

        private void btnAddToSale_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateQuantity(selectedDoughnut) > 0)
            {
                // am formatat un pic altfel mesajul, ca sa se inteleaga mai bine ce reprezinta valorile
                // am updatat peste tot pe unde se folosesc datele din string sa se potriveasca noului format

                lstSale.Items.Add(selectedDoughnut.ToString() + ": $" + txtPrice.Text + " x "+ txtQuantity.Text + " ---> Total: $" + double.Parse(txtQuantity.Text)*double.Parse(txtPrice.Text)+". ");

                // de fiecare data cand adaug un produs in cos, il voi adauga de asemenea la totalul cosului
                txtTotal.Text = (double.Parse(txtTotal.Text) + double.Parse(txtQuantity.Text) * double.Parse(txtPrice.Text)).ToString();
            } 
            else
            {
                //acest mesaj se va afisa in doua cazuri
                // nu am nici un produs in cos, dar cantitatea pe care doresc sa o adaug e mai mare decat ce am eu disponibil
                // am x produse in cos, dar cantitate toala - x < cantitatea pe care doresc eu sa o adaug in plus in cos

                MessageBox.Show("Cantitatea introdusa nu este disponibila in stoc !");
            }
        }

        private void btnRemoveItem_Click(object sender, RoutedEventArgs e)
        {
            //verific daca am element selectat
            if(lstSale.SelectedIndex>-1)
            { 
                string s = lstSale.SelectedItem.ToString();

                //aflu cantitatea produselor care urmeaza sa fie sterse
                int quantity = Int32.Parse(s.Substring(s.IndexOf(" x ") + 3, s.IndexOf(" --->") - (s.IndexOf(" x ") + 3)));

                // aflu pretul total al produselor care urmeaza sa fie sters
                string totalPrice = s.Substring(s.IndexOf("l: $") + 4, s.IndexOf(". ")-(s.IndexOf("l: $") + 4));

                // din total voi scadea pretul produselor care sunt sters
                txtTotal.Text = (double.Parse(txtTotal.Text) - double.Parse(totalPrice)).ToString();

                // din evidenta cantitatii din cos voi scadea cantitatea produselor care se sterg din cos
                switch (s.Substring(0, s.IndexOf(":")))
                {
                    case "Glazed":
                        basketGlazed -= quantity;
                        break;
                    case "Sugar":
                        basketSugar -= quantity;
                        break;
                    case "Lemon":
                        basketLemon -= quantity;
                        break;
                    case "Chocolate":
                        basketChocolate -= quantity;
                        break;
                    case "Vanilla":
                        basketVanilla -= quantity;
                        break;
                }
                // exista un bug la remove-ul acesta. Daca ai mai multe randuri in list box, si le stergi de jos in sus, de multe ori ultimul rand ramane highlightat gri, iar daca il selectezi si dai Remove, nu se va sterge.
                // nu inteleg exact cum se poate rezolva problema, de obicei daca adaugi mai multe randuri in list box si dai clickuri, se reseteaza highlight-ul acela si poti sa stergi entry-ul
                lstSale.Items.Remove(lstSale.SelectedItem);

            }
        }

        private void btnCheckOut_Click(object sender, RoutedEventArgs e)
        {

            MessageBox.Show("Thank you for your purchase!");
            // scad din totalul gogosilor produse gogosile care au fost cumparate la Checkout
            mRaisedGlazed -= basketGlazed;
            txtGlazedRaised.Text = mRaisedGlazed.ToString();
            mRaisedSugar -= basketSugar;
            txtSugarRaised.Text = mRaisedSugar.ToString();
            mFilledLemon -= basketLemon;
            txtLemonFilled.Text = mFilledLemon.ToString();
            mFilledVanilla -= basketVanilla;
            txtVanillaFilled.Text = mFilledVanilla.ToString();
            mFilledChocolate -= basketChocolate;
            txtChocolateFilled.Text = mFilledChocolate.ToString();

            // resetez valoarea cosului
            txtTotal.Text = "0";

            // resetez lista din cos
            lstSale.Items.Clear();

            // resetez valoarea produselor din cos
            basketGlazed = 0;
            basketSugar = 0;
            basketLemon = 0;
            basketVanilla = 0;
            basketChocolate = 0;



        }


        private void CtrlP_CommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("You have in stock: " + mRaisedGlazed + " Glazed, " + mRaisedSugar + " Sugar, " + mFilledLemon + " Lemon, " +mFilledChocolate + " Chocolate"+mFilledVanilla + " Vanilla" );
            this.Title = "Virtual Doughnuts Factory";
            e.Handled = true;
            // reseteaza tick-ul
            inventoryToolStripMenuItem.IsChecked = false;

        }


    }
}
