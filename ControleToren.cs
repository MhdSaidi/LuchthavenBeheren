using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuchthavenBeheren
{
    class ControleToren
    {

        public List<Vliegtuig> Vliegtuigs { get;} = new List<Vliegtuig>();// kan ik ook op lijn 19 aanmaken?  this.Vliegtuigs = new List<Vliegtuig>();
        public  List<Baan> Banen { get; set; } = new List<Baan>();

        public string RegistreerVliegtuig(Vliegtuig vliegtuig)
        {
            vliegtuig.VliegStatus = Status.OpstijgenAanTeVragen;
            vliegtuig.Vluchtnummer = GenereerVluchtNummer();
            Vliegtuigs.Add(vliegtuig);

            return vliegtuig.Vluchtnummer;
        }

        public string GenereerVluchtNummer() // Code uit de oefening
        {
            string vluchtnummer = string.Empty;
            Random random = new Random();
            do
            {
                int asciiNr = random.Next(48, 91);
                if (asciiNr >= 58 && asciiNr < 65)
                {
                    continue;
                }
                vluchtnummer += (char)asciiNr;
            } while (vluchtnummer.Length < 6);
            return vluchtnummer;
        }

        public Vliegtuig ZoekVliegtuig (string vluchtnummer)
        {
            if (this.Vliegtuigs.Exists(x=>x.Vluchtnummer==vluchtnummer))
            { 
                return Vliegtuigs.Find(x => x.Vluchtnummer.Equals(vluchtnummer));
                // mag ik hier gewoon "==" in plaats van Equals? In mijn ogen is dat de Equals niet enkel de waarde gaat vergelijken, maar neem het geheugenadres mee in rekening.
            }
            else
            {
                return null;// Wordt dit niet automatisch gedaan?(zie regel 55)
            }            
        }

        public Baan ZoekVrijeBaan()
        {           
            return Banen.Find(x => x.Vrij.Equals(true));   // hier doen we geen else return null. Vandaar dat ik de vraag stel op regel 49.       
        }

        public string AanvraagTotOpstijgen(string vluchtnummer)
        {
            Vliegtuig vliegtuig = (ZoekVliegtuig(vluchtnummer));
            Baan baan = ZoekVrijeBaan();
;
            if (vliegtuig != null && baan != null) { 
                
                vliegtuig.VliegStatus = Status.OpstijgenGoedgekeurd;
                vliegtuig.ToegewezenBaan = baan;
           
                return $"Opstijgen toegelaten - Toegewezen aan baan {baan.Code}";
            }
            
            else if (vliegtuig.VliegStatus!=Status.OpstijgenGoedgekeurd)
            {
                return $"Geen toelating - Status vliegtuig niet overeenkomstig : {Status.OpstijgenGoedgekeurd}";
            }
            else
            {
                return $"Geen toelating - Geen enkele baan is vrij";
            }
        }

        public List <string> OverzichtVliegtuigen()
            // Begrijp niet waarom het niet werk. Hier probeer ik het met een foreach en op lijn 94 met een SELECT, maar beide werken niet
        {

                return Vliegtuigs.Select(x => x.GeefOmschrijving()).ToList();
            /*


             List<Vliegtuig> vliegtuigLijst = new List<Vliegtuig>();

             vliegtuigLijst = (List<Vliegtuig>)Vliegtuigs.Select(x => x.GeefOmschrijving());
             foreach (Vliegtuig v in vliegtuigLijst)
             {
                 return v.GeefOmschrijving();
             }

             /* public IEnumerable<string> OverzichtVliegtuigen()*/

        }

        public List<string> OverzichtBanen()// werkt niet
        {
            return Banen.Select(baan => baan.GeefOmschrijving()).ToList();
        }

        public void VoegBaan(string code, bool vrij)
        {

            Banen.Add(new Baan(code, vrij));
        }
    }
}

/*
    
 * $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

 
 * 
 * ControleToren
      
        • Eigenschappen
                   o Vliegtuigen (List<Vliegtuig>): de lijst van alle vliegtuigen die beheerd worden door de
                   controletoren. De lijst kan alleen maar opgevraagd worden door een andere klasse.
                   o Banen (List<Baan>): de lijst van alle banen die beheerd worden door de controletoren.
                   De lijst kan alleen maar opgevraagd worden door een andere klasse.

           • Functies
              o RegistreerVliegtuig
                    ▪ Return: string
                    ▪ Parameters:
                    • Te registreren vliegtuig (Vliegtuig)
                    ▪ Omschrijving: de RegistreerVliegtuig functie zal het ontvangen vliegtuig een
                    vluchtnummer toewijzen, de status op “OpstijgenAanTeVragen” zetten en
                    toevoegen aan de lijst van beheerde vliegtuigen. Hierna zal de vluchtnummer
                    informatie worden teruggegeven. Hieronder de code die je kan gebruiken
                    voor een random vluchtnummer te genereren:
                    string vluchtnummer = string.Empty;
                    Random random = new Random();
                    do
                    {
                     int asciiNr = random.Next(48, 91);
                     if (asciiNr >= 58 && asciiNr < 65)
                     {
                     continue;
                     }
                     vluchtnummer += (char)asciiNr;
                    } while (vluchtnummer.Length < 6);

            o ZoekVliegtuig
                    ▪ Return: Vliegtuig
                    ▪ Parameters: 
                    • Vluchtnummber (string)
                    ▪ Omschrijving: Op basis van de vluchtnummerzal het vliegtuig worden gezocht
                    in de collectie van vliegtuigen. Indien er geen vliegtuig wordt gevonden zal er
                    null worden teruggegeven.


             o AanvraagTotOpstijgen
                    ▪ Return: string
                    ▪ Parameters:
                    • Vluchtnummer (string)
                    ▪ Omschrijving: 

                    op basis van de vluchtnummer parameter zal het vliegtuig
                    worden opgezocht (gebruik hiervoor de ZoekVliegtuig functie). Wanneer de
                    aanvraag goedgekeurd kan worden zal:
                    • De status van het vliegtuig aangepast worden naar
                    “OpstijgenGoedgekeurd”
                    • Een vrije baan worden toegewezen aan het vliegtuig
                    (ToegewezenBaan property)

                    Dit is echter enkel mogelijk wanneer:
                    • Het vliegtuig wordt gevonden (op basis van de vluchtnummer)
                    • Het vliegtuig de status “OpstijgenAanTeVragen” heeft
                    • Een vrije baan gevonden wordt (gebruik hiervoor de functie
                    ZoekVrijeBaan)
                    In alle gevallen zal de nodige informatie worden teruggegeven om de
                    aanvrager op de hoogte te stellen (zie screenshots)


                o ZoekVrijeBaan
                    ▪ Return: Baan
                    ▪ Parameters: void
                    ▪ Omschrijving: De functie ZoekVrijeBaan zal de eerste baan teruggeven
                    waarvan de Vrij property true is.


                o OverzichtVliegtuigen
                    ▪ Return: string
                    ▪ Parameters: geen
                    ▪ Omschrijving: De functie OverichtVliegtuigen geeft een overzicht van alle
                    geregistreerde vliegtuigen. (gebruik hiervoor de GeefOmschrijving functie van
                    het Vliegtuig)


                o OverzichtBanen
                    ▪ Return: string
                    ▪ Parameters: geen
                    ▪ Omschrijving: De functie OverichtBanen geeft een overzicht van alle banen.
                    (gebruik hiervoor de GeefOmschrijving functie van de Baan)

 */

