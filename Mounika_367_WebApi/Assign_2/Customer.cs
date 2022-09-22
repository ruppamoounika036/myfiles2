namespace Assign_2;

// namespace ObjectApp
// {
    class Customer{
        public string Name {get; set;}
        public string[] items {get;set;}
        public double[] items_qnt {get;set;}
        public decimal[] items_price {get;set;}
        public double payable {get;set;}
        public DateTime OrderedTime {get;set;}
        public bool[] idisc {get;set;}
        public DateTime StartDate{get;set;}
        public DateTime EndDate{get;set;}
        public string PackageName{get;set;}
        public int Pincode{get;set;}
        public int paymode{get;set;}
        
        public static bool IsPrimeCustomer(DateTime startTime , DateTime endTime){
            if(startTime < endTime)
            return true;
            return false;
        }
    }
    
// }