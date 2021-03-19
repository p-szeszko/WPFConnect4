using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace WpfConnect4
{
    public class CompPlayerMM : CompPlayer
    {
        public Connect4 c4;
        public char[,] copy;
        public char symbol;
        Random rand = new Random();
        public int depth;
        private int save;

         
        public CompPlayerMM(int d)
        {
            depth = d;
            save = d;
          //  MessageBox.Show(depth.ToString());
        }
        public override int selectedColumn()
        {


            List<Tuple<int, int>> listOfM = new List<Tuple<int, int>>();
            for (int i = 0; i < 7; i++)
            {

               
                if (c4.dropOne(symbol, i))
                {
                    listOfM.Add(Tuple.Create(i, MinMax(depth, false)));
                    c4.removeOne(i);
                }
                
            }
            int mValue = listOfM.Max(t => t.Item2);
            List<Tuple<int, int>> bestMoves = listOfM.Where(t => t.Item2 == mValue).ToList();
            
            return  bestMoves[rand.Next(0, bestMoves.Count)].Item1;
           
        }

        public override void setC4(Connect4 c4)
        {
            this.c4 = c4;
        }

      
      
        int MinMax(int depth, bool maxPlayer)
        {
            int score = evaluate(depth);
            // Console.WriteLine(c4.winner);
            if (score == depth)
                return depth;
            if (score == -depth)
                return -depth;
            if (c4.isF)
                return 0;
            if (depth <= 0)
                return 0;


            int bestValue = maxPlayer ? -1 : 1;
            for (int i = 0; i < 7; i++)
            {

                if (c4.dropOne(maxPlayer ? symbol : theOtherSymbol(), i))
                {
                    //Console.WriteLine(c4.toString());
                    int v = MinMax(depth - 1, !maxPlayer);
                    if (maxPlayer)
                    {
                        bestValue = Math.Max(bestValue, v);
                    }
                    else
                    {
                        bestValue = Math.Min(bestValue, v);
                    }
                    c4.removeOne(i);
                }
            }

            return bestValue;
        }

        int evaluate(int depth)
        {
            char? winner = c4.checkWin();
            if (winner == symbol)
            {
                return depth;
            }
            if (winner == theOtherSymbol())
            {
                return -depth;
            }
            else
                return -1;

        }

        public override char theOtherSymbol()
        {
            if (symbol == 'R')
            {
                return 'Y';
            }
            else
                return 'R';
        }
    }




}
