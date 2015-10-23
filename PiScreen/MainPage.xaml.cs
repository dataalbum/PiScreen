using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PiScreen
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            // Setup clock
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += timer_Tick;
            timer.Start();

            //Setup Time Picker for 24h format
            TimePicker timePicker1 = new TimePicker();
            timePicker1.ClockIdentifier = Windows.Globalization.ClockIdentifiers.TwentyFourHour;

        }
        void timer_Tick(object sender, object e)
        {
            DateTime dt = DateTime.Now;

            textBlockDate.Text = dt.ToString("dddd MMMM dd, yyyy");
            textBlockTime.Text = dt.ToString("HH:mm");
            textBlockSecond.Text = dt.ToString("ss");

            //Alarm
            if (toggleSwitch.IsOn == true)
            {
                DateTime alarmDt = Convert.ToDateTime(textBoxAlarm.Text);

                if (dt >= alarmDt)
                {
                    textBlockAlarm.Text = "Alarm!";
                }
            }
            else
            {
                textBlockAlarm.Text = "No Alarm.";
            }
        }
        private void timePicker_TimeChanged(object sender, TimePickerValueChangedEventArgs e)
        {
            textBoxAlarm.Text = e.NewTime.ToString();
        }
    }
}
