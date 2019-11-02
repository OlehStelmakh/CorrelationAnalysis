using System;

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

        public ThirdViewController(IntPtr handle) : base(handle)
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
    }
}

