using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace WPPaint
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor

        Point startPoint, endPoint;
        private bool stratDraw = false;



        public MainPage()
        {
            InitializeComponent();
        }

        private void canvas1_MouseMove(object sender, MouseEventArgs e)
        {
            startPoint = e.GetPosition(this.canvas1);

            Line line = new Line() { X1 = startPoint.X, Y1 = startPoint.Y, X2 = endPoint.X, Y2 = endPoint.Y };
            line.Stroke = new SolidColorBrush(Colors.Red);
            line.StrokeThickness = 7;

            this.canvas1.Children.Add(line);
            endPoint = startPoint;
        }

        private void canvas1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void canvas1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(canvas1);
            endPoint = startPoint;
        }
    }
}