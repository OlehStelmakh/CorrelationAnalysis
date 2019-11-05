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
    [Register ("FourthViewController")]
    partial class FourthViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel LabelAnswer { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel LabelLinear { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel LabelMainInfo { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISwitch SwitchExp { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISwitch SwitchLinear { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISwitch SwitchPower { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (LabelAnswer != null) {
                LabelAnswer.Dispose ();
                LabelAnswer = null;
            }

            if (LabelLinear != null) {
                LabelLinear.Dispose ();
                LabelLinear = null;
            }

            if (LabelMainInfo != null) {
                LabelMainInfo.Dispose ();
                LabelMainInfo = null;
            }

            if (SwitchExp != null) {
                SwitchExp.Dispose ();
                SwitchExp = null;
            }

            if (SwitchLinear != null) {
                SwitchLinear.Dispose ();
                SwitchLinear = null;
            }

            if (SwitchPower != null) {
                SwitchPower.Dispose ();
                SwitchPower = null;
            }
        }
    }
}