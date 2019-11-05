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
        public double newB1YonX { set; get; }
        public double newB0YonX { set; get; }
        public double[] numbersX { set; get; }
        public double[] numbersY { set; get; }

        public PlotViewController2(IntPtr handle) : base(handle)
        {
            
        }

        public override void ViewDidLoad()
        {
            this.View = new PlotView
            {
                Model = createPlotModel(),
            };
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        private PlotModel createPlotModel()
        {
            OxyThickness thickness = new OxyThickness(35, 70, 15, 40);
            var plotModel = new PlotModel { Title = "OxyPlot Demo", PlotMargins= thickness };
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
                Title = "Лінійна залежність",
                StrokeThickness = 3,
                LineStyle = LineStyle.Automatic,
                MarkerType = MarkerType.None,
                MarkerSize = 5,
                MarkerStroke = OxyColors.White,
                MarkerFill = OxyColors.Automatic,
                MarkerStrokeThickness = 1.5,
            };

            for (double x = 0; x < 10; x += 0.2)
            {
                double y = b0YonX + b1YonX * x;
                series2.Points.Add(new DataPoint(x, y));
            }

            var series3 = new LineSeries
            {
                Title = "Експоненційна зал",
                StrokeThickness = 3,
                LineStyle = LineStyle.Automatic,
                MarkerType = MarkerType.None,
                MarkerSize = 5,
                MarkerStroke = OxyColors.White,
                MarkerFill = OxyColors.Automatic,
                MarkerStrokeThickness = 1.5,
            };

            for (double x=0; x<10; x+=0.2)
            {
                double y = Math.Pow(10, newB1YonX * x + newB0YonX);
                series3.Points.Add(new DataPoint(x, y));
            }
            
            plotModel.Series.Add(series2);
            plotModel.Series.Add(series3);
            plotModel.Series.Add(series1);
            return plotModel;
        }
    }
}

