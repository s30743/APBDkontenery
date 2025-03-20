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


    public Statek(double predkosc, int maxKontenery, double maxWagaKontenery)
    {
        this.konteneryStatek = new List<Kontener>();
        this.predkosc = predkosc;
        this.max_kontenery = maxKontenery;
        this.max_waga_kontenery = maxWagaKontenery;
        waga_obecna = 0;
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
        Console.WriteLine("-------------------");
        Console.WriteLine($"- Predkosc {predkosc}:");
        Console.WriteLine($"- maksymalna ilosc kontenerow: {max_kontenery} kg");
        Console.WriteLine($"- maksymalan waga kontenerow: {max_waga_kontenery} kg");
        Console.WriteLine($"- Obecna waga statku: {waga_obecna} kg");
        Console.WriteLine($"Obecne kontenery na statku: ");
        foreach (var k in this.konteneryStatek)
        {
            Console.WriteLine($"- {k.numer_seryjny}");
        }
        
        Console.WriteLine("-------------------");
    }
}