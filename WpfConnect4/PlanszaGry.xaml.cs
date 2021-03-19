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
    /// Logika interakcji dla klasy PlanszaGry.xaml
    /// </summary>
    public partial class PlanszaGry : UserControl
    {
        int left = 428;
        int top = 282;
        int move_left = 113;
        int move_top = 96;
        int a = 85;
        Rectangle[,] grid = new Rectangle[6, 7];
        public PlanszaGry()
        {
            InitializeComponent();
            for (int i=0;i<6;i++)
            {
                for (int j=0;j<7; j++)
                {
                    System.Windows.Shapes.Rectangle rect;
                    rect = new System.Windows.Shapes.Rectangle();
                    rect.Stroke = new SolidColorBrush(Colors.Yellow);
                    rect.Fill = new SolidColorBrush(Colors.Yellow);
                    rect.Width = a;
                    rect.Height = a;
                    Canvas.SetLeft(rect, left+(j*move_left));
                    Canvas.SetTop(rect, top+(i*move_top));
                    grid[i, j] = rect;
                    this.AddChild(rect);
                    
                }
            }
        }
    }
}
