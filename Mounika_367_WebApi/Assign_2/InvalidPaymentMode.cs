namespace Assign_2;

// public class InvalidPaymentMode
// {
      [Serializable]
    public class InvalidPayementModeException : Exception{
        public InvalidPayementModeException(){
        }
        public InvalidPayementModeException(string? name)
        :base(string.Format("InvalidPayementModeException.Expected cash/card/wallwt/netbanking.Invalid Input , {0}",name)){
        }
    }
// }
