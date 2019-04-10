using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace XvsO
{
    public class XvsORoutines
    {
        public int[,] Mass { get; set; }
        public Canvas XvsOCanvas { get; set; }
        public Style Cross { get; set; }
        public Style Zero { get; set; }

        public XvsORoutines(Canvas canvas1, Style cross, Style zero, int[,] mass)
        {
            this.Mass = mass;
            this.XvsOCanvas = canvas1;
            this.Cross = cross;
            this.Zero = zero;
        }

        public void DrawingXorO(double X, double Y, ref bool flag)
        {
            int intX = Convert.ToInt32(X);
            int intY = Convert.ToInt32(Y);

            if (intX < 100)
            {
                if (intY < 100 && Mass[0, 0] == 0)
                {
                    this.XorO(new Thickness(25, 25, 0, 0), 0, 0, ref flag);
                    return;
                }
                if (intY >= 100 && intY < 200 && Mass[0, 1] == 0)
                {
                    this.XorO(new Thickness(25, 125, 0, 0), 0, 1, ref flag);
                    return;
                }
                if (intY >= 200 && Mass[0, 2] == 0)
                {
                    this.XorO(new Thickness(25, 225, 0, 0), 0, 2, ref flag);
                    return;
                }
            }

            if (intX >= 100 && intX < 200)
            {
                if (intY < 100 && Mass[1, 0] == 0)
                {
                    this.XorO(new Thickness(125, 25, 0, 0), 1, 0, ref flag);
                    return;
                }
                if (intY >= 100 && intY < 200 && Mass[1, 1] == 0)
                {
                    this.XorO(new Thickness(125, 125, 0, 0), 1, 1, ref flag);
                    return;
                }
                if (intY >= 200 && Mass[1, 2] == 0)
                {
                    this.XorO(new Thickness(125, 225, 0, 0), 1, 2, ref flag);
                    return;
                }
            }

            if (intX >= 200)
            {
                if (intY < 100 && Mass[2, 0] == 0)
                {
                    this.XorO(new Thickness(225, 25, 0, 0), 2, 0, ref flag);
                    return;
                }
                if (intY >= 100 && intY < 200 && Mass[2, 1] == 0)
                {
                    this.XorO(new Thickness(225, 125, 0, 0), 2, 1, ref flag);
                    return;
                }
                if (intY >= 200 && Mass[2, 2] == 0)
                {
                    this.XorO(new Thickness(225, 225, 0, 0), 2, 2, ref flag);
                    return;
                }
            }
        }

        public void XorO(Thickness margin, int i, int j, ref bool flag)
        {
            Image img = new Image();

            if (flag)
            {
                img.Style = Cross;
                img.Margin = margin;
                XvsOCanvas.Children.Add(img);
                Mass[i, j] = 1;
                flag = false;
            }
            else
            {
                img.Style = Zero;
                img.Margin = margin;
                XvsOCanvas.Children.Add(img);
                Mass[i, j] = 4;
                flag = true;
            }
        }

        public void WhoWin(ref bool flag)
        {
            int result = 0;
            int count = 0;

            Line winLine = new Line();
            winLine.Stroke = System.Windows.Media.Brushes.CornflowerBlue;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    result += Mass[i, j];
                }

                if (result == 3)
                {
                    winLine.X1 = 50 + 100*i;
                    winLine.X2 = 50 + 100*i;
                    winLine.Y1 = 50;
                    winLine.Y2 = 250;

                    winLine.StrokeThickness = 5;
                    XvsOCanvas.Children.Add(winLine);
                    flag = true;
                    MessageBox.Show("Победили крестики!");
                    this.RedrawingXvsO();
                    return;
                }
                if (result == 12)
                {
                    winLine.X1 = 50 + 100 * i;
                    winLine.X2 = 50 + 100 * i;
                    winLine.Y1 = 50;
                    winLine.Y2 = 250;

                    winLine.StrokeThickness = 5;
                    XvsOCanvas.Children.Add(winLine);
                    flag = true;
                    MessageBox.Show("Победили нолики!");
                    this.RedrawingXvsO();
                    return;
                }
                result = 0;
            }

            for (int j = 0; j < 3; j++)
            {
                for (int i = 0; i < 3; i++)
                {
                    result += Mass[i, j];
                }

                if (result == 3)
                {
                    winLine.X1 = 50;
                    winLine.X2 = 250;
                    winLine.Y1 = 50 + 100*j;
                    winLine.Y2 = 50 + 100*j;

                    winLine.StrokeThickness = 5;
                    XvsOCanvas.Children.Add(winLine);
                    flag = true;
                    MessageBox.Show("Победили крестики!");
                    this.RedrawingXvsO();
                    return;
                }
                if (result == 12)
                {
                    winLine.X1 = 50;
                    winLine.X2 = 250;
                    winLine.Y1 = 50 + 100 * j;
                    winLine.Y2 = 50 + 100 * j;

                    winLine.StrokeThickness = 5;
                    XvsOCanvas.Children.Add(winLine);
                    flag = true;
                    MessageBox.Show("Победили нолики!");
                    this.RedrawingXvsO();
                    return;
                }
                result = 0;
            }

            for (int i = 0; i < 3; i++)
            {
                result += Mass[i, i];

                if (result == 3)
                {
                    winLine.X1 = 50;
                    winLine.X2 = 250;
                    winLine.Y1 = 50;
                    winLine.Y2 = 250;

                    winLine.StrokeThickness = 5;
                    XvsOCanvas.Children.Add(winLine);
                    flag = true;
                    MessageBox.Show("Победили крестики!");
                    this.RedrawingXvsO();
                    return;
                }
                if (result == 12)
                {
                    winLine.X1 = 50;
                    winLine.X2 = 250;
                    winLine.Y1 = 50;
                    winLine.Y2 = 250;

                    winLine.StrokeThickness = 5;
                    XvsOCanvas.Children.Add(winLine);
                    flag = true;
                    MessageBox.Show("Победили нолики!");
                    this.RedrawingXvsO();
                    return;
                }   
            }

            result = 0;

            for (int i = 2; i >= 0; i--)
            {
                result += Mass[i, (2-i)];

                if (result == 3)
                {
                    winLine.X1 = 250;
                    winLine.X2 = 50;
                    winLine.Y1 = 50;
                    winLine.Y2 = 250;

                    winLine.StrokeThickness = 5;
                    XvsOCanvas.Children.Add(winLine);
                    flag = true;
                    MessageBox.Show("Победили крестики!");
                    this.RedrawingXvsO();
                    return;
                }
                if (result == 12)
                {
                    winLine.X1 = 250;
                    winLine.X2 = 50;
                    winLine.Y1 = 50;
                    winLine.Y2 = 250;

                    winLine.StrokeThickness = 5;
                    XvsOCanvas.Children.Add(winLine);
                    flag = true;
                    MessageBox.Show("Победили нолики!");
                    this.RedrawingXvsO();
                    return;
                }
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Mass[i,j] != 0)
                    {
                        count++;
                    }
                }
            }

            if (count >= 9)
            {
                flag = true;
                MessageBox.Show("Ничья!");
                this.RedrawingXvsO();
                return;
            }
        }

        public void RedrawingXvsO()
        {
            XvsOCanvas.Children.Clear();

            for (int i = 0; i < 4; i++)
            {
                Line razmetka = new Line();

                razmetka.Stroke = System.Windows.Media.Brushes.Black;
                razmetka.StrokeThickness = 4;

                razmetka.X1 = 100*i;
                razmetka.X2 = 100*i;
                razmetka.Y1 = 0;
                razmetka.Y2 = 300;
                XvsOCanvas.Children.Add(razmetka);
            }

            for (int i = 0; i < 4; i++)
            {
                Line razmetka = new Line();

                razmetka.Stroke = System.Windows.Media.Brushes.Black;
                razmetka.StrokeThickness = 4;

                razmetka.X1 = 0;
                razmetka.X2 = 300;
                razmetka.Y1 = 100*i;
                razmetka.Y2 = 100*i;
                XvsOCanvas.Children.Add(razmetka);
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Mass[i, j] = 0;
                }
            }
        }
    }
}
