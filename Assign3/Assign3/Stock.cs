using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Assign3
{
    class Stock
    {
        private string _name;
        private int _initialVal;
        private int _currentVal;        
        private int _maxChange;
        private int _threshold;
        private Thread thread;
        private int _changes;
        
        public Stock(string name, int initialVal, int maxChange, int threshold)
        {
            this._name = name;
            this._initialVal = initialVal;
            this._currentVal = _initialVal;
            this._maxChange = maxChange;
            this._threshold = threshold;
            thread = new Thread(new ThreadStart(Activate));
            thread.Start();
        }        
        private void Activate()
        {
            for (; ; )
            {
                Thread.Sleep(50);
                changeStockValue();
            }
            //throw new NotImplementedException();
        }
        public void changeStockValue()
        {
            Random ran = new Random();
            int changeInValue = 0;
            _currentVal +=ran.Next(-(_maxChange), _maxChange);
            changeInValue = (Math.Abs(_currentVal - _initialVal));            
            _changes += 1;
            if (changeInValue >= _threshold)
            {                
                StockNotificationEventArgs args = new StockNotificationEventArgs(_name, _initialVal, _currentVal, changeInValue, _changes);              
                OnFireEvent(args);
                //_changeInValue = 0;
               // _initialVal = _currentVal;
            }
            
            
        }
        protected virtual void OnFireEvent(StockNotificationEventArgs e)
        {
            StockNotificationHandler handler = StockEvent;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public event StockNotificationHandler StockEvent;


    }
    public class StockNotificationEventArgs : EventArgs
    {
        private string _name;
        private int _initialVal;
        private int _currentVal;
        private int _difference;
        private int _changes;
        public StockNotificationEventArgs(string name, int initialVal, int currentVal, int difference, int changes)
        {
            this._name = name;
            this._initialVal = initialVal;
            this._currentVal = currentVal;
            this._difference = difference;
            this._changes = changes;
        }
        public string Name{
            get { return _name; }
            set { _name = value; }
        }
        public int InitialValue
        {
            get { return _initialVal;  }
            set { _initialVal = value; }
        }
        public int CurrentValue
        {
            get { return _currentVal; }
            set { _currentVal = value; }
        }
        public int Difference
        {
            get { return _difference; }
            set { _difference = value; }
        }
        public int Changes
        {
            get { return _changes; }
            set { _changes = value; }
        }

    }
   public delegate void StockNotificationHandler(Object sender, StockNotificationEventArgs e);
}


//public string StockName{
//            get{
//                return _name;
//            }
//            set{
//                _name=value;
//            }
//        }
//        public int InitialValue{
//            get{
//                return _initialVal;
//            }
//            set{
//                 _initialVal =value;
//            }
//        }
//        public int MaxChange{
//            get{
//                return _maxChange;
//            }
//            set{
//               _maxChange =value;
//            }
//        }
//        public int Threshold{
//            get{
//                return _threshold ;
//            }
//            set{
//               _threshold =value;
//            }
//        }