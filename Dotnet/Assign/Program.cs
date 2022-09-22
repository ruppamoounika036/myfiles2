namespace DunzoNamespace{
    public static class Assignment{
        public static string? package_name;
        public static int pin_code;
        public static string[] item_code = new string[10];
        public static double[] item_weight = new double[10];
        public static void input(){
            Console.WriteLine("Enter the package name: ");
            package_name=Console.ReadLine();
            Console.WriteLine("Enter the pincode: ");
            pin_code=Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Enter item details: ");
            int i=0;
            while(i<10){
                Console.WriteLine("Enter item code: (Enter end to exit)");
                string? sam;
                sam=Console.ReadLine();
                if(sam=="end"){
                    break;
                }
                else{
                    item_code[i]=sam;
                    Console.WriteLine("Enter item weight: ");
                    item_weight[i]=Convert.ToInt16(Console.ReadLine());
                    i++;
                }
            }

        }
        public static void details(){
            Console.WriteLine("Your order details: ");
            Console.WriteLine($"Package Name: {package_name}");
            Console.WriteLine($"Pincode: {pin_code}");
            Console.WriteLine($"Items weight: {item_weight.Sum()}");
            Console.WriteLine("Your details: ");
            for(int j = 0;j<item_code.Length;j++){
             Console.WriteLine($"{item_code[j]}");
            }
        }
    }
class Dunzo{
     public static void Main(){
            Assignment.input();
            Assignment.details();
            }
    }
}
