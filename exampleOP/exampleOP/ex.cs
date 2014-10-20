using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exampleOP
{
    class ex
    {
        public string id { get; private set; }
        public int x { get; set; }
        public int y { get; set; }

        public ex()
        { }
        public ex(string id)
        {
            this.id = id;
        }
        public ex(int x, int y, string id):this(id)    
        {
            this.x = x;
            this.y = y;
            this.id = id;
        }
        public void changeID(ref String id)
        {
            this.id = id;
        }
       
    }
    class derived: ex
    { }
}
