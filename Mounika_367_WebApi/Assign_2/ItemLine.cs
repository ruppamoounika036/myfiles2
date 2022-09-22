namespace Assign_2;

public static class ItemLine
{
     public static decimal[] GetSubTotal(int count, decimal[] items_price,double[] items_qnt){
            decimal[] item_subtotal = new decimal[count];
            for(int i=0;i<count;i++){
                item_subtotal[i]=items_price[i]*Convert.ToDecimal(items_qnt[i]);
            }
            return item_subtotal;
        }
}
