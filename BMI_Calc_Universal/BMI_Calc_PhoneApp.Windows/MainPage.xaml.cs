using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using BMI_Calc_PhoneApp.Classes;
using System.Text.RegularExpressions;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace BMI_Calc_PhoneApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            if (chkConvert.IsChecked == true)
            {
                lblWeightDesc.Text = "Kilograms";
                lblHeight1Desc.Text = "Meters";
                lblHeight2Desc.Text = "Centimeters";
            }
            else
            {
                lblWeightDesc.Text = "Pounds";
                lblHeight1Desc.Text = "Feet";
                lblHeight2Desc.Text = "Inches";
            }
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                lblBMINumber.Text = "";
                lblBMIDescription.Text = "";

                BMICalc yourBMI = new BMICalc(txtHeight1.Text, txtHeight2.Text, txtWeight.Text, chkConvert.IsChecked);


                lblBMINumber.Text = yourBMI.Result;

                lblBMIDescription.Text = yourBMI.ResultDesc;

                lblResults.Visibility = Visibility.Visible;
                lblBMINumber.Visibility = Visibility.Visible;
                lblBMIDescription.Visibility = Visibility.Visible;

            }
            catch (Exception se)
            {
                lblResults.Visibility = Visibility.Visible;
                lblBMINumber.Visibility = Visibility.Visible;
                lblBMINumber.Text = se.Message;
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtHeight1.Text = "";
            txtHeight2.Text = "";
            txtWeight.Text = "";
            lblBMIDescription.Text = "";
            lblBMINumber.Text = "";

            lblResults.Visibility = Visibility.Collapsed;
            lblBMINumber.Visibility = Visibility.Collapsed;
            lblBMIDescription.Visibility = Visibility.Collapsed;
        }

        private void chkConvert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Regex rgx = new Regex(@"^\d+.?\d*$");

                if (chkConvert.IsChecked == true)
                {
                    lblWeightDesc.Text = "Kilograms";
                    lblHeight1Desc.Text = "Meters";
                    lblHeight2Desc.Text = "Centimeters";

                    if (rgx.IsMatch(txtWeight.Text))
                    {
                        txtWeight.Text = Convert.ToString(Math.Round(Convert.ToDouble(txtWeight.Text) / 2.2046, 3));
                    }

                    if (rgx.IsMatch(txtHeight1.Text))
                    {
                        txtHeight1.Text = Convert.ToString(Math.Round(Convert.ToDouble(txtHeight1.Text) / 3.2808, 3));
                    }

                    if (rgx.IsMatch(txtHeight2.Text))
                    {
                        txtHeight2.Text = Convert.ToString(Math.Round(Convert.ToDouble(txtHeight2.Text) * 2.54, 3));
                    }
                }
                else
                {
                    lblWeightDesc.Text = "Pounds";
                    lblHeight1Desc.Text = "Feet";
                    lblHeight2Desc.Text = "Inches";

                    if (rgx.IsMatch(txtWeight.Text))
                    {
                        txtWeight.Text = Convert.ToString(Math.Round(Convert.ToDouble(txtWeight.Text) * 2.2046, 3));
                    }

                    if (rgx.IsMatch(txtHeight1.Text))
                    {
                        txtHeight1.Text = Convert.ToString(Math.Round(Convert.ToDouble(txtHeight1.Text) * 3.2808, 3));
                    }

                    if (rgx.IsMatch(txtHeight2.Text))
                    {
                        txtHeight2.Text = Convert.ToString(Math.Round(Convert.ToDouble(txtHeight2.Text) / 2.54, 3));
                    }
                }
            }
            catch
            {

            }
        }
    }
}
