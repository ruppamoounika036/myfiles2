namespace Assign_2;
 [Serializable]
public class ItemOutofRange
{
    
   
    class ItemOutofRangeException : Exception{
        public ItemOutofRangeException(){
        }
        public ItemOutofRangeException(string name)
        :base(String.Format("ItemOutofRangeException.Limit Exceeded.Expected upto 5 characters : {0}", name)){
        }
    }
}

