using System;
using System.Linq;
using Foundation;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.Xamarin.iOS;
using UIKit;

namespace ChoiceApp
{
    public partial class SecondViewController : UIViewController
    {
        public bool XYIsChecked { set; get; }
        public bool CovIsChecked { set; get; }
        public bool StandDevIsChecked { set; get; }
        public bool AmountIsChecked { set; get; }
        public bool ZScoreIsChecked { set; get; }
        public bool MeanIsChecked { set; get; }

        private bool firstVariantChecked { set; get; }
        private bool secondVarintChecked { set; get; }
        private bool thirdVariandChecked { set; get; }

        public int amountOfFields { set; get; }
       

        public SecondViewController(IntPtr handle) : base(handle)
        {
            
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);
            var thirdViewController = segue.DestinationViewController as ThirdViewController;
            if (firstVariantChecked)
            {
                thirdViewController.numbersX = readData(TextFieldFirst);
                thirdViewController.numbersY = readData(TextFieldSecond);
                thirdViewController.variantThatChecked = 1;
            }
            else if (secondVarintChecked)
            {
                thirdViewController.Cov = readOneNumber(TextFieldFirst);
                thirdViewController.Sx = readOneNumber(TextFieldThird);
                thirdViewController.Sy = readOneNumber(TextFieldFourth);
                thirdViewController.MeanX = readOneNumber(TextFieldFifth);
                thirdViewController.MeanY = readOneNumber(TextFieldSixth);
                thirdViewController.variantThatChecked = 2;

            }
            else if(thirdVariandChecked)
            {
                thirdViewController.amount =Convert.ToInt32(readOneNumber(TextFieldFirst));
                thirdViewController.Sx = readOneNumber(TextFieldThird);
                thirdViewController.Sy = readOneNumber(TextFieldFourth);
                thirdViewController.MeanX = readOneNumber(TextFieldFifth);
                thirdViewController.MeanY = readOneNumber(TextFieldSixth);
                thirdViewController.ZScoreX = readOneNumber(TextFieldSeventh);
                thirdViewController.ZScoreY = readOneNumber(TextFieldEighth);
                thirdViewController.variantThatChecked = 3;
            }
            
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            makeVisibleTextFields();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        public void makeVisibleTextFields()
        {
            determineVariant();
            if (firstVariantChecked)
            {
                edit(LabelFirst, TextFieldFirst, "x: ");
                edit(LabelSecond, TextFieldSecond, "y: ");
                amountOfFields = 2;
            }
            else if (secondVarintChecked)
            {
                edit(LabelFirst, TextFieldFirst, "Covariance(x,y): ");
                edit(LabelThird, TextFieldThird, "Sx: ");
                edit(LabelFourth, TextFieldFourth, "Sy: ");
                edit(LabelFifth, TextFieldFifth, "Mean x: ");
                edit(LabelSixth, TextFieldSixth, "Mean y: ");
                amountOfFields = 5;
            }
            if (thirdVariandChecked)
            {
                edit(LabelFirst, TextFieldFirst, "Amount: ");
                edit(LabelThird, TextFieldThird, "Sx: ");
                edit(LabelFourth, TextFieldFourth, "Sy: ");
                edit(LabelFifth, TextFieldFifth, "Mean x: ");
                edit(LabelSixth, TextFieldSixth, "Mean y: ");
                edit(LabelSeventh, TextFieldSeventh, "Z-score x: ");
                edit(LabelEighth, TextFieldEighth, "Z-score y: ");
                amountOfFields = 7;
            }
            
        }

        private void determineVariant()
        {
            firstVariantChecked = false;
            secondVarintChecked = false;
            thirdVariandChecked = false;
            if (XYIsChecked)
            {
                firstVariantChecked = true;
                return;
            }
            if (CovIsChecked && StandDevIsChecked && MeanIsChecked)
            {
                secondVarintChecked = true;
                return;
            }
            thirdVariandChecked = true;
        }

        private void edit(UILabel label, UITextField field, string name) 
        {
            label.Text = name;
            label.Hidden = false;
            field.Hidden = false;
        }

        public double[] readData(UITextField textField)
        {
            string[] array = textField.Text.Trim().Split(" ");
            double[] numbers = array.Select(x => TryParseInTextField(x)).ToArray();
            numbers = numbers.Where(x => Math.Abs(x - int.MinValue) > 0.1).ToArray();
            return numbers;
        }

        public double readOneNumber(UITextField textField)
        {
            string[] array = textField.Text.Trim().Split(" ");
            double[] numbers = array.Select(x => TryParseInTextField(x)).ToArray();
            numbers = numbers.Where(x => Math.Abs(x - int.MinValue) > 0.1).ToArray();
            if (numbers.Length>1)
            {
                LabelMessage.Text = "More than one value is entered in one of the fields. " +
                        "The first value will be applied.";
                LabelMessage.TextColor = UIColor.SystemRedColor;
                textField.Text = numbers[0].ToString();
            }
            return numbers[0];
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

