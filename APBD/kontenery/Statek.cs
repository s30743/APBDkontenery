namespace kontenery;

public class Statek
{
    public List<Kontener> konteneryStatek {
        get;
        set;
    }

    public double predkosc { get; set; }
    public int max_kontenery { get; set; }
    public double max_waga_kontenery { get; set; }
    public double waga_obecna { get; set; }
    public int indexstatek { get; set; }    


    public Statek(double predkosc, int maxKontenery, double maxWagaKontenery)
    {
        this.konteneryStatek = new List<Kontener>();
        this.predkosc = predkosc;
        this.max_kontenery = maxKontenery;
        this.max_waga_kontenery = maxWagaKontenery * 1000;
        this.indexstatek = ++StatekIndex;
        waga_obecna = 0;
    }
    private static int StatekIndex = 0;

    public static Statek DodajKontenerowiec()
    {
        Console.Write("Podaj prędkość statku: ");
        double predkosc = Convert.ToDouble(Console.ReadLine());
        Console.Write("Podaj maksymalną liczbę kontenerów: ");
        int maxKontenery = Convert.ToInt32(Console.ReadLine());
        Console.Write("Podaj maksymalną wagę kontenerów: ");
        double maxWagaKontenery = Convert.ToDouble(Console.ReadLine());
        Statek statek = new Statek(predkosc, maxKontenery, maxWagaKontenery);
        return statek;
    }
    public Kontener StworzKontener()
    {
        
        Console.Write("Wysokość: ");
        double wysokosc = Convert.ToDouble(Console.ReadLine());
        Console.Write("Masa kontenera: ");
        double masaKontener = Convert.ToDouble(Console.ReadLine());
        Console.Write("Głębokość: ");
        double glebokosc = Convert.ToDouble(Console.ReadLine());
        Console.Write("Maksymalna ładowność: ");
        double maxLadownosc = Convert.ToDouble(Console.ReadLine());

        return new Kontener(wysokosc, masaKontener, glebokosc, maxLadownosc);
    }
    public KontenerChlodniczy StworzKontenerChlodniczy()
    {
        
        Console.Write("Rodzaj produktu: ");
        string rodzajProdukt = Console.ReadLine();
        Kontener kontener = StworzKontener();
        Console.Write("Temperatura kontenera: ");
        double temperatura = Convert.ToDouble(Console.ReadLine());
        

        return new KontenerChlodniczy(kontener.wysokosc, kontener.masa_kontener, kontener.glebokosc, kontener.max_Ladownosc, temperatura, rodzajProdukt);
    }

    public KontenerPlyn StworzKontenerPlynny()
    {
        Kontener kontener = StworzKontener();
        Console.Write("Czy ładunek jest niebezpieczny? (true/false): ");
        bool ladunekNiebezpieczny = Convert.ToBoolean(Console.ReadLine());

        return new KontenerPlyn(kontener.wysokosc, kontener.masa_kontener, kontener.glebokosc, kontener.max_Ladownosc, ladunekNiebezpieczny);
    }

    public KontenerGaz StworzKontenerGazowy()
    {
        Kontener kontener = StworzKontener();
        Console.Write("Ciśnienie gazu: ");
        double cisnienie = Convert.ToDouble(Console.ReadLine());

        return new KontenerGaz(kontener.wysokosc, kontener.masa_kontener, kontener.glebokosc, kontener.max_Ladownosc, cisnienie);
    }

    
    public void DodajKontener(Kontener k)
    {
        if (konteneryStatek.Count >= max_kontenery)
        {
            Console.WriteLine($"Nie mozna dodac kolejengo kontera, max ilosc {max_kontenery} ");
            return;
        }
        
        if (waga_obecna + k.masa_ladunek + k.masa_kontener < max_waga_kontenery)
        {
            konteneryStatek.Add(k);
            waga_obecna += k.masa_ladunek + k.masa_kontener;
            Console.WriteLine($"Kontener {k.numer_seryjny} został dodany na statek.");
            
            
        }
        else
        {
            Console.WriteLine($"Nie mozna dodac konteneru ze wzgledu na zbbyt duza wage");
            return;
        }
    }

    public void UsunKontener(Kontener k)
    {
        if (konteneryStatek.Contains(k))
        {
            konteneryStatek.Remove(k);
            waga_obecna -= k.masa_ladunek + k.masa_kontener;
            
        }
        else
        {
            Console.WriteLine("Statek nie posiadal takiego kontenera");
        }
    }

    public void DodajListeKontenerow(List<Kontener> kontenery)
    {
        if (konteneryStatek.Count + kontenery.Count > max_kontenery)
        {
            Console.WriteLine("Nie można dodać listy kontenerów, ponieważ liczba kontenerów przekroczy limit");
            return;
        }
        double waga_kontenery = 0;
        foreach (var k in kontenery)
        {
            waga_kontenery += k.masa_ladunek + k.masa_kontener;
        }

        if (waga_kontenery + waga_obecna > max_waga_kontenery)
        {
            Console.WriteLine("Waga Listy kontenerow jest zbyt duza");
        }
        else
        {
            foreach (var k in kontenery)
            {
                waga_obecna += k.masa_ladunek + k.masa_kontener;
                konteneryStatek.Add(k);
            }
        }
    }

    public void ZastapKontener(Kontener stary, Kontener nowy)
    {
        if (konteneryStatek.Contains(stary))
        {
            UsunKontener(stary);
            DodajKontener(nowy);
        }
        else
        {
            Console.WriteLine("Kontner ktory mial zostac wymieniony nie istnieje na statku");
        }
    }

    public void PrzeniesKontenernaInnyStatek(Kontener k,Statek nowy)
    {
        if (this.konteneryStatek.Contains(k))
        {
            if (nowy.konteneryStatek.Count < nowy.max_kontenery)
            {
                this.UsunKontener(k);
                nowy.DodajKontener(k);
                Console.WriteLine($"Jezeli nie wyswietlil sie komunikat dotyczacy zbyt duzej wagi ,przeniesiono kontener {k.numer_seryjny} do innego statku");
            }
            
        }
        else
        {
            Console.WriteLine("Kontener nie istnieje na statku");
        }
    }

    public void InfoStatek()
    {
        /*Console.WriteLine("-------------------");
        Console.WriteLine($"- Predkosc {predkosc}:");
        Console.WriteLine($"- maksymalna ilosc kontenerow: {max_kontenery} kg");
        Console.WriteLine($"- maksymalan waga kontenerow: {max_waga_kontenery} kg");
        Console.WriteLine($"- Obecna waga statku: {waga_obecna} kg");
        Console.WriteLine($"Obecne kontenery na statku: ");
        foreach (var k in this.konteneryStatek)
        {
            Console.WriteLine($"- {k.numer_seryjny}");
        }
        
        Console.WriteLine("-------------------");*/
        Console.WriteLine($"Statek " + indexstatek + $" speed={predkosc}, maxContainerNum={max_kontenery}, maxWeight={max_waga_kontenery}, obecna_waga={waga_obecna}");
    }

    public  void WyswietlKontenerowce()
    {
        Console.WriteLine("Lista kontenerowców:");
        if (this.konteneryStatek.Count ==0)
        {
            Console.WriteLine("Brak");
        }
    }
    
}