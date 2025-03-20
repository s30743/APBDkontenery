namespace kontenery;

public class KontenerChlodniczy : Kontener
{
    public string RodzajProdukt { get; set; }
    public double temperatura;
    Dictionary<string, double> produktyTemperatury = new Dictionary<string, double>
    {
        { "Bananas", 13.3 },
        { "Chocolate", 18 },
        { "Fish", 2 },
        { "Meat", -15 },
        { "Ice cream", -18 },
        { "Frozen pizza", -30 },
        { "Cheese", 7.2 },
        { "Sausages", 5 },
        { "Butter", 20.5 },
        { "Eggs", 19 }
    };

    public KontenerChlodniczy(double wysokosc, double masaKontener, double glebokosc, double maxLadownosc, double temperatura, string rodzajProdukt) : base(wysokosc, masaKontener, glebokosc, maxLadownosc)
    {

        if (!produktyTemperatury.ContainsKey(rodzajProdukt))
        {
            Console.WriteLine("Wpisany produkt nie znajduje sie na liscie, kontener nie utworzony");
            return;
        }

        if (this.temperatura < produktyTemperatury[rodzajProdukt])
        {
            Console.WriteLine("Temperatura kontenera nie moze byc nizsza niz temperatura produktu, kontener nie utworzony");
            return;
        }
        this.temperatura = temperatura;
        
    }

    public  void zaladowanie(double masa, string rodzajProdukt)
    {
        if (produktyTemperatury[rodzajProdukt] > temperatura)
        {
            
        }
    }
}