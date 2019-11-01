using Foundation;
using System;
using UIKit;

namespace ChoiceApp
{
    public partial class ViewController : UIViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            SwitchXY.On = false;
            SwitchCov.On = false;
            SwitchStandDev.On = false;
            SwitchAmount.On = false;
            SwitchZScore.On = false;
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

        partial void UISwitch202_TouchUpInside(UISwitch sender)
        {
            if(SwitchXY.On)
            {
                SwitchCov.On = false;
            }
            else
            {
                SwitchCov.On = true;
            }
        }
    }
}