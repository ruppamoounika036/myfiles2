using Assign_2;
class MyApp{
    public static void Main(){
        string? choice;
        while(true){
            Console.WriteLine("Enter your choice:\n1.customer\n2.admin\n3.exit):");
            choice = Console.ReadLine();
            switch(choice){
                case "1":
                CustomerDetails c = new CustomerDetails();
                c.start();
                c.GetInput();
                c.Display();
                break;
                case "2":
                Admin.ChooseOption();
                break;
                case "3":
                break;
                default:
                Console.WriteLine("Enter a valid input");
                break;
            }
            if(choice == "exit")
            break;
        }
    }
}