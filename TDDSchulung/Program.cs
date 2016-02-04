using System;
using System.Net.Http;

namespace TDDSchulung
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://10.0.0.44:8080/");

            IKoerpersteuerung koerpersteuerung = new Koerpersteuerung(client);
            BaseballSpieler harald = new BaseballSpieler(koerpersteuerung);

            harald.laufeStrecke(1.0);
            //Console.WriteLine(harald.getGelaufeneDistanz());

            //harald.laufeZurNaechstenBase();
            //harald.laufeHomeRun();
            Console.Read();
        }
    }
}
