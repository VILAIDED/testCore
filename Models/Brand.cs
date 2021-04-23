using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace testCore.Models
{
    public class Brand
    {
        [Key]
        public int ID { get; set; }
        public String BrandName { get; set; }
        public virtual ICollection<Laptop> Laptop { get; set; }
        public Brand(){
            this.Laptop = new HashSet<Laptop>();
            }

    }
}
