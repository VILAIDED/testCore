namespace testCore.Models
{
    public class BillInfo
    {
        public int ID {get;set;}
        public int BillID {get;set;}
        public int LaptopId {get;set;}
        public int Quanlity {get;set;}
        public double Price {get;set;}
        public Bill Bill {get;set;}
        public Laptop Laptop {get;set;}
    }
}