namespace kontenery;

public class KontenerGaz : Kontener, IHazardNotifier
{
    public double cisnienie { get; set; }
    
    public KontenerGaz(double wysokosc, double masaKontener, double glebokosc, double maxLadownosc, double cisnienie) : base(wysokosc, masaKontener, glebokosc, maxLadownosc)
    {
        this.cisnienie = cisnienie;
        numer_seryjny = $"KON-G-{index++}";
        
    }


    public override void oproznienie(Statek statek)
    {
        double zapamietana_masa = masa_ladunek * 0.05;
        base.oproznienie(statek);
        masa_ladunek += zapamietana_masa;
    }

    public override void zaladowanie(double masa, Statek statek)
    {
        base.zaladowanie(masa, statek);
    }

    public void Notify()
    {
        Console.WriteLine($"NIEBEZPIECZENSTGW DLA : KON-P-{index}");
    }

    public override void info()
    {
        base.info();
        Console.WriteLine($"- cisnienie: {cisnienie} kg");
    }
}