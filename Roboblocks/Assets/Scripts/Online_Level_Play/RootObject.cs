using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Online_Level_Play
{
    class RootObject
    {
            public int id { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public DateTime date { get; set; }
            public List<Object> objects { get; set; }
            public object ratings { get; set; }
            public object user { get; set; }
            public int rating { get; set; }
            public object username { get; set; }
        
    }
}
