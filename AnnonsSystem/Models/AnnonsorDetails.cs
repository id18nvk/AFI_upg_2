using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnnonsSystem.Models
{
    public class AnnonsorDetails
    {
        public AnnonsorDetails() {}

        public int an_Id { get; set; }
        public string an_Namn { get; set; }
        public string an_Tlfnr { get; set; }
        public string an_OrgNr { get; set; }
        public string an_Adress { get; set; }
        public string an_Ort { get; set; }
        public string an_PostNr { get; set; }
        public string an_FkAdress { get; set; }
        public string an_FkOrt { get; set; }
        public string an_FkPostNr { get; set; }
    }
}
