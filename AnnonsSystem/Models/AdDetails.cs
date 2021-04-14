using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnnonsSystem.Models
{
    public class AdDetails
    {
        public AdDetails(){}

        public int ad_Id { get; set; }
        public string ad_Title { get; set; }
        public int ad_Price { get; set; }
        public string ad_Content { get; set; }
        public int ad_AdPrice { get; set; }
        public int ad_P_Annonsor { get; set; }
        public int ad_F_Annonsor { get; set; }
    }
}