using System;
using System.Collections.Generic;
namespace testCore.Models
{
    public class Bill
    {
        public int ID {get;set;}
        public string CustomerName {get;set;}
        public string Email {get;set;}
        public string Phone {get;set;}
        public DateTime OrderDate {get;set;}
        public double Price {get;set;}
        public ICollection<BillInfo> BillInfos {get;set;}
        
    }
}