using System;
using UIKit;

namespace ChoiceApp.Calculations
{
    public class CalculateSecondVariant
    {
        public static double correlCoef(UILabel label, double covXY, double standDevX, double standDevY)
        {
            double r = covXY / (standDevX * standDevY);
            label.Hidden = false;
            label.Text = $"Correl coef: {Math.Round(r, 3)}  ";
            return r;
        }

        public static double findB1YonX(UILabel label, double r, double standDevX, double standDevY)
        {
            double b1 = r * (standDevY / standDevX);
            label.Hidden = false;
            label.Text = $"b1: {Math.Round(b1, 3)}";
            return b1;
        }

        public static double findB0(UILabel label, double b1, double mean1, double mean2)
        {
            double b0 = mean1 - b1 * mean2;
            label.Text += $"  b0: {Math.Round(b0, 4)}";
            return b0;
        }

        public static double RSQ(UILabel label, double r)
        {
            double rsq = r * r;
            label.Hidden = false;
            label.Text = $"RSQ: {Math.Round(rsq, 3)}";
            return rsq;
        }
    }
}
