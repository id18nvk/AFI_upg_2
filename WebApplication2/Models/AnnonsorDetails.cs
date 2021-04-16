using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnnonsSystem.Models
{
    public class AnnonsorDetails
    {
        public AnnonsorDetails() {}

        public int an_Id { get; set; }

        [Display(Name = "Företagsnamn")]
        public string an_Namn { get; set; }

        [Display(Name = "Telefonnummer")]
        public string an_Tlfnr { get; set; }

        [Display(Name = "Organisationsnummer")]
        public string an_OrgNr { get; set; }

        [Display(Name = "Address")]
        public string an_Adress { get; set; }

        [Display(Name = "Ort")]
        public string an_Ort { get; set; }

        [Display(Name = "Postnummer")]
        public string an_PostNr { get; set; }

        [Display(Name = "Faktureringsaddress")]
        public string an_FkAdress { get; set; }

        [Display(Name = "Faktureringsort")]
        public string an_FkOrt { get; set; }

        [Display(Name = "Faktureringspostnummer")]
        public string an_FkPostNr { get; set; }
    }
}
