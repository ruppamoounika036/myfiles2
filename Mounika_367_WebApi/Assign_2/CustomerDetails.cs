namespace Assign_2;
using System;
using System.Net.Http;
    public enum payment{
        cash = 1,
        card,
        wallet,
        netbank
    }
    public class CustomerDetails{
        public string? name;
        public string? packageName;
        public int? pincode;
        public DateTime Otime;
        public string[]? items = new string[10];
        public double[] items_qnt = new double[10];
        public decimal[] items_price = new decimal[10];
        public bool[] item_disc = new bool[10];
        public decimal[] item_subtotal = new decimal[10];
        public DateTime startTime;
        public DateTime endTime;
        public int pay;
        public double GTotal;
        public double Wdtotal;
        public string? disc;
        public int count;
        public double payable;
        public string path = @"C:\Users\jyoshna.korada\Desktop\Assignment\ObjectApp\Data\data.json";
        public int OrderID = 1;
        
        public string GetName(){
            try{
                Console.WriteLine("Enter Item name/(allowed upto 5 character)/enter 'end' to exit");
                string temp = Input.GetInputString();
                if(temp.Length > 5){
                    throw new ItemOutofRangeException(temp);
                }
                return temp;
            }
            catch(ItemOutofRangeException e){
                Console.WriteLine(e);
                return GetName();
            }
        }
        public double GetPrice(){
            try{
                double temp = Input.GetInputDouble();
                if(temp > 10000){
                    throw new ItemPriceOutOfRangeException(temp);
                }
                return temp;
            }
            catch(ItemPriceOutOfRangeException e){
                Console.WriteLine(e);
                Console.WriteLine("Enter the item price (couldn't be more than 10000)");
                return GetPrice();
            }
        }
        public bool GetDiscount(){
             disc = Input.GetInputString().ToUpper();
            if(disc!="Y" && disc!="N"){
                Console.WriteLine("Enter only(Y/N):");
                return GetDiscount();
            }
            return disc=="Y";
        }
        public void start(){
            Console.WriteLine("Welcome to Customer Mode!!!!");
        }
        public DateTime GetStartDate(){
            try{
                Console.WriteLine("StartDate:");
                DateTime d = Convert.ToDateTime(Console.ReadLine());
                if(d>DateTime.Now){
                    Console.WriteLine("Start Date of prime membership is not a valid date. Seems like its reffering to the future");
                    Console.WriteLine("Please enter a valid date");
                    return GetStartDate();
                }
                return d;
            }
            catch(Exception e){
                Console.WriteLine("Please enter a valid date");
                return GetStartDate();
            }
        }
        public DateTime GetEndDate(){
            try{
                Console.WriteLine("EndDate:");
                DateTime d = Convert.ToDateTime(Console.ReadLine());
                if(d <= startTime){
                    Console.WriteLine("End Date of prime membership is not a valid date. Seems like its reffering to the past");
                    Console.WriteLine("Please enter a valid date");
                    return GetEndDate();
                }
                return d;
            }
            catch(Exception e){
                Console.WriteLine("Please enter a valid date");
                return GetEndDate();
            }
        }
        public void GetInput(){
            int i=0;
            Console.WriteLine("Enter Your Name..");
            name = Input.GetInputString();
            Console.WriteLine("Enter the item details");
            do{
                string? temp = GetName();
                if (temp.ToLower() == "end"){
                    Console.WriteLine("On your request we terminated the taking of input");
                    break;
                }
                items[i] = temp;
                Console.WriteLine($"Enter the {temp} quantity(Example: 2,3.5,..)");
                items_qnt[i] = Input.GetInputDouble();
                Console.WriteLine($"Enter the {temp} price(Example : 25.09,100.00,....)/(couldn't be more than 10000)");
                items_price[i] = Convert.ToDecimal(GetPrice());
                Console.WriteLine("Is item eligible for discount(Y/N)?");
                item_disc[i] = GetDiscount();
                i++;
            }while(i<=9);
            count = i;
            Console.WriteLine("Enter Prime Membership details");
            startTime = GetStartDate();
            endTime = GetEndDate();
            Console.WriteLine("Enter Payment Mode");
            pay = Order.GetPaymentMode();
            item_subtotal = ItemLine.GetSubTotal(count,items_price,items_qnt);
            GTotal = Order.GetTotal(item_subtotal,count);
            Wdtotal = Order.GetTotalWD(item_disc,item_subtotal,count);
            payable = Discount.GetPayableAmount(startTime,endTime,Wdtotal,GTotal,pay);
    }
    public async void Display(){
        Console.WriteLine("Enter packageName");
       packageName = Input.GetInputString();
        Console.WriteLine("enter the pincode");
        pincode = Input.GetInputInt();
        Customer Obj = new Customer(){
                    Name = name,
                    StartDate = startTime,
                    EndDate = endTime,
                    PackageName = packageName,
                    Pincode = (int)pincode,
                    paymode = pay
                };

        var url = "https://localhost:7055/Customer/PostCustomerDetails";
        var client = new HttpClient();

        var response = await client.PostAsJsonAsync<Customer>(url,Obj);

        var result = await response.Content.ReadAsStringAsync();
        Console.WriteLine(result);

    }
    }   
