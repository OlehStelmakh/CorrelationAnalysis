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
       

        public SecondViewController(IntPtr handle) : base(handle)
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

        public void makeVisibleTextFields()
        {
            bool[] checkedOrNot = { XYIsChecked, CovIsChecked, StandDevIsChecked, AmountIsChecked, ZScoreIsChecked, MeanIsChecked };
            UITextField[] textFields = { TextFieldFirst, TextFieldSecond, TextFieldThird, TextFieldFourth, TextFieldFifth, TextFieldSixth };
            int counter = 0;
            
        }
    }
}

