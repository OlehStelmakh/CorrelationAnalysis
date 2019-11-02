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
                LabelFirst.Text = "X: ";
                LabelFirst.Hidden = false;
                TextFieldFirst.Hidden = false;

                LabelSecond.Text = "Y: ";
                LabelSecond.Hidden = false;
                TextFieldSecond.Hidden = false;
            }
            else if (secondVarintChecked)
            {
                LabelFirst.Text = "Covariance(X,Y): ";
                LabelFirst.Hidden = false;
                TextFieldFirst.Hidden = false;

                LabelThird.Text = "Sx: ";
                LabelThird.Hidden = false;
                TextFieldThird.Hidden = false;

                LabelFourth.Text = "Sy: ";
                LabelFourth.Hidden = false;
                TextFieldFourth.Hidden = false;

                LabelFifth.Text = "Mean x: ";
                LabelFifth.Hidden = false;
                TextFieldFifth.Hidden = false;

                LabelSixth.Text = "Mean y: ";
                LabelSixth.Hidden = false;
                TextFieldSixth.Hidden = false;
            }
            else
            {
                LabelFirst.Text = "Amount: ";
                LabelFirst.Hidden = false;
                TextFieldFirst.Hidden = false;

                LabelThird.Text = "Sx: ";
                LabelThird.Hidden = false;
                TextFieldThird.Hidden = false;

                LabelFourth.Text = "Sy: ";
                LabelFourth.Hidden = false;
                TextFieldFourth.Hidden = false;

                LabelFifth.Text = "Mean x: ";
                LabelFifth.Hidden = false;
                TextFieldFifth.Hidden = false;

                LabelSixth.Text = "Mean y: ";
                LabelSixth.Hidden = false;
                TextFieldSixth.Hidden = false;

                LabelSeventh.Text = "Z-score x: ";
                LabelSeventh.Hidden = false;
                TextFieldSeventh.Hidden = false;

                LabelEighth.Text = "Z-score y: ";
                LabelEighth.Hidden = false;
                TextFieldEighth.Hidden = false;
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
    }
}

