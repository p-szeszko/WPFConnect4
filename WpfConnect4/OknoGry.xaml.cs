using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfConnect4
{
    /// <summary>
    /// Logika interakcji dla klasy OknoGry.xaml
    /// </summary>
    public partial class OknoGry : Window
    {

        int left = 428;
        int top = 282;
        int move_left = 113;
        int move_top = 96;
        int a = 85;
        int col;
        bool clicked = false;
        public int zr = 0;
        public int cr = 0;

        public Connect4 Con4 { get; set; }
        string enemy1, enemy2, depth1, depth2, heur1, heur2;
        public Rectangle[,] sgrid = new Rectangle[6, 7];
        public List<Button> buttons = new List<Button>();
        /* public OknoGry()
         {
             InitializeComponent();
             for (int i = 0; i < 6; i++)
             {
                 for (int j = 0; j < 7; j++)
                 {
                     System.Windows.Shapes.Rectangle rect;
                     rect = new System.Windows.Shapes.Rectangle();
                     rect.Stroke = new SolidColorBrush(Colors.Black);
                     rect.Fill = new SolidColorBrush(Colors.Black);
                     rect.Width = a;
                     rect.Height = a;
                     Canvas.SetLeft(rect, left + (j * move_left));
                     Canvas.SetTop(rect, top + (i * move_top));
                     grid[i, j] = rect;

                     canvas.Children.Add(rect);

                 }
             }
         }*/

        public OknoGry(string enemy1, string enemy2, string depth1, string depth2, string heur1, string heur2)
        {
            InitializeComponent();
            this.enemy1 = enemy1;
            this.enemy2 = enemy2;
            this.depth1 = depth1;
            this.depth2 = depth2;
            this.heur1 = heur1;
            this.heur2 = heur2;
            buttons.Add(c0);
            buttons.Add(c1);
            buttons.Add(c2);
            buttons.Add(c3);
            buttons.Add(c4);
            buttons.Add(c5);
            buttons.Add(c6);
          
            ng.Visibility = Visibility.Hidden;
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    System.Windows.Shapes.Rectangle rect;
                    rect = new System.Windows.Shapes.Rectangle();
                    rect.Stroke = new SolidColorBrush(Colors.White);
                    rect.Fill = new SolidColorBrush(Colors.White);
                    rect.Width = a;
                    rect.Height = a;
                    Canvas.SetLeft(rect, left + (j * move_left));
                    Canvas.SetTop(rect, top + (i * move_top));
                    sgrid[i, j] = rect;
                    canvas.Children.Add(rect);
                    
                }
            }
            
            if(enemy1=="Człowiek")
            {
                nt.Visibility = Visibility.Hidden;
            }
            if(enemy1=="MinMax")
            {
               foreach(Button b in buttons)
                {
                    b.IsEnabled = false;
                }
            }
            TopLabel.Content = enemy1 + " vs " + enemy2;
           // MessageBox.Show(enemy1 + " " + enemy2 + " " + depth1 + " " + depth2);
        }
       

        public void start(object sender, EventArgs e)
        {
            if (enemy1 == "Człowiek") { }
            else if (enemy1 == "MinMax") Con4.eve();
            
        }

        
        public void msg(string s)
        {
            MessageBox.Show(s);
        }
        public async void selCol(object sender, EventArgs e)
        {
            //MessageBox.Show((sender as Button).Content.ToString());
            
            col = Convert.ToInt32((sender as Button).Content.ToString()) - 1;

            bool z=Con4.makeaMoves2(col);
            if (z)
            {
                updateMoves();
                updateGrid2();

                if (Con4.winner == Con4.ai.theOtherSymbol())
                {
                    showWinner();
                }
                if (Con4.isF)
                    boardFull();
                else
                {
                    Con4.makeEnemyMove();
                    updateGrid2();
                    updateMoves();
                    if (Con4.winner == Con4.ai.symbol)
                    {
                        showWinner();
                    }
                    if (Con4.isF)
                        boardFull();
                }
            }  
        }

        public  void nextAva(object sender, EventArgs e)
        {
            //MessageBox.Show((sender as Button).Content.ToString());
           
                Con4.makeEnemyMove();
            updateMoves();
                updateGrid2();
                if (Con4.winner == Con4.ai.symbol)
                {
                    showWinner();
                    
                }
                else
                {
                    Con4.makeEnemy2Move();
                updateMoves();
                    updateGrid2();
                    if (Con4.winner == Con4.ai2.symbol)
                    {
                        showWinner();
                      
                    }
                }
          
           
        }

        public void boardFull()
        {
            if (Con4.winner != 'R' && Con4.winner != 'Y')
            {
                foreach (Button b in buttons)
                {
                    b.IsEnabled = false;
                }
                nt.IsEnabled = false;
                TopLabel.Content = "Remis! Plansza jest pełna ";
                ng.Visibility = Visibility.Visible;
                ng.Click += newGame;
            }
        }
        public void updateMoves()
        {
            rzolte.Content = zr;
            rczerwone.Content = cr;
        }
        public void showWinner()
        {
           if(enemy1=="Człowiek")
            {
                if(Con4.winner=='R')
                {
                    TopLabel.Content = "Wygrywasz!";
                }
                else
                {
                    TopLabel.Content = "Przegrałeś :(";
                }
                foreach (Button b in buttons)
                {
                    b.IsEnabled = false;
                }

            }
           else
            {

                if (Con4.winner == 'R')
                {
                    TopLabel.Content = "Wygrywa Czerwony "+enemy2;
                }
                else
                {
                    TopLabel.Content = "Wygrywa Żółty " + enemy1 ;
                }
                nt.IsEnabled = false;
            }
            ng.Visibility = Visibility.Visible;
            ng.Click += newGame;
        }

        public void newGame(object sender, EventArgs e)
        {
            var okn = new MainWindow();
            okn.DataContext = new NewGame();
            okn.Show();
            this.Close();
        }


        public void updateGrid2()
        {
            if (Con4.grid[Con4.lTop, Con4.lCol] == 'Y')
            {
                sgrid[Con4.lTop, Con4.lCol].Fill = new SolidColorBrush(Colors.Yellow);
                sgrid[Con4.lTop, Con4.lCol].InvalidateVisual();
                canvas.UpdateLayout();
            }

            if (Con4.grid[Con4.lTop, Con4.lCol] == 'R')
            {
                sgrid[Con4.lTop, Con4.lCol].Fill = new SolidColorBrush(Colors.Red);
                sgrid[Con4.lTop, Con4.lCol].InvalidateVisual();
                canvas.UpdateLayout();
            }
            

           /* bool v = true;
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (Con4.grid[i, j] == 'Y' )
                    {
                        sgrid[i, j].Fill = new SolidColorBrush(Colors.Yellow);
                        sgrid[i,j]
                    }
                    if (Con4.grid[i, j] == 'R')
                    {
                        sgrid[i, j].Fill = new SolidColorBrush(Colors.Red);
                    }
                }
            }*/
            
        }
    }
}
