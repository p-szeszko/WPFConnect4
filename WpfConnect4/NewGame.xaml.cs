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

namespace WpfConnect4
{
    /// <summary>
    /// Logika interakcji dla klasy NewGame.xaml
    /// </summary>
    public partial class NewGame : UserControl
    {
        public NewGame()
        {
            InitializeComponent();
            cbg1.SelectedIndex = 0;
            cbg2.SelectedIndex = 1;
            cbalg1.SelectedIndex=0;
            cbalg2.SelectedIndex = 0;
            cbheur1.SelectedIndex = 0;
            cbheur2.SelectedIndex = 0;
            if(cbg1.SelectedIndex==0)
            {
                alg1.Visibility = Visibility.Hidden;
                cbalg1.Visibility = Visibility.Hidden;
                cbheur1.Visibility = Visibility.Hidden;
                heur1.Visibility = Visibility.Hidden;
            }

            if (cbg2.SelectedIndex==0)
            {
                alg1.Visibility = Visibility.Hidden;
                cbalg1.Visibility = Visibility.Hidden;
                cbheur1.Visibility = Visibility.Hidden;
                heur1.Visibility = Visibility.Hidden;
            }
            

        }

        public void  cbg1DropDown(object sender, EventArgs e)
        {
            if (cbg1.SelectedIndex==0)
            {
                alg1.Visibility = Visibility.Hidden;
                cbalg1.Visibility = Visibility.Hidden;
                cbheur1.Visibility = Visibility.Hidden;
                heur1.Visibility = Visibility.Hidden;
            }
            else
            {
                alg1.Visibility = Visibility.Visible;
                cbalg1.Visibility = Visibility.Visible;
                cbheur1.Visibility = Visibility.Visible;
                heur1.Visibility = Visibility.Visible;
            }
        }
        public void cbg2DropDown(object sender, EventArgs e)
        {
            if (cbg2.SelectedIndex == 0)
            {
                alg2.Visibility = Visibility.Hidden;
                cbalg2.Visibility = Visibility.Hidden;
                cbheur2.Visibility = Visibility.Hidden;
                heur2.Visibility = Visibility.Hidden;
            }
            else
            {
                alg2.Visibility = Visibility.Visible;
                cbalg2.Visibility = Visibility.Visible;
                cbheur2.Visibility = Visibility.Visible;
                heur2.Visibility = Visibility.Visible;
            }
        }

        public void returnToMainMenu(object sender, EventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            parentWindow.DataContext = new MainMenu();
        }

        public void startGame(object sender, EventArgs e)
        {
           // MessageBox.Show((cbg1.SelectedItem as ComboBoxItem).Content.ToString() + " " + (cbg2.SelectedItem as ComboBoxItem).Content.ToString());
            if ((cbg1.SelectedItem as ComboBoxItem).Content.ToString().Equals("Alfa-Beta") || (cbg2.SelectedItem as ComboBoxItem).Content.ToString().Equals("Alfa-Beta") || (cbg2.SelectedItem as ComboBoxItem).Content.ToString().Equals("Człowiek"))
            {
                MessageBox.Show("Zaimplementowane rozgrywki: Człowiek vs MinMax oraz MinMax vs MinMax");
            }
            else
            {
                Window parentWindow = Window.GetWindow(this);
                
                var okn = new OknoGry((cbg1.SelectedItem as ComboBoxItem).Content.ToString(), (cbg2.SelectedItem as ComboBoxItem).Content.ToString(), (cbalg1.SelectedItem as ComboBoxItem).Content.ToString(),
                    (cbalg2.SelectedItem as ComboBoxItem).Content.ToString(), (cbheur1.SelectedItem as ComboBoxItem).Content.ToString(), (cbheur2.SelectedItem as ComboBoxItem).Content.ToString());

                if ((cbg1.SelectedItem as ComboBoxItem).Content.ToString().Equals("Człowiek")) {
                    CompPlayerMM cp = new CompPlayerMM(Convert.ToInt32((cbalg2.SelectedItem as ComboBoxItem).Content.ToString()));
                  //  okn.msg((Convert.ToInt32((cbalg2.SelectedItem as ComboBoxItem).Content.ToString())).ToString());
                    Connect4 c4 = new Connect4(cp, okn);
                    cp.setC4(c4);
                    cp.setSymbol('Y');
                    okn.Con4 = c4;
                   // okn.msg("start");
                }
                if ((cbg1.SelectedItem as ComboBoxItem).Content.ToString().Equals("MinMax"))
                {
                    CompPlayerMM cp = new CompPlayerMM(Convert.ToInt32((cbalg1.SelectedItem as ComboBoxItem).Content.ToString()));
                    CompPlayerMM cp2 = new CompPlayerMM(Convert.ToInt32((cbalg2.SelectedItem as ComboBoxItem).Content.ToString()));
                    //  okn.msg((Convert.ToInt32((cbalg2.SelectedItem as ComboBoxItem).Content.ToString())).ToString());
                    Connect4 c4 = new Connect4(cp,cp2, okn);
                    cp.setC4(c4);
                    cp.setSymbol('Y');
                    cp2.setC4(c4);
                    cp2.setSymbol('R');
                    okn.Con4 = c4;
                    // okn.msg("start");
                }
                okn.Show();
                
                parentWindow.Close();
            }
        }
    }
}
