// See https://aka.ms/new-console-template for more information

using kontenery;
class Program
{
    public static void Main(string[] args)
    {
        List<Statek> statki = new List<Statek>();
        while (true)
        {
            Console.WriteLine("\nLista kontenerowców");
            if (statki.Count == 0)
            {
                Console.WriteLine("Brak");
            }
            else
            {
                foreach (var statek in statki)
                {
                    statek.InfoStatek();
                }
            }
            Console.WriteLine("Lista kontenerów");
            if (statki.Count == 0)
            {
                Console.WriteLine("Brak");
            }
            else
            {
                foreach (var statek in statki)
                {
                    var numery = string.Join(" ", statek.konteneryStatek.Select(k => k.numer_seryjny));
                    Console.WriteLine(numery);
                }
            }
            
            Console.WriteLine("\nMożliwe akcje:");
            Console.WriteLine("1. Dodaj kontenerowiec");
            if (statki.Count >0 )
            {
                Console.WriteLine("2. Usuń kontenerowiec");
                Console.WriteLine("3. dodaj kontener");
            }

            if (statki.Count > 0 && statki.Any(k => k.konteneryStatek.Count > 0))
            {
                Console.WriteLine("4. Usuń kontener");
                Console.WriteLine("5. Zastąp kontener");
                Console.WriteLine("6.Załaduj kontener");
                Console.WriteLine("7.Opróżnij kontener");
                Console.WriteLine("8. Informacje kontener");
                
            }

            if (statki.Count > 1 && statki.Any(k => k.konteneryStatek.Count > 0))
            {
                Console.WriteLine("9.Przecu kontener na inny statek");
            }
            
            Console.WriteLine("nacisnij Q by zakonczyc");
            
            string user_input = Console.ReadLine();
            if (user_input == "1")
            {
                Statek n1 = Statek.DodajKontenerowiec();
                statki.Add(n1);
            }
            else if (user_input == "2")
            {
                
                    Console.WriteLine("Który statek chcesz usunąc: ");
                    for (int i = 0; i < statki.Count; i++)
                    {
                        Console.WriteLine($"{i}. Statek {i }");
                    }
                    int index = int.Parse(Console.ReadLine());
                    statki.RemoveAt(index);
                
                    
            }
            else if (user_input == "3")
            {
                Console.WriteLine("Podaj numer statku, na który chcesz dodać kontener:");
                for (int i = 0; i < statki.Count; i++)
                {
                    Console.WriteLine($"{i}. Statek {i }");
                }
                int indexstatek = int.Parse(Console.ReadLine());

                if (indexstatek >= 0 && indexstatek < statki.Count)
                {
                    Console.WriteLine("Podaj typ kontenera: \n1.Chłodniczy \n2.Płyn \n3.Gazowy");
                    int typKontenera = int.Parse(Console.ReadLine());
                    Kontener kontener = null;
                    
                    switch (typKontenera)
                    {
                        case 1:
                            kontener = statki[indexstatek].StworzKontenerChlodniczy();
                            break;
                        case 2:
                            kontener = statki[indexstatek].StworzKontenerPlynny();
                            break;
                        case 3:
                            kontener = statki[indexstatek].StworzKontenerGazowy();
                            break;
                        
                    }
                    if (kontener != null)
                    {
                        statki[indexstatek].DodajKontener(kontener);
                    }
                }
                else
                {
                    Console.WriteLine("Niepoprawny numer statku.");
                }
            }
            else if (user_input == "4")
            {
                Console.WriteLine("Wybierz numer statku, z którego chcesz usunąć kontener:");
                for (int i = 0; i < statki.Count; i++)
                {
                    Console.WriteLine($"{i}. Statek {i }");
                }
                int statekIndex = int.Parse(Console.ReadLine());
                
                var statek = statki[statekIndex];
                Console.WriteLine("Wybierz numer kontenera do usuniecia");
                for (int i = 0; i < statek.konteneryStatek.Count; i++)
                {
                    Console.WriteLine($"{i}. {statek.konteneryStatek[i].numer_seryjny}");
                }
                int kontenerIndex = int.Parse(Console.ReadLine());
                Kontener kontener = statek.konteneryStatek[kontenerIndex];
                
                statek.UsunKontener(kontener);
                
                
                
            } else if (user_input == "5")
            {   
                Console.WriteLine("Wybierz numer statku, na ktorym chcesz zastapic kontener:");
                for (int i = 0; i < statki.Count; i++)
                {
                    Console.WriteLine($"{i}. Statek {i }");
                }
                int statekIndex = int.Parse(Console.ReadLine());
                var statek = statki[statekIndex];
                Console.WriteLine("Wybierz numer kontenera do zastapienia");
                for (int i = 0; i < statek.konteneryStatek.Count; i++)
                {
                    Console.WriteLine($"{i}. {statek.konteneryStatek[i].numer_seryjny}");
                }
                int stary = int.Parse(Console.ReadLine());
                Kontener staryKontener = statek.konteneryStatek[stary];
                Console.WriteLine("Podaj typ kontenera: \n1.Chłodniczy \n2.Płyn \n3.Gazowy");
                int typKontenera = int.Parse(Console.ReadLine());
                Kontener nowyKontener = null;

                switch (typKontenera)
                {
                    case 1:
                        nowyKontener = statek.StworzKontenerChlodniczy();
                        break;
                    case 2:
                        nowyKontener = statek.StworzKontenerPlynny();
                        break;
                    case 3:
                        nowyKontener = statek.StworzKontenerGazowy();
                        break;
                    
                }

                if (nowyKontener != null)
                {
                    statek.ZastapKontener(staryKontener, nowyKontener);
                }
                
            } else if (user_input == "6") 
            {
                Console.WriteLine("Wybierz numer statku, na którym chcesz załadować kontener:");
                for (int i = 0; i < statki.Count; i++)
                {
                    Console.WriteLine($"{i}. Statek {i }");
                }
                int statekIndex = int.Parse(Console.ReadLine());
                
                var statek = statki[statekIndex];
                Console.WriteLine("Wybierz numer kontenera do załadowania:");
                for (int i = 0; i < statek.konteneryStatek.Count; i++)
                {
                    Console.WriteLine($"{i}. {statek.konteneryStatek[i].numer_seryjny}");
                }
    
                int kontenerIndex = int.Parse(Console.ReadLine());
                var kontener = statek.konteneryStatek[kontenerIndex];

                Console.WriteLine("Podaj masę ładunku do załadowania:");
                double masa = double.Parse(Console.ReadLine());
                kontener.zaladowanie(masa,statek);
                
            }else if (user_input == "7") 
            {
                Console.WriteLine("Wybierz numer statku, na którym chcesz oprozncs kontener:");
                for (int i = 0; i < statki.Count; i++)
                {
                    Console.WriteLine($"{i}. Statek {i }");
                }
                int statekIndex = int.Parse(Console.ReadLine());
                
                var statek = statki[statekIndex];
                Console.WriteLine("Wybierz numer kontenera do oproznienia:");
                for (int i = 0; i < statek.konteneryStatek.Count; i++)
                {
                    Console.WriteLine($"{i}. {statek.konteneryStatek[i].numer_seryjny}");
                }
    
                int kontenerIndex = int.Parse(Console.ReadLine());
                var kontener = statek.konteneryStatek[kontenerIndex];

                
                kontener.oproznienie(statek);
                
            }else if (user_input == "9")
            {
                Console.WriteLine("Wybierz numer statku, z ktorego chcesz przeniesc kontener:");
                for (int i = 0; i < statki.Count; i++)
                {
                    Console.WriteLine($"{i}. Statek {i }");
                }
                int statekIndex = int.Parse(Console.ReadLine());
                
                var statekstary = statki[statekIndex];
                
                Console.WriteLine("Wybierz numer kontenera do przeniesienia:");
                for (int i = 0; i < statekstary.konteneryStatek.Count; i++)
                {
                    Console.WriteLine($"{i}. {statekstary.konteneryStatek[i].numer_seryjny}");
                }
    
                int kontenerIndex = int.Parse(Console.ReadLine());
                var kontener = statekstary.konteneryStatek[kontenerIndex];
                
                Console.WriteLine("Wybierz numer statku, na ktory chcesz przeniesc kontener:");
                for (int i = 0; i < statki.Count; i++)
                {
                    Console.WriteLine($"{i}. Statek {i }");
                }
                int statekIndex2 = int.Parse(Console.ReadLine());
                var nowystsatek = statki[statekIndex2];
                
                statekstary.PrzeniesKontenernaInnyStatek(kontener,nowystsatek);
            }else if (user_input == "8")
            {
                Console.WriteLine("Wybierz numer statku:");
                for (int i = 0; i < statki.Count; i++)
                {
                    Console.WriteLine($"{i}. Statek {i }");
                }
                int statekIndex = int.Parse(Console.ReadLine());
                
                var statek = statki[statekIndex];
                
                
                Console.WriteLine("Wybierz numer kontenera by zdobyc informacje:");
                for (int i = 0; i < statek.konteneryStatek.Count; i++)
                {
                    Console.WriteLine($"{i}. {statek.konteneryStatek[i].numer_seryjny}");
                }
    
                int kontenerIndex = int.Parse(Console.ReadLine());
                var kontener = statek.konteneryStatek[kontenerIndex];
                
                kontener.info();
                
                
            }
            {
                
            }
        }
    }
}


