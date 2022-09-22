namespace Assign_2;

// public class Input
// {
      static class Input{
        public static string GetInputString(){
            string? temp = Console.ReadLine();
            if (temp != ""){
                try{
                    int i = Convert.ToInt32(temp);
                    Console.WriteLine("Enter a valid input string(not an  integer or value with presicion)");
                    return GetInputString();
                }
                catch (Exception e){
                    return temp;
                }
            }
            else{
                Console.WriteLine("Enter a valid input string(not an empty string)");
                Console.WriteLine("Enter your input");
                return GetInputString();
            }
        }
        public static int GetInputInt(){
            try{
                int temp = Convert.ToInt32(Console.ReadLine());
                return temp;
            }
            catch(FormatException e){
                Console.WriteLine("Enter a valid integer(characters not allowed!!)");
                Console.WriteLine("Enter your input");
                return GetInputInt();
            }
        }
        public static double GetInputDouble(){
            try{
                double temp = Convert.ToDouble(Console.ReadLine());
                return temp;
            }
            catch(FormatException e){
                Console.WriteLine("Enter a valid double(characters not allowed!!)");
                Console.WriteLine("Enter your input");
                return GetInputDouble();
            }
        }
        
    }
// }
