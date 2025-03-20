namespace kontenery;

public class KontenerPlyn : Kontener, IHazardNotifier
{
    public bool LadunekNiebezpieczny { get; set; }

    public KontenerPlyn(double wysokosc, double masaKontener, double glebokosc, double maxLadownosc, bool ladunekNiebezpieczny) : base(wysokosc, masaKontener, glebokosc, maxLadownosc)
    {
        LadunekNiebezpieczny = ladunekNiebezpieczny;
        numer_seryjny = $"KON-P-{index}";
    }

    public void Notify()
    {
        Console.WriteLine($"NIEBEZPIECZENSTGW DLA : KON-P-{index}");
    }

    public override void zaladowanie(double masa)
    {
        if (LadunekNiebezpieczny)
        {
            max_Ladownosc *= 0.50;
            if (masa > max_Ladownosc)
            {
                Notify();
            }
            else
            {
                masa_ladunek += masa;
            }
        }
        else
        {
            max_Ladownosc *= 0.9;
            if (masa > max_Ladownosc)
            {
                Notify();
            }
            else
            {
                masa_ladunek += masa;
            }
        }
    }
}