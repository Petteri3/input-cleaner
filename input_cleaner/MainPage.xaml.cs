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
using System.Diagnostics;
using Windows.ApplicationModel.DataTransfer;

// Petteri M. 20222

namespace input_cleaner
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

        }

        // siivotaan stringistä väärät merkit ja palautetaan siivottu string
        public string Cleaninput(string _input)
        {
            string[] forbiddenChars = { "<", ">", ".", "+", "\\", "/", "@", "=", "{", "}", "\""};

            for (int i = 0; i < forbiddenChars.Length; i++)
            {
                _input = _input.Replace(forbiddenChars[i], "");
            }
            return _input;
        }

        private void nappiClicked(object sender, RoutedEventArgs e)
        {
           
            string inputText = inputti.Text;
            string outputText = Cleaninput(inputText);

            outputtii.Text = "Teksti kopioitu leikepöydälle: " + outputText;

            // koodi napattu täältä: https://docs.microsoft.com/en-us/windows/uwp/app-to-app/copy-and-paste
            DataPackage dataPackage = new DataPackage();
            dataPackage.SetText(outputText);

            Clipboard.SetContent(dataPackage);

            Debug.WriteLine("copied to clipboard");
            
            
        }

    }
}
