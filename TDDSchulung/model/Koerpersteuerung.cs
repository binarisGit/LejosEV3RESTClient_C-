using System;
using System.Net.Http;

namespace TDDSchulung
{
    /// <summary>
    /// Koerpersteuerung communicate with http to the REST Service of the robot
    /// http://www.dotnetperls.com/httpclient
    /// </summary>
    public class Koerpersteuerung : IKoerpersteuerung
    {
        HttpClient client;
        /// <summary>
        /// the Httpclient already has the BaseAddress
        /// </summary>
        /// <param name="client"></param>
        public Koerpersteuerung(HttpClient client)
        {
            this.client = client;
        }

        public void laufeStrecke(double zuLaufendeDistanz)
        {
            client.GetAsync("differentialpilot/run/" + zuLaufendeDistanz);
        }

        public double getGelaufeneDistanz()
        {
            HttpResponseMessage response = client.GetAsync("differentialpilot/getmovementincrement").Result;
            if (response.IsSuccessStatusCode)
            {
                return double.Parse(response.Content.ReadAsStringAsync().Result, System.Globalization.CultureInfo.InvariantCulture);
            }
            return 0.0;
        }

        public Color sehe()
        {
            int colorID = -1;
            HttpResponseMessage response = client.GetAsync("color/getcolor/").Result;
            if (response.IsSuccessStatusCode)
            {                
                colorID = int.Parse(response.Content.ReadAsStringAsync().Result);
                Console.WriteLine((Color)colorID);
            }
            return (Color)colorID;
        }

        public void stoppe()
        {
            client.GetAsync("differentialpilot/stop");
            Console.WriteLine("stoppe");
        }

        public async void drehe(int winkel)
        {
            await client.GetAsync("differentialpilot/rotate/" + winkel);
        }

        public void rufe(bool beepOrBuzz)
        {
            if (beepOrBuzz)
                client.GetAsync("sound/beep");
            else
                client.GetAsync("sound/buzz");

            Console.WriteLine("rufe");
        }
    }
}