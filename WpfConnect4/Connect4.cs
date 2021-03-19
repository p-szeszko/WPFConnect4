using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WpfConnect4
{
    public class Connect4
    {
        static char[] PLAYERS = { 'Y', 'R' };
       public int width, height;
       public char[,] grid;
        public int lCol = -1, lTop = -1;
        public CompPlayer ai;
        public CompPlayer ai2;
        public   bool isF = false;
        public char? winner;
        public int selectedCol = -1;
        bool aif = true;
        bool ai2f = true;
        Random rand = new Random();
        public OknoGry og;
       public Connect4 (CompPlayer cp, OknoGry og)
        {
            this.og = og;
            this.ai = cp;
            Console.WriteLine(ai.symbol);
            this.width = 7;
            this.height = 6;
            grid = new char[height, width];
            for (int i=0;i<height;i++)
            {
               for (int j=0;j<width;j++)
                {
                    grid[i, j] = '.';
                }
            }
            
        }

     public Connect4(CompPlayer cp,CompPlayer cp2, OknoGry og)
        {
            this.og = og;
            this.ai = cp;
            this.ai2 = cp2;
            //Console.WriteLine(ai.symbol);
            this.width = 7;
            this.height = 6;
            grid = new char[height, width];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    grid[i, j] = '.';
                }
            }

        }

        public void makeEnemy2Move()
        {
            if (!ai2f)
            {
                int col = ai2.selectedColumn();
                dropOne(ai2.symbol, col);
                checkWin();
                og.cr++;
            }
            else
            {
                int col = rand.Next(0, 7);

                dropOne(ai2.symbol, col);
                og.cr++;
                ai2f = false;
            }

            isFull();
        }

       public void makeEnemyMove()
        {
            if (!aif)
            {
                int col = ai.selectedColumn();
                dropOne(ai.symbol, col);

                og.zr++;
                checkWin();
            }
            else
            {
                int col = rand.Next(0, 7);

                dropOne(ai.symbol, col);
                og.zr++;
                aif = false;
            }
            isFull();
        }
        public bool makeaMoves2(int i)
        {
            bool x = false;
            if (dropOne(ai.theOtherSymbol(), i))
            {
                x = true;
                og.cr++;
                checkWin();
            }

            isFull();
            return x;
        }

        public async void eve()
        {
            int player = 0;
            if (PLAYERS[0] == ai.symbol)
            {

               // Console.WriteLine("Komputer gra jako: " + PLAYERS[0]);
                //Console.WriteLine("Człowiek gra jako: " + PLAYERS[1]);
            }
            else
            {

            //    Console.WriteLine("Komputer gra jako: " + PLAYERS[1]);
              //  Console.WriteLine("Człowiek gra jako: " + PLAYERS[0]);
            }



            do
            {
                bool full = false;
                //Console.WriteLine("0123456");
                //Console.WriteLine(toString());
                player %= 2;
                //Console.WriteLine(player);
                if (PLAYERS[player] == ai.symbol)
                {
                    if (!aif)
                    {
                        int col = ai.selectedColumn();
                        dropOne(ai.symbol, col);
                        //  Console.WriteLine("Tura Komputera: "+ col);
                        player++;
                       og.updateGrid2();
                    }
                    else
                    {
                        int col = rand.Next(0, 7);

                        dropOne(ai.symbol, col);
                        player++;
                        aif = false;
                         og.updateGrid2();
                    }

                }
                else
                {
                    /* Console.Write("Tura Gracza: ");
                     int col = Convert.ToInt32(Console.ReadLine());

                     if (col < 0 || col > width-1)
                     {
                         Console.WriteLine("Kolumna musi być między 0 a 6 ");

                     }
                     else
                     {
                         if(!dropOne(ai.theOtherSymbol(),col))
                         {
                             Console.WriteLine("Kolumna pełna, wybierz inną!");
                         }
                         else
                         {
                             player++;
                         }
                     }
                     */
                    if (!ai2f)
                    {
                        int col = ai2.selectedColumn();
                        dropOne(ai2.symbol, col);
                        // Console.WriteLine("Tura Komputera: " + col);
                        player++;
                         og.updateGrid2();
                    }
                    else
                    {
                        int col = rand.Next(0, 7);

                        dropOne(ai2.symbol, col);
                        player++;
                        ai2f = false;
                      og.updateGrid2();
                    }
                }



              
                winner = checkWin();
                if (winner != null)
                {
                    //Console.WriteLine("Brawo wygrywają: " + winner);
                    //Console.WriteLine(toString());
                   ;
                    og.showWinner();
                    break;
                }
                isFull();
                if (isF)
                {
                    //Console.WriteLine("Remis!");
                    //Console.WriteLine(toString());
                   
                    break;
                }

            } while (true);
           
        }


       



        public void pve()
        {
            int player = 0;
            if (PLAYERS[0] == ai.symbol)
            {

              //  Console.WriteLine("Komputer gra jako: " + PLAYERS[0]);
               // Console.WriteLine("Człowiek gra jako: " + PLAYERS[1]);
            }
            else
            {

             //   Console.WriteLine("Komputer gra jako: " + PLAYERS[1]);
              //  Console.WriteLine("Człowiek gra jako: " + PLAYERS[0]);
            }



            do
            {
                bool full = false;
             //   Console.WriteLine("0123456");
             //   Console.WriteLine(toString());
                player %= 2;
             //   Console.WriteLine(player);
                if (PLAYERS[player] == ai.symbol)
                {
                    int col = ai.selectedColumn();
                    dropOne(ai.symbol, col);
               //     Console.WriteLine("Tura Komputera: " + col);
                    player++;


                }
                else
                {
                  //  Console.Write("Tura Gracza: ");
                    int col = Convert.ToInt32(Console.ReadLine());

                    if (col < 0 || col > width - 1)
                    {
                      //  Console.WriteLine("Kolumna musi być między 0 a 6 ");

                    }
                    else
                    {
                        if (!dropOne(ai.theOtherSymbol(), col))
                        {
                           // Console.WriteLine("Kolumna pełna, wybierz inną!");
                        }
                        else
                        {
                            player++;
                        }
                    }


                }
                winner = checkWin();
                if (winner != null)
                {
                   // Console.WriteLine("Brawo wygrywają: " + winner);
                   // Console.WriteLine(toString());
                    break;
                }
                isFull();
                if (isF)
                {
                   // Console.WriteLine("Remis!");
                   // Console.WriteLine(toString());
                    break;
                }

            } while (true);

        }






        //umiesc w kolumnie
        public bool dropOne(char symbol, int column)
        {
            int row = 0;
            while (row < width-1 && grid[row, column]=='.')
            {
                row++;
            }

            if (row == 0)
                return false;
           grid[row-1, column ] = symbol;
            lTop = row - 1;
            lCol = column;
            return true;
        }

        //usun najwyzszy w kolumnie, jezeli istnieje
        public bool removeOne(int column)
        {
            int row = 0;
            while (row < width-1 && grid[row, column]=='.')
            {
                row++;
            }

            if (row == 6)
                return false;
            grid[row, column] = '.' ;           
            return true;
        }


       
        //czy plansza jest pelna, sprawdza pierwszy wiersz, czy ma wolne pozycje
        public void isFull()
        {
            isF = true;
            for (int i = 0; i < width; i++)
            {
                if (grid[0, i] == '.')
                {
                    isF = false;
                }
            }
        }



        //plansza do string
        public string toString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    sb.Append(grid[i, j]);
                }
                sb.Append('\n');
            }

            return sb.ToString();
        }

       
        //zestaw funkcji do sprawdania wygranej" tworzenie pionowo, poziomo, ukosnie stringów od ostatniej pozycji na której dodano
        //"zeton"  i funkcja przeszukująca stringi w poszukiwnaiu ciągów wygrywających 
        public string horizontalLine()
        {
            StringBuilder sbH = new StringBuilder();

            for (int j = 0; j < width; j++)
            {
                sbH.Append(grid[lTop, j]);
            }
            return sbH.ToString();
        }

        public string verticalLine()
        {
            StringBuilder sb = new StringBuilder();
            for (int j = 0; j < height; j++)
            {
                sb.Append(grid[j, lCol]);
            }
            return sb.ToString();
        }

        public string slashLine()
        {
            StringBuilder sb = new StringBuilder();
            for (int i=0;i<height;i++)
            {
                int s = lCol + lTop - i;
                if(0<=s&& s<width)
                {
                    //Console.WriteLine("Tutaj" + grid[i, s]);
                    sb.Append(grid[i, s]);
                }
            }
            //Console.WriteLine(sb.ToString());
            return sb.ToString();
        }

        public string bslashLine()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < height; i++)
            {
                int s = lCol - lTop + i;
                if (0 <= s && s < width)
                {
                    //Console.WriteLine("Tutaj" + grid[i, s]);
                    sb.Append(grid[i, s]);
                }
            }
            return sb.ToString();
        }

        public char? checkWin()
        {
            //Console.WriteLine("Tutaj" + grid[lTop, lCol]);
            char symbol = grid[lTop,lCol];
            string streak = String.Format("{0}{1}{2}{3}", symbol, symbol, symbol, symbol);
            //Console.WriteLine(streak);

            if (horizontalLine().Contains(streak) || verticalLine().Contains(streak)
                    || slashLine().Contains(streak) || bslashLine().Contains(streak))
            {
               
                winner = grid[lTop, lCol];
                //Console.WriteLine("Winner: " + winner);
                return winner;
            }
            else
            {
                winner = null;
                return winner;
            }
        }
        
       

    }
}


