namespace kontenery;

public class Kontener
{
    public double masa_ladunek {
        get;
        set;
    }
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
        masa_ladunek = 0;
        numer_seryjny = "";

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
        try
        {
            

            if (masa_ladunek + masa > max_Ladownosc)
            {
                throw new OverFillException(
                    $"OBECNA MASA ŁADUNKU PO ZAŁADOWANIU DLA {numer_seryjny} JEST WIĘKSZA NIŻ JEGO POJEMNOŚĆ");
            } 
            masa_ladunek += masa;
            
        }
        catch (OverFillException ex)
        {
            Console.WriteLine($"{ex.Message}");
            
            return;
        }
    }

    public virtual void info()
    {
        Console.WriteLine($"Kontener {numer_seryjny}:");
        Console.WriteLine($"- Typ: {this.GetType().Name}");
        Console.WriteLine($"- Waga_kontenera: {masa_kontener} kg");
        Console.WriteLine($"- Wysokość: {wysokosc} cm");
        Console.WriteLine($"- Głębokość: {glebokosc} cm");
        Console.WriteLine($"- Max_ladownosc: {max_Ladownosc} kg");
        Console.WriteLine($"- Ładunek: {masa_ladunek} kg");
        
    }
}