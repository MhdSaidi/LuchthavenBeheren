using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuchthavenBeheren
{
    public class Baan
    {
      

        public string Code { get; set;}// kan een if aan de setter megegeven worden om zeker te zijn dat de ingegeven code niet langer is dan 3 zoals in meegegeven voorbeeld
        public bool Vrij { get; set; }

        public Baan()
        {
        }

        public Baan(string code, bool vrij)
        {
            Code = code;
            Vrij = vrij;
        }

     
        public string GeefOmschrijving()
        {

            string vrij;
            if( Vrij == true)
            {
                vrij = "ja";
            }
            else
            {
                vrij = "neen";
            }

            return " Overzicht banen:\n" +
                $" - Code : {Code} / Vrij : {vrij}";
        }
    }
}

/* * 
• Eigenschappen
o Code (string): de code van de baan. Deze is volledig vrij te kiezen.
o Vrij (bool): geeft aan indien de baan vrij is (true) en dus kan gebruikt worden door een
vliegtuig.
• Functies
o GeefOmschrijving
▪ Return: string
▪ Parameters: geen
▪ Omschrijving: Geeft een omschrijving van de baan terug = de code van de baan
+ ja / nee indien de baan respectievelijk vrij of niet vrij is.

 */