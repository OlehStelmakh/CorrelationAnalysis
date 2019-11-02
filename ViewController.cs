using Foundation;
using System;
using UIKit;

namespace ChoiceApp
{
    public partial class ViewController : UIViewController
    {
        private bool accessForNext = false;

        public ViewController(IntPtr handle) : base(handle)
        {
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

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);
            var secondViewController = segue.DestinationViewController as SecondViewController;
            secondViewController.firstIsChecked = SwitchXY.On;
            secondViewController.secondIsChecked = SwitchCov.On;
            secondViewController.thirdIsChecked = SwitchStandDev.On;
            secondViewController.fourthIsChecked = SwitchAmount.On;
            secondViewController.fifthIsChecked = SwitchZScore.On;
        }

        //додати події

        partial void UIButton205_TouchUpInside(UIButton sender)
        {
          
        }

        //X and Y fields
        partial void UISwitch202_TouchUpInside(UISwitch sender)
        {
            if(SwitchXY.On)
            {
                SwitchCov.On = false;
                SwitchAmount.On = false;
                SwitchMean.On = false;
                SwitchStandDev.On = false;
                SwitchZScore.On = false;
                sufficient();
            }
            else { notSufficient(); }


        }

        //Cov
        partial void UISwitch203_TouchUpInside(UISwitch sender)
        {
            if (SwitchCov.On)
            {
                SwitchXY.On = false;
                SwitchZScore.On = false;
                SwitchAmount.On = false;
                SwitchMean.On = true;
                SwitchStandDev.On = true;
                sufficient();
            }
            else { notSufficient(); }

        }

        //Z-score
        partial void UISwitch2659_TouchUpInside(UISwitch sender)
        {
            if (SwitchZScore.On)
            {
                SwitchXY.On = false;
                SwitchCov.On = false;
                SwitchAmount.On = true;
                SwitchStandDev.On = true;
                SwitchMean.On = true;
                sufficient();

            }
            else
            {
                SwitchAmount.On = false;
                notSufficient();
            }
          
        }

        //Amount
        partial void UISwitch2658_TouchUpInside(UISwitch sender)
        {
            if (SwitchAmount.On)
            {
                SwitchXY.On = false;
                SwitchCov.On = false;
                SwitchZScore.On = true;
                SwitchStandDev.On = true;
                SwitchMean.On = true;
                accessForNext = true;
                sufficient();
            }
            else
            {
                SwitchZScore.On = false;
                notSufficient();
            }
           
            

        }

        private void notSufficient()
        {
            LabelSufficient.TextColor = UIColor.SystemRedColor;
            LabelSufficient.Text = "This information is not sufficient for calculations";
            LabelSufficient.Hidden = false;
            ButtonFirstView.Enabled = false;
        }

        private void sufficient()
        {
            LabelSufficient.Text = "This information is sufficient for calculations";
            LabelSufficient.TextColor = UIColor.SystemGreenColor;
            LabelSufficient.Hidden = false;
            ButtonFirstView.Enabled = true;
        }

        /*
        //Mean of X and Y
        partial void UISwitch16249_TouchUpInside(UISwitch sender)
        {
            if (SwitchMean.On)
            {
                SwitchXY.On = false;
                LabelSufficient.Hidden = true;
            }
            else
            {
                SwitchCov.On = false;
                SwitchStandDev.On = false;
                SwitchZScore.On = false;
                SwitchAmount.On = false;
                LabelSufficient.Hidden = true;
            }
        }

        //Standart dev
        partial void UISwitch2657_TouchUpInside(UISwitch sender)
        {
            if (SwitchStandDev.On)
            {
                SwitchXY.On = false;
                LabelSufficient.Hidden = true;
            }
            else
            {
                SwitchCov.On = false;
                SwitchMean.On = false;
                SwitchZScore.On = false;
                SwitchAmount.On = false;
                LabelSufficient.Hidden = true;
            }
        }
        */
    }
}