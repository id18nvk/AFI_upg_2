using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrenumerantSystem.Models
{
    public class PrenumerantDetails
    {
        public PrenumerantDetails(){}

        public int pr_Id { get; set; }
        public string pr_Firstname { get; set; }
        public string pr_Lastname { get; set; }
        public string pr_Tlfnr { get; set; }
    }
}
