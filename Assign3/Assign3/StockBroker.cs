using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assign3
{
    
    class StockBroker
    {
       
      
       private List<Stock> stocks = new List<Stock>();
       private string _name;
       myFile write = new myFile();
 
       public StockBroker(string name)
       {
           this._name = name;
          
       }
       public void AddStock(Stock s)
       {

           stocks.Add(s);
          s.StockEvent += HandleCustomEvent; 
          
       }

       void HandleCustomEvent(object sender, StockNotificationEventArgs e)
       {
           Console.WriteLine("{0} \t {1} \t {2} \t {3} \t {4} \t {5}", _name, e.Name, e.InitialValue, e.CurrentValue, e.Difference, e.Changes);
           StringBuilder sb = new StringBuilder();
           DateTime now = DateTime.Now;
           sb.Append("Written on ->" + now.ToString()+"\t");
           sb.Append(_name + "\t");
           sb.Append(e.Name + "\t");
           sb.Append(e.InitialValue.ToString() + "\t");
           sb.Append(e.CurrentValue.ToString()+"\t");
           sb.Append(e.Difference.ToString() + "\t");
           sb.Append(e.Changes.ToString() + "\t");
           write.writeToFile(sb.ToString());
       }
       
       public string StockBrokerName
       {
           get
           {
               return _name;
           }
           set
           {
               _name = value;
           }
       }
    }
}
