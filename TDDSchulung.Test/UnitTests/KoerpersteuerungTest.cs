using System;
using System.Net.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RichardSzalay.MockHttp;

namespace TDDSchulung.Test
{
    [TestClass]
    public class KoerpersteuerungTest
    {
        Uri baseUri = new Uri("http://10.0.0.44:8080/");
        MockHttpMessageHandler mockHttp;
        HttpClient client;
        
        IKoerpersteuerung koerpersteuerung;

        [TestInitialize]
        public void init()
        {
            mockHttp = new MockHttpMessageHandler();
            mockHttp.When("http://10.0.0.44:8080/*")
                    .Respond("application/json", "6");
            client = new HttpClient(mockHttp);
            client.BaseAddress = baseUri;
            koerpersteuerung = new Koerpersteuerung(client);
        }

        [TestMethod]
        public void laufe60cmVorwaerts()
        {
            koerpersteuerung.laufeStrecke(60.0);
            mockHttp.VerifyNoOutstandingExpectation();
        }

        
        [TestMethod]
        public void sehe()
        {            
            Color color = koerpersteuerung.sehe();
            Assert.AreEqual(Color.Weiss, color);
            mockHttp.VerifyNoOutstandingExpectation();
        }

        [TestMethod]
        public void dreheNachRechts()
        {
            koerpersteuerung.drehe(-90);
            mockHttp.VerifyNoOutstandingExpectation();
        }

        [TestMethod]
        public void rufenBeep()
        {
            koerpersteuerung.rufe(true);
            mockHttp.VerifyNoOutstandingExpectation();
        }
    }
}
