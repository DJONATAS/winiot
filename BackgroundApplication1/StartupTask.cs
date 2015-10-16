using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using Windows.ApplicationModel.Background;
using Windows.Devices.Gpio;
using Windows.UI.Xaml;
using System.Net;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

// The Background Application template is documented at http://go.microsoft.com/fwlink/?LinkID=533884&clcid=0x409

namespace BackgroundApplication1
{
    public sealed class StartupTask : IBackgroundTask
    {
        private GpioPin sirene;
        private GpioPin lampada;
        private GpioPin tomada;
        private GpioPin led;


        private string LampadaResult;
        private string SireneResult;
        private string TomadaResult;

        public void Run(IBackgroundTaskInstance taskInstance)
        {
            initGPIO();

            while (true)
            {
                RequestLampada();
                RequestSirene();
                RequestTomada();
            }

        }

        #region Lampada
        private async void RequestLampada()
        {
            var result = Task.Run(() => GetResponseLampada()).Result;

            if (result != LampadaResult)
            {
                if (result.Contains("0"))
                {
                    lampada.Write(GpioPinValue.High);
                }
                else
                {
                    lampada.Write(GpioPinValue.Low);
                }
            }

        }

        private async Task<string> GetResponseLampada()
        {
            var httpClient = new HttpClient();

            var response = await httpClient.GetAsync("http://winiot.azurewebsites.net/api/Lampada");
            var contents = await response.Content.ReadAsStringAsync();

            return contents;
        }
        #endregion


        #region Sirene
        private async void RequestSirene()
        {
            var result = Task.Run(() => GetResponseSirene()).Result;

            if (result != SireneResult)
            {
                if (result.Contains("0"))
                {
                    sirene.Write(GpioPinValue.High);
                }
                else
                {
                    sirene.Write(GpioPinValue.Low);
                }
            }

        }

        private async Task<string> GetResponseSirene()
        {
            var httpClient = new HttpClient();

            var response = await httpClient.GetAsync("http://winiot.azurewebsites.net/api/Sirene");
            var contents = await response.Content.ReadAsStringAsync();

            return contents;
        }
        #endregion


        #region Tomada
        private async void RequestTomada()
        {
            var result = Task.Run(() => GetResponseTomada()).Result;

            if (result != TomadaResult)
            {
                if (result.Contains("0"))
                {
                    tomada.Write(GpioPinValue.High);
                }
                else
                {
                    tomada.Write(GpioPinValue.Low);
                }
            }

        }

        private async Task<string> GetResponseTomada()
        {
            var httpClient = new HttpClient();

            var response = await httpClient.GetAsync("http://winiot.azurewebsites.net/api/Tomada");
            var contents = await response.Content.ReadAsStringAsync();

            return contents;
        }
        #endregion

        private void initGPIO()
        {
            var gpio = GpioController.GetDefault();

            sirene = gpio.OpenPin(18);
            sirene.SetDriveMode(GpioPinDriveMode.Output);

            sirene.Write(GpioPinValue.Low);
            sirene.Write(GpioPinValue.High);
            
            lampada = gpio.OpenPin(26);
            lampada.SetDriveMode(GpioPinDriveMode.Output);

            tomada = gpio.OpenPin(16);
            tomada.SetDriveMode(GpioPinDriveMode.Output);

            led = gpio.OpenPin(24);
            led.SetDriveMode(GpioPinDriveMode.Output);
            led.Write(GpioPinValue.Low);
        }

    }
}
