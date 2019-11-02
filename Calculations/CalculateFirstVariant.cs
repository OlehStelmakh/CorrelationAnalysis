using System;
using UIKit;

namespace ChoiceApp.Calculations
{
    public static class CalculateFirstVariant
    {

        public static double Mean(double[] array, UILabel label, string coord)
        {
            double mean = 0;
            double amountOf = array.Length;
            double sumOf = 0;
            foreach (double num in array)
            {
                sumOf += num;
            }
            mean = sumOf / amountOf;
            label.Hidden = false;
            label.Text = $"Mean of {coord}: {Math.Round(mean, 5)}";
            return mean;
        }

        public static double correlCoef(UILabel label, double[] arrayX, double[] arrayY, double meanX, double meanY)
        {
            double numerator = 0;
            double quadrateX = 0;
            double quadrateY = 0;
            for (int i = 0; i < arrayX.Length; i++)
            {
                numerator += (arrayX[i] - meanX) * (arrayY[i] - meanY);
            }
            for (int i = 0; i < arrayX.Length; i++)
            {
                quadrateX += (arrayX[i] - meanX) * (arrayX[i] - meanX);
                quadrateY += (arrayY[i] - meanY) * (arrayY[i] - meanY);
            }
            double denominator = Math.Sqrt(quadrateX * quadrateY);
            double r = numerator / denominator;
            label.Hidden = false;
            label.Text = $"Correlation coef: {Math.Round(r, 5)}";
            return r;
        }

        public static double RSQ(UILabel label, double r)
        {
            label.Hidden = false;
            double rsq = r * r;
            label.Text = $"R-sq: {Math.Round(rsq, 5)}";
            return rsq;
        }

        
        public static double findB1XonY(UILabel label, double[] arrayX, double[] arrayY, double meanX, double meanY)
        {
            double covXY = 0;
            for (int i = 0; i < arrayX.Length; i++)
            {
                covXY += (arrayX[i] - meanX) * (arrayY[i] - meanY);
            }
            covXY = covXY / arrayX.Length;
            double varY = 0;
            for (int i = 0; i < arrayY.Length; i++)
            {
                varY += arrayY[i] * arrayY[i];
            }
            varY = varY / arrayY.Length - meanY * meanY;
            double b1 = covXY / varY;
            label.Text = $"b1: {Math.Round(b1, 4)}";
            label.Hidden = false;
            return b1;
        }

            public static double findB1YonX(UILabel label, double[] arrayX, double[] arrayY, double meanX, double meanY)
        {
            double covXY = 0;
            for (int i = 0; i < arrayX.Length; i++)
            {
                covXY += (arrayX[i] - meanX) * (arrayY[i] - meanY);
            }
            covXY = covXY / arrayX.Length;
            double varX = 0;
            for (int i = 0; i < arrayX.Length; i++)
            {
                varX += arrayX[i] * arrayX[i];
            }
            varX = varX / arrayY.Length - meanX * meanX;
            double b1 = covXY / varX;
            label.Text = $"b1: {Math.Round(b1,4)}";
            label.Hidden = false;
            return b1;
        }

        public static double findB0(UILabel label, double mean1, double mean2, double b1)
        {
            double b0 = mean1 - b1 * mean2;
            label.Text += $"  b0: {Math.Round(b0,4)}";
            return b0;
        }

        public static void lineYonX(UILabel label, double b1, double b0)
        {
            string regLine = $"y={Math.Round(b0, 2)}+({Math.Round(b1, 2)})×x"; //TODO покращити вигляд
            label.Hidden = false;
            label.Text = $"Y on X: {regLine}";
        }

        public static void lineXonY(UILabel label, double b1, double b0)
        {
            string regLine = $"x={Math.Round(b0, 2)}+({Math.Round(b1, 2)})×y"; //TODO покращити вигляд
            label.Hidden = false;
            label.Text = $"X on Y: {regLine}";
        }

    }
}
