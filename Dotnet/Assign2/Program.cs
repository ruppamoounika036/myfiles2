namespace AmazonNamespace{
    public enum payment_mode{cash,card,wallet,netbank};
    public static class Assignment{
        public static string? account;
        public static string[]? customer_item = new string[10];
        public static string[]? customer_name=new string[10];
        public static int[] item_quantity = new int[10];
        public static double[] item_price = new double[10];
        public static bool[] eligibility = new bool[10];
        public static DateTime startdate;
        public static DateTime enddate;
        public static int count=0;
        public static int pay;
        public static string? c_name;
        public static string? customer_n;
        public static void input(string? accoun){
             
            if(accoun=="Admin"){
                var filePath=@"D:\Mysource.txt";
                c_name=Console.ReadLine();
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
            using (StreamReader sr = new StreamReader(fs))
            {
                string content = sr.ReadToEnd();
                string[] lines = content.Split(new string[] {Environment.NewLine},
                    StringSplitOptions.RemoveEmptyEntries);

                int lineCount = 0;
                foreach (string line in lines)
                {
                    string[] column = line.Split(',');
                    if(c_name!="all orders"){
                     if (lineCount != 0)
                    {   
                        if(c_name==column[0]){
                            Console.WriteLine(column[1]);

                        }
                    }
                    }
                    else if(c_name=="all orders"){
                         if((DateTime.Now).Subtract(Convert.ToDateTime(column[2])).Minutes<=60){
                            Console.WriteLine($"Customer Name: {column[0]}");
                            Console.WriteLine($"Customer Item: {column[1]}");
                            Console.WriteLine($"Item Quantity: {column[3]}");
                            Console.WriteLine($"Item Price: {column[4]}");
                         }
                    }
                    else{
                        Console.WriteLine("Invalid Input");
                    }
                    lineCount++;
                }
            }  
        }            
            }
            else if(accoun=="Customer"){
                customerDetails();
                cutsomerDetailsPrint();
            }
        } 
        public static void customerDetails(){
            var filePath=@"D:\Mysource.txt";
            Console.WriteLine("Enter the customer name: ");
            customer_n=Console.ReadLine();
            Console.WriteLine("Enter item details: ");
            int i=0;
            while(i<10){
                Console.WriteLine("Enter item name: (Enter end to exit)");
                string? sam;
                sam=Console.ReadLine();
                if(sam=="end"){
                    break;
                }
                else{
                    count+=1;
                    customer_name[i]=customer_n;
                    customer_item[i]=sam;
                    Console.WriteLine("Enter item quantity: ");
                    item_quantity[i]=Convert.ToInt16(Console.ReadLine());
                    Console.WriteLine("Enter the item price: ");
                    item_price[i]=Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Enter the item eligibility");
                    string yn=Console.ReadLine();
                    eligibility[i]=(yn=="Y")?true:false;
                    i++;
                }
               
        using (FileStream fs = new FileStream(filePath, FileMode.Append))
        {
            using (StreamWriter sw = new StreamWriter(fs))
            {
                string fullText = (customer_n+ "," +sam+ "," + DateTime.Now+","+item_quantity[i-1]+","+item_price[i-1]);
                sw.WriteLine(fullText);
            }
        }
    }
            Console.WriteLine("Enter the start date: ");
            startdate=Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Enter the end date: ");
            enddate=Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Enter the payment mode: \n1.Cash\n2.Card\n3.Wallet\n4.Netbank");
            pay=Convert.ToInt32(Console.ReadLine());

        }
        public static void cutsomerDetailsPrint(){
           Console.WriteLine("Item deatils:");
           double summ=0;
           for(int j=0;j<count;j++){
               Console.WriteLine($"{customer_item[j]}");
           Console.WriteLine($"{item_quantity[j]}");
           Console.WriteLine($"{item_price[j]}");
           Console.WriteLine($"Subtotal for each item: {item_quantity[j]*item_price[j]}");
           summ+=item_quantity[j]*item_price[j];
           }
           Console.WriteLine($"Grand total: {summ}");
           double invoice=(summ*5)/100;
           Console.WriteLine($"5% GST on the Grand total:{invoice}");
           double invoic=invoice+summ;
           Console.WriteLine($"Invoice:{invoic}");
           discount(invoic,item_quantity,item_price,eligibility,enddate,Convert.ToString((payment_mode)pay));
        }
        public static void discount(double invoice,int[] item_quantity,double[] item_price,bool[] eligibility,DateTime enddate,string? payment){
            double sum1=0;
            for(int k=0;k<count;k++){
                if(eligibility[k]){
                   sum1+=item_price[k]*item_quantity[k];
                }
            }
            if(sum1>1500 && DateTime.Now<Convert.ToDateTime(enddate)){
                double payable=invoice-(invoice*10)/100;
                Console.WriteLine("10% discount applied.");
                Console.WriteLine($"Your Payable Amount: {payable}");
            }
            else if(sum1<1500 && sum1>1000 && DateTime.Now<Convert.ToDateTime(enddate)){
                Console.WriteLine("50rs discount applied");
                double payable=invoice-50;
                Console.WriteLine($"Your Payable Amount: {payable}");
            }
            else if( DateTime.Now<Convert.ToDateTime(enddate) && payment=="cash"){
                Console.WriteLine("3% discount applied");
                double payable=invoice-(invoice*3)/100;
                Console.WriteLine($"Your Payable Amount: {payable}");
            }
            else{
                double payable=invoice;
                Console.WriteLine("No discount is applied");
                Console.WriteLine($"Your Payable Amount: {payable}");
            }
        }

    }
class Amazon{
    public static void Main(){

        while(true){
              Console.WriteLine("Welcome!");
            Console.WriteLine("Enter the account(Admin/Customer/exit)");
            Assignment.account=Console.ReadLine();
            if(Assignment.account=="exit"){
                break;
            }
            else{
                Assignment.input(Assignment.account);
            }
        }
    }
}
}
       
   