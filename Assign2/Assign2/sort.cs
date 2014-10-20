//sort.cs

using System;

public class sort
{
    public delegate bool Comparing(int a,int b);
    public static void bubblesort(IPayable [] tmp, Comparing c)
    {
        IPayable temp;
        for (int i = 0; i < tmp.Length; i++)
        {            
            for (int j = 0; j < tmp.Length-1; j++)
            {                
                if (c(tmp[j].getSSN(), tmp[j + 1].getSSN()))
                {                   
                    temp = tmp[j + 1];
                    tmp[j + 1] = tmp[j];
                    tmp[j] = temp;
                }            
            }                     
        }
    }
    public static bool greaterThan(int a, int b){
        return a > b;
    }
}

/*
 *
 * 
*/