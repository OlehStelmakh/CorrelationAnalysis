using System;
using ChoiceApp.Calculations;
using Foundation;
using UIKit;

namespace ChoiceApp
{
    public partial class ThirdViewController : UIViewController
    {
        public double[] numbersX { set; get; }
        public double[] numbersY { set; get; }
        public double Cov { set; get; }
        public double Sx { set; get; }
        public double Sy { set; get; }
        public int amount { set; get; }
        public double ZScoreX { set; get; }
        public double ZScoreY { set; get; }
        public double MeanX { set; get; }
        public double MeanY { set; get; }
        public int variantThatChecked { set; get; }


        private double b1XonY { set; get; }
        private double b0XonY { set; get; }
        private double b1YonX { set; get; }
        private double b0YonX { set; get; }

        public ThirdViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            calculate();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);
            /*var plotViewController1 = segue.DestinationViewController as PlotViewController1;
            plotViewController1.b1XonY = this.b1XonY;
            plotViewController1.b0XonY = this.b0XonY;
            var plotViewController2 = segue.DestinationViewController as PlotViewController2;
            plotViewController2.b1YonX = this.b1YonX;
            plotViewController2.b0YonX = this.b0YonX;*/ //TODO проблеми
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        private void calculate()
        {
            if (variantThatChecked==1) {
                double meanOfX = CalculateFirstVariant.Mean(numbersX, LabelFirst, "x");
                double meanOfY = CalculateFirstVariant.Mean(numbersY, LabelSecond, "y");
                double r = CalculateFirstVariant.correlCoef(LabelThird, numbersX, numbersY, meanOfX, meanOfY);
                double rsq = CalculateFirstVariant.RSQ(LabelFourth, r);
                b1XonY = CalculateFirstVariant.findB1XonY(LabelFifth, numbersX, numbersY, meanOfX, meanOfY);
                b0XonY = CalculateFirstVariant.findB0(LabelFifth, meanOfX, meanOfY, b1XonY);
                CalculateFirstVariant.lineXonY(LabelSeventh, b1XonY, b0XonY);
                b1YonX = CalculateFirstVariant.findB1YonX(LabelSixth, numbersX, numbersY, meanOfX, meanOfY);
                b0YonX = CalculateFirstVariant.findB0(LabelSixth, meanOfY, meanOfX, b1YonX);

            }
            else if (variantThatChecked == 2)
            {

            }
            else
            {

            }
        }
    }
}

