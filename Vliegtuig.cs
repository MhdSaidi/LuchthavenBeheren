using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuchthavenBeheren
{
    public class Vliegtuig : IEquatable<Vliegtuig>
    {
       

        public int ID { get; }// niet in de opgave, maar hoe koppel ik anders mijn vliegtuig aan mijn vluchtnummer
        public string Vluchtnummer { get; set; }
        public Baan ToegewezenBaan { get; set; } = new Baan();
        public Status VliegStatus { get; set; }

        public Vliegtuig()
        {
        }

        public Vliegtuig(int iD)
        {
            ID = iD;
        }

        public string StijgOp ()
        {
           this.VliegStatus = Status.Opgestegen;
           this.ToegewezenBaan.Vrij = true;

            if (this.VliegStatus is Status.OpstijgenGoedgekeurd)// op regel 25 zet ik het gelijk aan "opgestegen". Ik begrijp dus niet hoe de code hier gaat werken? Gaat het uit mijn code en komt terug wanneer mijn controletoren het op "opstijgengoedgekeurd"?
            {
                this.ToegewezenBaan = null; // Er wordt mij gevraagd om de eigenschap op "null" te zetten, maar daarna moet ik de waarde hiervan wel kennen om te returnen. Nu return ik een waarde null wat niet de bedoeling is.

                return $" Vlucht met vluchtnummer + {this.Vluchtnummer} is opgestegen op baan {this.ToegewezenBaan.Code}";
                
            }
            else
            {
                return $" Opstijgen niet mogelijk - Huidige status : {Status.OpstijgenAanTeVragen}";
            }
        }


        public string GeefOmschrijving()
         {
            return "Overzicht vliegtuigen:\n" +
                $" - Vluchtnummer : { this.Vluchtnummer} || Status : {this.VliegStatus} || Toegewezen baan : {this.ToegewezenBaan.Code}";
        }

        //Wat hieronder volgt, heb ik gewoon gekopierd, maar begrijp de code en het nut ervan.

      
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Vliegtuig objAsPart = obj as Vliegtuig;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
        public override int GetHashCode()
        {
            return int.Parse(this.Vluchtnummer);
        }
        public bool Equals(Vliegtuig other)
        {
            if (other == null) return false;
            return (this.Vluchtnummer.Equals(other.Vluchtnummer));
        }



  
    }
}

/*
  
 * ------------------------------------------------------------------------
 * 
 * 
 * * Vliegtuig:
    • Eigenschappen
        o Vluchtnummer (string): de vluchtnummer ontvangen van de controletoren
        o ToegewezenBaan (Baan): De baan die werd toegewezen aan het vliegtuig na een
        positieve aanvraag voor opstijgen. (toegewezen door de controletoren)
        o Status (VliegStatus enum): geeft via een enumeratie de status van het vliegtuig weer.
        De mogelijk waarden zijn
            ▪ OpstijgenAanTeVragen
            ▪ OpstijgenGoedgekeurd
            ▪ Opgestegen

  oStijgOp
            ▪ Return: string
            ▪ Parameters: geen
            ▪ Omschrijving: de StijgOp functie zal
                ➢ de status van het vliegtuig aanpassen naar “Opgestegen”
                ➢ de toegewezen baan vrij geven (Vrij property van het Baan object
                aanpassen)
                ➢ de toegewezen baan verwijderen (ToegewezenBaan property = null)
                Dit zal echter enkel gebeuren wanneer de status van het vliegtuig
                “OpstijgenGoedgekeurd” is. In dit geval zal ook de vluchtnummer en baan
                code informatie worden teruggegeven. In het andere geval zal een
                foutmelding met vliegtuig status worden teruggegeven (zie screenshots)

 • Fucnties
      
        o GeefOmschrijving
            ▪ Return: string
            ▪ Parameters: geen
            ▪ Omschrijving: Geeft een volledige omschrijving van het vliegtuig =
            Vluchtnummer / Status / Toegewezen baan
 * 
 * 
 */