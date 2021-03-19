using System;
using System.Collections.Generic;
using System.Text;

namespace WpfConnect4
{
    public class CompPlayerR : CompPlayer
    {
        public Connect4 c4;
      public char symbol;
        Random rand = new Random();
        public CompPlayerR( char s)
        {
            
            this.symbol = s;
        }
        
        public override int selectedColumn()
        {
            do
            {
                int col = rand.Next(0, 7);
                if (c4.grid[0, col] == '.')
                {
                    return col;
                }
            } while (true);
        }

        public override void setC4(Connect4 c4)
        {
            this.c4 = c4;
        }

     
        public override char theOtherSymbol()
        {
            throw new NotImplementedException();
        }
    }
}
