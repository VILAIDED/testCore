using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace testCore.Models
{
    public class Laptop
    {
      
        public int ID { get; set; }

        public int BrandID { get; set; }
        public double Price { get; set; }
        public String LaptopName { get; set; }
        public String Info { get; set; }
        public int Amount { get; set; }
        public  Brand Brand { get; set; }
        public  Component Component { get; set; }
        public ICollection<LaptopImage> LaptopImage { get; set; }
        public ICollection<BillInfo> BillInfos {get;set;}
        
    }
}
