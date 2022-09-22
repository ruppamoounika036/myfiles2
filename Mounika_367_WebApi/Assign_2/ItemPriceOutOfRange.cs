namespace Assign_2;

// namespace ObjectApp
// {
    [Serializable]
    public class ItemPriceOutOfRangeException : Exception{
        public ItemPriceOutOfRangeException(){
        }
        public ItemPriceOutOfRangeException(double price)
        :base(string.Format("ItemPriceOutOfRangeException.Expected upto 1000.Limit Exceeded,{0}",price)){
        }
    }
    
// }
