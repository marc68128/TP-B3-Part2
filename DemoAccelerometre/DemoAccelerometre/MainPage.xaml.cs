using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using DemoAccelerometre.Resources;
using Microsoft.Devices.Sensors;

namespace DemoAccelerometre
{
    public partial class MainPage : PhoneApplicationPage
    {
        private Accelerometer _accelerometer;
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            _accelerometer = new Accelerometer();
            _accelerometer.CurrentValueChanged += _accelerometer_ReadingChanged;
            _accelerometer.Start();

        }

        private void _accelerometer_ReadingChanged(object sender, SensorReadingEventArgs<AccelerometerReading> e)
        {
            Dispatcher.BeginInvoke(() =>
            {
                xValue.Text = e.SensorReading.Acceleration.X.ToString();
                yValue.Text = e.SensorReading.Acceleration.Y.ToString();
                zValue.Text = e.SensorReading.Acceleration.Z.ToString();
            });

        }


    }
}