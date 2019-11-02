using System;
using System.Collections.Generic;
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

        private double[] numbersX { set; get; }
        private double[] numbersY { set; get; }
        private double Cov { set; get; }
        private double Sx { set; get; }
        private double Sy { set; get; }
        private int amount { set; get; }
        private double ZScoreX { set; get; }
        private double ZScoreY { set; get; }
        private double MeanX { set; get; }
        private double MeanY { set; get; }

        private UITextField[] textFields { set; get; }
        private List<UITextField> visibleFields { set; get; }

        public SecondViewController(IntPtr handle) : base(handle)
        {
            textFields = new UITextField[] { TextFieldFirst, TextFieldSecond, TextFieldThird, TextFieldFourth, TextFieldFifth, TextFieldSixth, TextFieldSeventh, TextFieldEighth };
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);
            var thirdViewController = segue.DestinationViewController as ThirdViewController;
            if (firstVariantChecked)
            {
                thirdViewController.numbersX = this.numbersX;
                thirdViewController.numbersY = this.numbersY;
                thirdViewController.variantThatChecked = 1;
            }
            else if (secondVarintChecked)
            {
                thirdViewController.Cov = this.Cov;
                thirdViewController.Sx = this.Sx;
                thirdViewController.Sy = this.Sy;
                thirdViewController.MeanX = this.MeanX;
                thirdViewController.MeanY = this.MeanY;
                thirdViewController.variantThatChecked = 2;

            }
            else if (thirdVariandChecked)
            {
                thirdViewController.amount = this.amount;
                thirdViewController.Sx = this.Sx;
                thirdViewController.Sy = this.Sy;
                thirdViewController.MeanX = this.MeanX;
                thirdViewController.MeanY = this.MeanY;
                thirdViewController.ZScoreX = this.ZScoreX;
                thirdViewController.ZScoreY = this.ZScoreY;
                thirdViewController.variantThatChecked = 3;
            }

        }

        

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            makeVisibleTextFields();
            bad("One or more fields is empty!");

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
            visibleFields = new List<UITextField>();
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
            visibleFields.Add(field);

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
            if (numbers.Length > 1)
            {
                LabelMessage.Text = "More than one value is entered in one of the fields. " +
                        "The first value will be applied.";
                LabelMessage.TextColor = UIColor.SystemRedColor;
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

        partial void forEditingAFields(UITextField sender)
        {

            bool empty = false;
            for (int i=0;i<visibleFields.Count;i++)
            {
                if (String.IsNullOrWhiteSpace(visibleFields[i].Text))
                {
                    empty = true;
                    break;
                }
            }
            if(empty)
            {
                bad("One or more fields is empty!");
            }
            else
            {
                good();

                if (firstVariantChecked)
                {
                    this.numbersX = readData(TextFieldFirst);
                    this.numbersY = readData(TextFieldSecond);
                    if (numbersX.Length!=numbersY.Length)
                    {
                        bad("The amount of numbers in the series is not the same");
                    }
                }
                else if (secondVarintChecked)
                {
                    this.Cov = readOneNumber(TextFieldFirst);
                    this.Sx = readOneNumber(TextFieldThird);
                    this.Sy = readOneNumber(TextFieldFourth);
                    this.MeanX = readOneNumber(TextFieldFifth);
                    this.MeanY = readOneNumber(TextFieldSixth);

                }
                else if (thirdVariandChecked)
                {
                    this.amount = Convert.ToInt32(readOneNumber(TextFieldFirst));
                    this.Sx = readOneNumber(TextFieldThird);
                    this.Sy = readOneNumber(TextFieldFourth);
                    this.MeanX = readOneNumber(TextFieldFifth);
                    this.MeanY = readOneNumber(TextFieldSixth);
                    this.ZScoreX = readOneNumber(TextFieldSeventh);
                    this.ZScoreY = readOneNumber(TextFieldEighth);
                }
            }
        }

        public void good()
        {
            LabelMessage.Text = "Everything is good!";
            LabelMessage.TextColor = UIColor.SystemGreenColor;
            ButtonSubmit.Enabled = true;
        }

        public void bad(string message)
        {
            LabelMessage.Text = message;
            LabelMessage.TextColor = UIColor.SystemRedColor;
            ButtonSubmit.Enabled = false;
        }
    }
}

