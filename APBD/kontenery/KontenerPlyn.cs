namespace kontenery;

public class KontenerPlyn : Kontener
{
    public bool LadunekNiebezpieczny { get; set; }

    public KontenerPlyn(double masaLadunek, double wysokosc, double masaKontener, double glebokosc, double maxLadownosc, bool ladunekNiebezpieczny) : base(masaLadunek, wysokosc, masaKontener, glebokosc, maxLadownosc)
    {
        LadunekNiebezpieczny = ladunekNiebezpieczny;
        numer_seryjny = $"KON-P-{index}";
    }
}