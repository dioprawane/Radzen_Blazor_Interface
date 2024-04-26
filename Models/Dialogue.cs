// Models/Dialogue.cs
using System;
using System.ComponentModel.DataAnnotations;
namespace DialogueDeGestion.Models
{
    public class Dialogue
    {
        [Key]
        public int DCODE { get; set; }
        public int DGCODE { get; set; }
        public string DGMACRODESIGNATION { get; set; } = string.Empty;
        public string DGNATUREDUBESOIN { get; set; } = string.Empty;
        public string DGCADREDACHAT { get; set; } = string.Empty;
        public string DGFOURNISSEUR { get; set; } = string.Empty;
        public int DGNTIERS { get; set; }
        public string DGLIBELLEDUMARCHE { get; set; } = string.Empty;
        public string DGMASSEBUDGETAIRE { get; set; } = string.Empty;
        public string DGDA { get; set; } = string.Empty;
        public string DGAXENATIONAL1 { get; set; } = string.Empty;
        public string DGGRANDPROJET { get; set; } = string.Empty;
        public string DGNOMPROJET { get; set; } = string.Empty;
        public string DGSTATUTPROJETG2PI { get; set; } = string.Empty;
        public string DGCODEINITIATIVESDSI { get; set; } = string.Empty;
        public string DGOBJECTINITIATIVE { get; set; } = string.Empty;
        public decimal DGCOMPTESBUDGETAIRES { get; set; } = 0;
        public decimal DGCOMPTESCOMPTABLES { get; set; } = 0;
        public string DGPORTEFEUILLE { get; set; } = string.Empty;
        public string DGSOUSPORTEFEUILLE { get; set; } = string.Empty;
        public string DGCARACTERISTIQUEDUBESOIN { get; set; } = string.Empty;
        public string DGCRITICITE { get; set; } = string.Empty;
        public decimal DGBUDGETINITIALDEMANDE { get; set; }
        public decimal DGBUDGETDG1DEMANDE { get; set; }
        public decimal DGBUDGETDG2DEMANDE { get; set; }
        public decimal DGBUDGETDG3DEMANDE { get; set; }
        public decimal DGBUDGETDG4DEMANDE { get; set; }
        public string DGDEMANDEDEREPORTIDENTIFIE { get; set; } = string.Empty;
        public decimal DGPLANBUDGBIJANVIER { get; set; } = 0;
        public decimal DGPLANBUDGBR1JUILLET { get; set; } = 0;
        public decimal DGPLANBUDGBR2NOVEMBRE { get; set; } = 0;
        public string DGNUMEROAB { get; set; } = string.Empty;
        public string DGNUMERODB { get; set; } = string.Empty;
        public decimal DGBIAUTORISE { get; set; }
        public decimal DGBR1AUTORISE { get; set; }
        public decimal DGBR2AUTORISE { get; set; }
        public string DGNCOMMANDE { get; set; } = string.Empty;
        public DateTime DGDATEDEDEBUT  { get; set; }
        public DateTime DGDATEDEFIN { get; set; }
        public decimal DGMONTANTCOMMANDE { get; set; }
        public string DGNENGAGEMENT { get; set; } = string.Empty;
        public decimal DGMONTANTENGAGE { get; set; }
        public decimal DGREALISE { get; set; }
        public string DGGA486ANNEEN1 { get; set; } = string.Empty;
        public string DGGA486ANNEEN2 { get; set; } = string.Empty;
        public string DGGA486ANNEEN3 { get; set; } = string.Empty;
        public string DGGA486ANNEEN4 { get; set; } = string.Empty;
        public decimal DGBUDGPREVN1 { get; set; }
        public decimal DGBUDGPREVN2 { get; set; }
        public decimal DGBUDGPREVN3 { get; set; }
        public decimal DGBUDGPREVN4 { get; set; }
        public string DGCOMMENTAIRES { get; set; } = string.Empty;
        public int DGANNEE { get; set; }
        public string DGSERIEDEDONNEES { get; set; } = string.Empty;
    }
}
