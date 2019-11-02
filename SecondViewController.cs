using System;
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
       

        public SecondViewController(IntPtr handle) : base(handle)
        {
            
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
            }
            else if (secondVarintChecked)
            {
                edit(LabelFirst, TextFieldFirst, "Covariance(x,y): ");
                edit(LabelThird, TextFieldThird, "Sx: ");
                edit(LabelFourth, TextFieldFourth, "Sy: ");
                edit(LabelFifth, TextFieldFifth, "Mean x: ");
                edit(LabelSixth, TextFieldSixth, "Mean y: ");
            }
            else
            {
                edit(LabelFirst, TextFieldFirst, "Amount: ");
                edit(LabelThird, TextFieldThird, "Sx: ");
                edit(LabelFourth, TextFieldFourth, "Sy: ");
                edit(LabelFifth, TextFieldFifth, "Mean x: ");
                edit(LabelSixth, TextFieldSixth, "Mean y: ");
                edit(LabelSeventh, TextFieldSeventh, "Z-score x: ");
                edit(LabelEighth, TextFieldEighth, "Z-score y: ");
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
    }
}

