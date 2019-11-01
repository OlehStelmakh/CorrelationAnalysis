// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace ChoiceApp
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISwitch SwitchAmount { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISwitch SwitchCov { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISwitch SwitchStandDev { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISwitch SwitchXY { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISwitch SwitchZScore { get; set; }

        [Action ("UIButton205_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void UIButton205_TouchUpInside (UIKit.UIButton sender);

        [Action ("UISwitch202_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void UISwitch202_TouchUpInside (UIKit.UISwitch sender);

        void ReleaseDesignerOutlets ()
        {
            if (SwitchAmount != null) {
                SwitchAmount.Dispose ();
                SwitchAmount = null;
            }

            if (SwitchCov != null) {
                SwitchCov.Dispose ();
                SwitchCov = null;
            }

            if (SwitchStandDev != null) {
                SwitchStandDev.Dispose ();
                SwitchStandDev = null;
            }

            if (SwitchXY != null) {
                SwitchXY.Dispose ();
                SwitchXY = null;
            }

            if (SwitchZScore != null) {
                SwitchZScore.Dispose ();
                SwitchZScore = null;
            }
        }
    }
}