using System;
using System.Collections.Generic;

namespace LuchthavenBeheren
{
    class Program
    {
        static void Main(string[] args)
        {
            bool check = true;
            ControleToren controleToren = new ControleToren();
            Vliegtuig vliegtuig = new Vliegtuig();

            do
            {
                Console.WriteLine(" Controletoren - menu :\n" +
                    "1. Voeg baan toe.\n" +
                    "2. Registreer vliegtuig.\n" +
                    "3. Controletoren overzicht.\n" +
                    "4. Aanvraag voor opstijgen\n" +
                    "5. Opstijgen\n" +
                    "6. Stop\n");
                string invoerMenu = Console.ReadLine();
              
                switch (invoerMenu)
                {

                    case "1":
                        Console.WriteLine("Geef de baan code in : ");
                        string invoerBaan = Console.ReadLine();
                        controleToren.VoegBaan(invoerBaan, true);
                        controleToren.OverzichtBanen();
                        Console.WriteLine();
                        Console.WriteLine("Druk op een toets om verder te gaan");
                        break;
                    case "2":
                        controleToren.RegistreerVliegtuig(vliegtuig);
                        Console.WriteLine($"Vliegtuig werd geregistreerd. Vluchtnummer : {vliegtuig.Vluchtnummer}");
                        controleToren.OverzichtVliegtuigen();
                        Console.WriteLine();
                        Console.WriteLine("Druk op een toets om verder te gaan");
                        break;
                    case "3":
                        controleToren.OverzichtBanen();
                        Console.WriteLine();
                        controleToren.OverzichtVliegtuigen();
                        Console.WriteLine();
                        Console.WriteLine("Druk op een toets om verder te gaan");
                        break;
                    case "4":

                        Console.WriteLine("Geef het vluchtnummer in :");
                        string invoerVluchtnummer = Console.ReadLine();
                        controleToren.AanvraagTotOpstijgen(invoerVluchtnummer);
                        Console.WriteLine();
                        Console.WriteLine("Druk op een toets om verder te gaan");
                        break;
                    case "5":
                        Console.WriteLine("Geef het vluchtnummer in :");
                        invoerVluchtnummer = Console.ReadLine();
                        vliegtuig=controleToren.ZoekVliegtuig(invoerVluchtnummer);
                        vliegtuig.StijgOp();
                        Console.WriteLine();
                        Console.WriteLine("Druk op een toets om verder te gaan");
                        break;
                    case "6":
                        check = false; break;

                    default: Console.WriteLine("Voeg een cijfer van 1 tot 6 in om een keuze te maken in de Menu");break;
                }

            } while (check);






        }
    }
}
