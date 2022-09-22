namespace Assign_2;

 class Discount{
        public static double GetPayableAmount(DateTime startTime , DateTime endTime , double wdTotal ,double invoice,int pay){
            double payable = invoice;
            if (Customer.IsPrimeCustomer(startTime,endTime)){
                if (wdTotal > 1500){
                    payable = 0.9 * invoice;
                }
                else if (wdTotal <= 1500 && wdTotal >= 1000){
                    payable = invoice - 50;
                }
            }
            else{
                if (pay == 1){
                    payable = 0.97 * invoice;
                }
            }
            return payable;
        }
    }
