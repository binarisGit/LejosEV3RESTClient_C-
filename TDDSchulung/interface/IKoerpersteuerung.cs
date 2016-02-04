namespace TDDSchulung
{
    public interface IKoerpersteuerung
    {
        void laufeStrecke(double zuLaufendeDistanz);
        double getGelaufeneDistanz();
        Color sehe();
        void stoppe();
        void drehe(int winkel);
        void rufe(bool beepOrBuzz);
    }
}