using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace XvsO
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static bool flag = true;

        public int[,] massXvsO = new int[3, 3];

        public MainWindow()
        {
            InitializeComponent();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    massXvsO[i, j] = 0;
                }
            }
        }

        private void canvas1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            XvsORoutines xo = new XvsORoutines(canvas1, (Style)FindResource("crossStyle"), (Style)FindResource("zeroStyle"), massXvsO);

            Point position = e.GetPosition(canvas1);

            xo.DrawingXorO(position.X, position.Y, ref flag);

            xo.WhoWin(ref flag);
        }
    }
}
