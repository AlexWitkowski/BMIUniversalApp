using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Popups;

namespace BMI_Calc_PhoneApp.Classes
{
    class BMICalc
    {
        string height1;
        string height2;
        string weight;
        bool? isImperial;
        string result;
        string resultDesc;

        public BMICalc(string BMIHeight1, string BMIHeight2, string BMIWeight, bool? BMIIsImperial)
        {
            
                this.height1 = BMIHeight1;
                this.height2 = BMIHeight2;
                this.weight = BMIWeight;
                this.isImperial = BMIIsImperial;
            try
            {
                if (weight == "")
                {
                    weight = "0";
                }
                if (height1 == "")
                {
                    height1 = "0";
                }
                if (height2 == "")
                {
                    height2 = "0";
                }

                double dubWeight;
                double dubHeight;
                double dubResult;

                if (isImperial == true)
                {
                    dubWeight = (Convert.ToDouble(weight));
                    dubHeight = (Convert.ToDouble(height1) + (Convert.ToDouble(height2) / 100));
                }
                else
                {
                    dubWeight = (Convert.ToDouble(weight) / 2.2046);
                    dubHeight = ((((Convert.ToDouble(height1) * 12) + (Convert.ToDouble(height2))) * 2.54) / 100);
                }

                dubResult = Math.Round((dubWeight / (Math.Pow(dubHeight, 2))), 3);
                this.result = dubResult.ToString();

                if (dubResult < 15)
                {
                    this.resultDesc = "Very Severly Underweight";
                }
                else if (dubResult >= 15 && dubResult < 16)
                {
                    this.resultDesc = "Severly Underweight";
                }
                else if (dubResult >= 16 && dubResult < 18.5)
                {
                    this.resultDesc = "Underweight";
                }
                else if (dubResult >= 18.5 && dubResult < 25)
                {
                    this.resultDesc = "Normal (Healthy Weight)";
                }
                else if (dubResult >= 25 && dubResult < 30)
                {
                    this.resultDesc = "Overweight";
                }
                else if (dubResult >= 30 && dubResult < 35)
                {
                    this.resultDesc = "Obese Class 1 (Moderately Obese)";
                }
                else if (dubResult >= 35 && dubResult < 40)
                {
                    this.resultDesc = "Obese Class 2 (Severly Obese)";
                }
                else if (dubResult >= 40)
                {
                    this.resultDesc = "Obese Class 3 (Very Severly Obese)";
                }
                else
                {
                    this.resultDesc = "An Error has Occured.";
                    this.result = "result is not a number.";
                }
            }
            catch (Exception se)
            {
                this.result = se.Message;
                this.resultDesc = "An Error has Occured.";
            }   
        }
        public string Result { get { return result; } }
        public string ResultDesc { get { return resultDesc; } }

    }
}
