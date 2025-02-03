using System.Runtime.InteropServices;

public class Sum 
{
    private int _number = 0;
    private int _sum = 0;
 
    public int CalculateSum(int n, int i)
    {
        _sum = _sum + (n + i);
        i++;
        n--;
         if (n-i >= 1)
         {
            CalculateSum(n, i);
         }
         return _sum;
    }
    
}