using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCrud.Helpers
{
    public static partial class Extension
    {
       static public  int ReadInteger(string caption, bool checkInterval=false, int minValue=0, int maxValue=2500)
        {
            int value;
            l1:
            Console.Write(caption);
            if(!int.TryParse(Console.ReadLine(),out value))
            {
                goto l1;

            }
            if(!checkInterval&&(value<minValue|| value>maxValue))
            {
                Console.WriteLine($"{value} bu intervalda deyildir [{minValue}, {maxValue}]");
                goto l1;
                
            }
            return value;
        }
        static public string ReadString(string caption)
        {
            Console.Write(caption);
            
            return Console.ReadLine();
        }

        static public decimal ReadDecimal(string caption, bool checkInterval = false, decimal minValue = 0)
        {
            decimal value;
        l1:
            Console.Write(caption);
            if (!decimal.TryParse(Console.ReadLine(), out value))
            {
                goto l1;

            }
            if (checkInterval && (value < minValue))
            {
                Console.WriteLine($"{value} bu intervalda deyildir [{minValue}, ");
                goto l1;
            }
            return value;
        }


    }
}
