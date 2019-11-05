using System;
using Foundation;
using UIKit;

namespace ChoiceApp
{
    public partial class FourthViewController : UIViewController
    {

        public double b0YonX { get; set; }
        public double b1YonX { get; set; }
        public double expB1YonX { set; get; }
        public double expB0YonX { set; get; }
        public double[] numbersX { set; get; }
        public double[] numbersY { set; get; }
        public double powerB1YonX { set; get; }
        public double powerB0YonX { set; get; }

        public double rsq { set; get; }
        public double expRsq { set; get; }
        public double powerRsq { set; get; }

        public FourthViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            mainInfo();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);
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

                plotViewController2.linearPlotEnabled = SwitchLinear.On;
                plotViewController2.expPlotEnabled = SwitchExp.On;
                plotViewController2.powerPlotEnabled = SwitchPower.On;
                
            }

        }

        public void mainInfo()
        {
            double[] rsqArray = { rsq, expRsq, powerRsq};
            double max = 0;
            for (int i=0;i<rsqArray.Length; i++)
            {
                if (max < rsqArray[i])
                {
                    max = rsqArray[i];
                }
            }

            if (max > 0.7)
            {
                if (Math.Abs(rsq - max) < 0.1)
                {
                    LabelMainInfo.Text = "According to the given data, linear dependence is most evident.";
                }
                else if (Math.Abs(expRsq - max) < 0.1)
                {
                    LabelMainInfo.Text = "According to the given data, exponential dependence is most evident.";
                }
                else
                {
                    LabelMainInfo.Text = "According to the given data, power dependence is most evident.";
                }
                if (numbersX.Length < 15)
                {
                    LabelMainInfo.Text += "But unfortunately, the given data is not enough to accurately determine the dependency.";
                }
                LabelMainInfo.TextColor = UIColor.SystemGreenColor;
            }
            else
            {
                LabelMainInfo.Text = "No dependency reflects the relationship between the data.";
                LabelMainInfo.TextColor = UIColor.SystemRedColor;
            }

        }
    }
}

