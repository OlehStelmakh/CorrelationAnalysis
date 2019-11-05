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


        //private double b1XonY { set; get; }
        //private double b0XonY { set; get; }
        private double b1YonX { set; get; }
        private double b0YonX { set; get; }

        private double expB1YonX { set; get; }
        private double expB0YonX { set; get; }

        private double powerB1YonX { set; get; }
        private double powerB0YonX { set; get; }


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
            if (segue.DestinationViewController is PlotViewController1)
            {
                var plotViewController1 = segue.DestinationViewController as PlotViewController1;
                //plotViewController1.b1XonY = this.b1XonY;
                //plotViewController1.b0XonY = this.b0XonY;
            }
            if (segue.DestinationViewController is PlotViewController2)
            {
                var plotViewController2 = segue.DestinationViewController as PlotViewController2;
                plotViewController2.b1YonX = this.b1YonX;
                plotViewController2.b0YonX = this.b0YonX;
                plotViewController2.expB1YonX = this.expB1YonX;
                plotViewController2.expB0YonX = this.expB0YonX;
                plotViewController2.powerB1YonX = this.powerB1YonX;
                plotViewController2.powerB0YonX = this.powerB0YonX;
                plotViewController2.numbersX = this.numbersX;
                plotViewController2.numbersY = this.numbersY;

            }
            
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
                double meanOfY = CalculateFirstVariant.Mean(numbersY, LabelFirst, "y");
                double r = CalculateFirstVariant.correlCoef(LabelSecond, numbersX, numbersY, meanOfX, meanOfY);
                double rsq = CalculateFirstVariant.RSQ(LabelSecond, r);
                //b1XonY = CalculateFirstVariant.findB1XonY(LabelFifth, numbersX, numbersY, meanOfX, meanOfY);
                //b0XonY = CalculateFirstVariant.findB0(LabelFifth, meanOfX, meanOfY, b1XonY);
                //CalculateFirstVariant.lineXonY(LabelSeventh, b1XonY, b0XonY);
                b1YonX = CalculateFirstVariant.findB1YonX(LabelThird, numbersX, numbersY, meanOfX, meanOfY);
                b0YonX = CalculateFirstVariant.findB0(LabelThird, meanOfY, meanOfX, b1YonX);
                CalculateFirstVariant.lineYonX(LabelFourth, b1YonX, b0YonX);

                //експоненційна залежність
                double[] newArrayY = CalculateFirstVariant.findLog(numbersY);
                double meanOfNewY = CalculateFirstVariant.Mean(newArrayY, LabelFifth, "y");
                double expR = CalculateFirstVariant.correlCoef(LabelSixth, numbersX, newArrayY, meanOfX, meanOfNewY);
                double expRsq = CalculateFirstVariant.RSQ(LabelSixth, expR);
                expB1YonX = CalculateFirstVariant.findB1YonX(LabelSeventh, numbersX, newArrayY, meanOfX, meanOfNewY);
                expB0YonX = CalculateFirstVariant.findB0(LabelSeventh, meanOfNewY, meanOfX, expB1YonX);
                CalculateFirstVariant.lineYonX(LabelEighth, expB1YonX, expB0YonX);

                //power
                double[] newArrayX = CalculateFirstVariant.findLog(numbersX);
                double meanOfNewX = CalculateFirstVariant.Mean(newArrayX, LabelNineth, "x");
                double powerR = CalculateFirstVariant.correlCoef(LabelTenth, newArrayX, newArrayY, meanOfNewX, meanOfNewY);
                double powerRsq = CalculateFirstVariant.RSQ(LabelTenth, powerR);
                powerB1YonX = CalculateFirstVariant.findB1YonX(LabelEleventh, newArrayX, newArrayY, meanOfNewX, meanOfNewY);
                powerB0YonX = CalculateFirstVariant.findB0(LabelEleventh, meanOfNewY, meanOfNewX, powerB1YonX);
                CalculateFirstVariant.lineYonX(LabelTwelfth, powerB1YonX, powerB0YonX);

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

