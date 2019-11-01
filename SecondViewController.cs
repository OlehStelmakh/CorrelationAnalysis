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
        public bool firstIsChecked { set; get; }
        public bool secondIsChecked { set; get; }
        public bool thirdIsChecked { set; get; }
        public bool fourthIsChecked { set; get; }
        public bool fifthIsChecked { set; get; }
       

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
            bool[] checkedOrNot = { firstIsChecked, secondIsChecked, thirdIsChecked, fourthIsChecked, fifthIsChecked };
            UITextField[] textFields = { TextFieldFirst, TextFieldSecond, TextFieldThird, TextFieldFourth, TextFieldFifth, TextFieldSixth };
            int counter = 0;
            for (int i =0; i<checkedOrNot.Length; i++) 
            {
                if (checkedOrNot[i] && (i == 1 || i == 3)) { counter++; }
                else { counter += 2; }
            }

        }
    }
}

