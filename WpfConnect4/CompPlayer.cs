using System;
using System.Collections.Generic;
using System.Text;

namespace WpfConnect4
{
  public abstract  class CompPlayer
    {
       public char symbol;
        protected Connect4 c4;
            
        public void setSymbol(char z)
        {
            symbol=z;
        }
        public abstract int selectedColumn();
        public abstract void setC4(Connect4 c4);
        public abstract char theOtherSymbol();
    }
}
