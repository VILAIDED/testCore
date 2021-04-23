using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace testCore.Models
{
    public class Component
    {
        [Key]
        public int ID { get; set; }
     
        public int LapTopID {get; set; }
        public String TypeCPU { get; set; }
        public double SizeScreen { get; set; }
        public String TypeDisk { get; set; }
        public double SizeDisk { get; set; }
        public double SizeRam { get; set; }
        public double SizePin { get; set; }
        public double Weight { get; set; }
        public  Laptop Laptop { get; set; }


    }
}
