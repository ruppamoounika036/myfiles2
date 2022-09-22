namespace Assign_2;

// namespace ObjectApp
// {
    class Order{
        public static double GetTotal(decimal[] item_subtotal,int count){
            double GTotal =0;
            for(int i =0; i< count; i++){
                GTotal+=Convert.ToDouble(item_subtotal[i]);
            }
            return GTotal;
        }
        public static int GetPaymentMode(){
            try{
                Console.WriteLine("Payment Mode:/n 1.cash /n 2.card /n 3.wallet /n 4.netbank /n Enter a number");
                int temp = Convert.ToInt32(Console.ReadLine());
                if(temp<1 || temp>4){
                    throw new InvalidPayementModeException(Convert.ToString((payment)temp));
                }
                return temp;
            }
            catch(InvalidPayementModeException e){
                Console.WriteLine(e);
                return GetPaymentMode();
            }
            catch(FormatException e){
                Console.WriteLine("Input accepted is only an int from above.please choose wisely");
                return GetPaymentMode();
            }
        }
        public static double GetTotalWD(bool[] item_disc , decimal[] item_subtotal , int count){
            double Wdtotal=0;
            for(int i =0; i< count; i++){
                if(item_disc[i]){
                    Wdtotal+=Convert.ToDouble(item_subtotal[i]);
                }
            }
            return Wdtotal;
        }
    }
// }