using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnnonsSystem.Models
{
    public class AdDetails
    {
        public AdDetails(){}

        [Display(Name = "ID")]
        public int ad_Id { get; set; }

        [Display(Name = "Titel")]
        public string ad_Title { get; set; }
        
        [Display(Name = "Pris")]
        public int ad_Price { get; set; }

        [Display(Name = "Beskrivning")]
        public string ad_Content { get; set; }
        public int ad_AdPrice { get; set; }
        public int ad_P_Annonsor { get; set; }
        public int ad_F_Annonsor { get; set; }
    }
}