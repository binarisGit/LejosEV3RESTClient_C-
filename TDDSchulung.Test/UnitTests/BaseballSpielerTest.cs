using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace TDDSchulung.Test
{
    /// <summary>
    /// Unit tests of the BaseballSpieler.cs
    /// </summary>
    [TestClass]
    public class BaseballSpielerTest
    {
        /// <summary>
        /// using Mock from the Moq Framework to have an Object from the IKoerpersteuerung interface
        /// needed to initiliaze the BaseballSpieler object and to verify actions in the interface
        /// http://www.developerhandbook.com/unit-testing/writing-unit-tests-with-nunit-and-moq/
        /// </summary>
        Mock<IKoerpersteuerung> koMock;
        IKoerpersteuerung koerpersteuerung;
        BaseballSpieler harald;

        [TestInitialize]
        public void init()
        {
            koMock = new Mock<IKoerpersteuerung>();
            koerpersteuerung = koMock.Object;
            harald = new BaseballSpieler(koerpersteuerung);
        }

        /// <summary>
        /// basis test to let the robot walk 60cm
        /// </summary>
        [TestMethod]
        public void BaseballSpieler_laufe60cmVorwaerts()
        {
            //since the mocked koerpersteuerung interface doesn't have any code, here is setup that the function "getGelaufeneDistanz" always response 60.0
            koMock.Setup(krprstrng => krprstrng.getGelaufeneDistanz()).Returns(60.0);
            harald.laufeStrecke(60.0);
            //verify that the function "laufeStrecke(60.0) was called 1 time
            koMock.Verify(krprstrng => krprstrng.laufeStrecke(60.0));
            //if the "getGelaufeDistanz" is != 60.0 (not possible since we say it always answers 60.0) the robot didn't walk the wanted distance          
            Assert.AreEqual(60.0, harald.getGelaufeneDistanz(), "Falsche Distanz gelaufen");
            //could also verify that the BaseballSpieler.getGelaufeneDistanz needs the koerpersteuerung.getGelaufeneDistanz
            //koMock.Verify(Koerpersteuerung => Koerpersteuerung.getGelaufeneDistanz());
        }

        [TestMethod]
        public void BaseballSpieler_drehe90gradRechts()
        {
            harald.drehe(-90);
            koMock.Verify(krprstrng => krprstrng.drehe(-90), Times.Exactly(1));
        }

        [TestMethod]
        public void BaseballSpieler_laufeZurNaechstenBase()
        {
            koMock.Setup(krprstrng => krprstrng.sehe()).Returns(Color.Rot);
            harald.laufeZurNaechstenBase();
            koMock.Verify(krprstrng => krprstrng.sehe(), Times.Exactly(1));
            koMock.Verify(krprstrng => krprstrng.rufe(true), Times.AtLeastOnce());
        }

        [TestMethod]
        public void BaseballSpieler_laufeHomeRun()
        {
            koMock.Setup(krprstrng => krprstrng.sehe()).Returns(Color.Rot);
            harald.laufeHomeRun();
            koMock.Verify(krprstrng => krprstrng.laufeStrecke(45), Times.Exactly(4));
            koMock.Verify(krprstrng => krprstrng.drehe(-90), Times.Exactly(4));
        }
    }
}
