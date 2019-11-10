using System;
using System.Linq;
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

        private double maxRSQ { set; get; }
        private bool on { set; get; } = true;

        public bool expLabelHidden { set; get; }
        public bool powLabelHidden { set; get; }

        public FourthViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            mainInfo();
            if (expLabelHidden)
            {
                SwitchExp.On = false;
                SwitchExp.Enabled = false;
            }
            if (powLabelHidden)
            {
                SwitchPower.On = false;
                SwitchPower.Enabled = false;
            }
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

                if (on)
                {
                    plotViewController2.linearPlotEnabled = SwitchLinear.On;
                    plotViewController2.expPlotEnabled = SwitchExp.On;
                    plotViewController2.powerPlotEnabled = SwitchPower.On;
                }
                
                
            }

        }

        public void mainInfo()
        {
            double[] rsqArray = { rsq, expRsq, powerRsq};
            for (int i=0;i<rsqArray.Length; i++)
            {
                if (maxRSQ < rsqArray[i])
                {
                    maxRSQ = rsqArray[i];
                }
            }

            if (maxRSQ > 0.6 || maxRSQ < -0.6)
            {
                if (Math.Abs(rsq - maxRSQ) < 0.0001)
                {
                    LabelMainInfo.Text = "According to the given data, linear dependence is most evident.";
                }
                else if (Math.Abs(expRsq - maxRSQ) < 0.0001)
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
                on = false;
                ButtonAnswer.Enabled = false;
                SwitchLinear.On = false;
                SwitchLinear.Enabled = false;
                SwitchExp.On = false;
                SwitchExp.Enabled = false;
                SwitchPower.On = false;
                SwitchPower.Enabled = false;
                
            }

        }

        partial void UIButton34688_TouchUpInside(UIButton sender)
        {
            if (!String.IsNullOrWhiteSpace(FieldForPredict.Text))
            {
                double x = readOneNumber(FieldForPredict);
                if (x==double.MinValue)
                {
                    LabelAnswer.TextColor = UIColor.SystemRedColor;
                    LabelAnswer.Text = "Number not found! Try again.";
                }
                else if (Math.Abs(rsq - maxRSQ) < 0.0001)
                {
                    double y = b0YonX + b1YonX * x;
                    LabelAnswer.TextColor = UIColor.Black;
                    LabelAnswer.Text = $"Predicted value: {Math.Round(y,3)} ";
                }
                else if (Math.Abs(expRsq - maxRSQ) < 0.0001)
                {

                    double y = Math.Pow(10, expB1YonX * x + expB0YonX);
                    LabelAnswer.TextColor = UIColor.Black;
                    LabelAnswer.Text = $"Predicted value: {Math.Round(y,3)} ";
                }
                else
                {
                    double b = Math.Pow(10, powerB0YonX);  //b = a^x
                    double y = b * Math.Pow(x, powerB1YonX);
                    LabelAnswer.TextColor = UIColor.Black;
                    LabelAnswer.Text = $"Predicted value: {Math.Round(y,3)} ";
                }
                LabelAnswer.Hidden = false;
            }
            else {
                LabelAnswer.Hidden = true;
            }
        }

        public double readOneNumber(UITextField textField)
        {
            string[] array = textField.Text.Trim().Split(" ");
            double[] numbers = array.Select(x => TryParseInTextField(x)).ToArray();
            numbers = numbers.Where(x => Math.Abs(x - int.MinValue) > 0.1).ToArray();
            if (numbers.Length >= 1)
            {
                return numbers[0];
                //LabelMessage.Text = "More than one value is entered in one of the fields. " +
                //        "The first value will be applied.";
                //LabelMessage.TextColor = UIColor.SystemRedColor;
            }
            return double.MinValue;
        }

        public static double TryParseInTextField(string a)
        {
            double x;
            try
            {
                x = Convert.ToDouble(double.Parse(a));
                return x;
            }
            catch (FormatException)
            {
                return int.MinValue;
            }
        }
    }
}

