using System;
using System.Threading;

namespace TDDSchulung
{
    /// <summary>
    /// BaseballSpieler class needs IKoerpersteuerung interface and can do multiple things
    /// </summary>
    public class BaseballSpieler
    {
        private IKoerpersteuerung koerpersteuerung;
        Base currentBase = Base.HomeBase;

        public BaseballSpieler(IKoerpersteuerung koerpersteuerung)
        {
            this.koerpersteuerung = koerpersteuerung;
        }

        public void laufeStrecke(double zuLaufendeDistanz)
        {
            koerpersteuerung.laufeStrecke(zuLaufendeDistanz);
        }

        public double getGelaufeneDistanz()
        {
            return koerpersteuerung.getGelaufeneDistanz();
        }
        public void drehe(int winkel)
        {
            koerpersteuerung.drehe(winkel);
        }

        public void laufeZurNaechstenBase()
        {
            try
            {
                laufeStrecke(45.0);
                Thread.Sleep(800);
                while(koerpersteuerung.sehe() != Color.Rot)
                {                    
                    //warten
                }
                koerpersteuerung.stoppe();
                drehe(-90);
                currentBase = currentBase.getNextBase();
                Console.WriteLine(currentBase);
                koerpersteuerung.rufe(true);
            }
            catch (ThreadInterruptedException e)
            {
                Console.WriteLine(e);             
                Thread.CurrentThread.Interrupt();
            }
        }

        public void laufeHomeRun()
        {
            if (currentBase == Base.HomeBase)
            {
                do
                {
                    laufeZurNaechstenBase();
                } while (currentBase != Base.HomeBase);
            }
        }
    }
}