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

        public PlotViewController2(IntPtr handle) : base(handle)
        {
            this.View = new PlotView
            {
                Model = createPlotModel(),
            };
        }

        public override void ViewDidLoad()
        {
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
            OxyThickness thickness = new OxyThickness(25, 70, 15, 40);
            var plotModel = new PlotModel { Title = "OxyPlot Demo", PlotMargins= thickness };
            plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom });
            plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Maximum = 10, Minimum = 0 });

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

            var series2 = new LineSeries
            {
                Title = "\nЛінія регресії",
                StrokeThickness = 3,
                LineStyle = LineStyle.Automatic,
                MarkerType = MarkerType.Circle,
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

            series1.Points.Add(new DataPoint(0.0, 6.0));
            series1.Points.Add(new DataPoint(1.4, 2.1));
            series1.Points.Add(new DataPoint(2.0, 4.2));
            series1.Points.Add(new DataPoint(3.3, 2.3));
            series1.Points.Add(new DataPoint(4.7, 7.4));
            series1.Points.Add(new DataPoint(6.0, 6.2));
            series1.Points.Add(new DataPoint(8.9, 8.9));

            plotModel.Series.Add(series1);
            plotModel.Series.Add(series2);
            return plotModel;
        }
    }
}

