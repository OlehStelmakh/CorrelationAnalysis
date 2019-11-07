using System;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.Xamarin.iOS;
using UIKit;

namespace ChoiceApp
{
    public partial class PlotViewController2 : UIViewController
    {
        public double b0YonX { get; set; }
        public double b1YonX { get; set; }
        public double expB1YonX { set; get; }
        public double expB0YonX { set; get; }
        public double[] numbersX { set; get; }
        public double[] numbersY { set; get; }
        public double powerB1YonX { set; get; }
        public double powerB0YonX { set; get; }

        public bool linearPlotEnabled { set; get; }
        public bool expPlotEnabled { set; get; }
        public bool powerPlotEnabled { set; get; }

        private double maxX { set; get; }
        private double minX { set; get; }

        public PlotViewController2(IntPtr handle) : base(handle)
        {
            
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            minX = findMinX(numbersX);
            maxX = findMaxX(numbersX);
            this.View = new PlotView
            {
                Model = createPlotModel(),
            };
            
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        private double findMinX(double[] arrayX) 
        {
            double min = arrayX[0];
            for (int i=1; i<arrayX.Length; i++)
            {
                if (min > arrayX[i])
                {
                    min = arrayX[i];
                }
            }
            return min;
        }

        private double findMaxX(double[] arrayX)
        {
            double max = arrayX[0];
            for (int i = 1; i < arrayX.Length; i++)
            {
                if (max < arrayX[i])
                {
                    max = arrayX[i];
                }
            }
            return max;
        }

        private PlotModel createPlotModel()
        {
            OxyThickness thickness = new OxyThickness(35, 70, 15, 40);
            var plotModel = new PlotModel { Title = "OxyPlot Demo", PlotMargins = thickness };
            plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom });
            plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left });

            var series1 = new LineSeries
            {

                Title = "Точки",
                StrokeThickness = 3,
                LineStyle = LineStyle.None,
                MarkerType = MarkerType.Circle,
                MarkerSize = 5,
                MarkerStroke = OxyColors.White,
                MarkerFill = OxyColors.Automatic,
                MarkerStrokeThickness = 1.5,
            };

            for (int i=0;i<numbersX.Length; i++)
            {
                series1.Points.Add(new DataPoint(numbersX[i], numbersY[i]));
            }

            var series2 = new LineSeries
            {
                Title = "Лінійна ",
                StrokeThickness = 3,
                LineStyle = LineStyle.Automatic,
                MarkerType = MarkerType.None,
                MarkerSize = 5,
                MarkerStroke = OxyColors.White,
                MarkerFill = OxyColors.Automatic,
                MarkerStrokeThickness = 1.5,
            };

            for (double x = minX; x < maxX; x += 0.002)
            {
                double y = b0YonX + b1YonX * x;
                series2.Points.Add(new DataPoint(x, y));
            }

            var series3 = new LineSeries
            {
                Title = "Експоненційна",
                StrokeThickness = 3,
                LineStyle = LineStyle.Automatic,
                MarkerType = MarkerType.None,
                MarkerSize = 5,
                MarkerStroke = OxyColors.White,
                MarkerFill = OxyColors.Automatic,
                MarkerStrokeThickness = 1.5,
            };

            for (double x = minX; x < maxX ; x += 0.002)
            {
                double y = Math.Pow(10, expB1YonX * x + expB0YonX);
                series3.Points.Add(new DataPoint(x, y));
                
            }

            var series4 = new LineSeries
            {
                Title = "Статична",
                StrokeThickness = 3,
                LineStyle = LineStyle.Automatic,
                MarkerType = MarkerType.None,
                MarkerSize = 5,
                MarkerStroke = OxyColors.White,
                MarkerFill = OxyColors.Automatic,
                MarkerStrokeThickness = 1.5,
            };

            for (double x = minX ; x < maxX ; x += 0.002)
            {
                double b = Math.Pow(10, powerB0YonX);  //b = a^x
                double y = b* Math.Pow(x, powerB1YonX);
                //double y = powerB0YonX * Math.Pow(x, powerB1YonX);
                series4.Points.Add(new DataPoint(x, y));

               
            }

            if (linearPlotEnabled) { plotModel.Series.Add(series2); }
            if (expPlotEnabled) { plotModel.Series.Add(series3); }
            if (powerPlotEnabled) { plotModel.Series.Add(series4); }
            plotModel.Series.Add(series1);
            return plotModel;
        }
    }
}

