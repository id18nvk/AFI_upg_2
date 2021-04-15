using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrenumerantSystem.Models
{
    public class PrenumerantDetails
    {
        public PrenumerantDetails(){}

        [Display (Name ="Prenumerations id")]
        public int pr_Id { get; set; }

        [Display(Name = "Förnamn")]
        public string pr_Firstname { get; set; }

        [Display(Name = "Efternamn")]
        public string pr_Lastname { get; set; }

        [Display(Name = "Telefonnummer")]
        public string pr_Tlfnr { get; set; }

        [Display(Name = "Address")]
        public string pr_Adress { get; set; }

        [Display(Name = "Ort")]
        public string pr_Ort { get; set; }

        [Display(Name = "Postnummer")]
        public string pr_PostNr { get; set; }

        [Display(Name = "Faktureringsaddress")]
        public string pr_FkAdress { get; set; }

        [Display(Name = "Faktureringsort")]
        public string pr_FkOrt { get; set; }

        [Display(Name = "Faktureringspostnummer")]
        public string pr_FkPostNr { get; set; }
    }
}
