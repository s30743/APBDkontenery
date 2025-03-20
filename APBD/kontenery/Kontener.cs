namespace kontenery;

public class Kontener
{
    protected double masa_ladunek;
    public double wysokosc { get; set; }
    public double masa_kontener { get; set; }
    public double glebokosc { get; set; }
    public double max_Ladownosc { get; set; }
    public string numer_seryjny { get; set; }
    public static int index = 0;


    public Kontener(double wysokosc, double masaKontener, double glebokosc, double maxLadownosc)
    {
        this.wysokosc = wysokosc;
        masa_kontener = masaKontener;
        this.glebokosc = glebokosc;
        max_Ladownosc = maxLadownosc;
        index++;
        
    }

    public virtual void oproznienie()
    {
        if (masa_ladunek != 0)
        {
            masa_ladunek = 0;
        }
        
    }

    public virtual void zaladowanie(double masa)
    {
        masa_ladunek += masa;
        if (masa_ladunek > max_Ladownosc)
        {
            throw new OverFillException(
                $"OBECNA MASA ŁADUNKU PO ZAŁADOWANIU DLA {numer_seryjny} JEST WIĘKSZA NIŻ JEGO POJEMNOŚĆ");
        }
    }
}