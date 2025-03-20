namespace kontenery;

public class KontenerGaz : Kontener, IHazardNotifier
{
    public double cisnienie { get; set; }

    public KontenerGaz(double wysokosc, double masaKontener, double glebokosc, double maxLadownosc, double cisnienie) : base(wysokosc, masaKontener, glebokosc, maxLadownosc)
    {
        this.cisnienie = cisnienie;
        numer_seryjny = $"KON-G-{index}";
    }


    public override void oproznienie()
    {
        double zapamietana_masa = masa_ladunek * 0.05;
        base.oproznienie();
        masa_ladunek += zapamietana_masa;
    }

    public override void zaladowanie(double masa)
    {
        base.zaladowanie(masa);
    }

    public void Notify()
    {
        throw new NotImplementedException();
    }
}