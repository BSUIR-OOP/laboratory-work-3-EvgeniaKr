using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Class
{
    [SerelezClass]
    public abstract class ListFigures
    {
        private int p;
        private int s;
        private string name;
        
        public int P { get => p; set => p = value; }
        public int S { get => s; set => s = value; }
        public string Name { get => name; set => name = value; }
        public abstract string strname();
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("P", P, typeof(string));
            info.AddValue("S", S, typeof(string));

            info.AddValue("Name", Name, typeof(string));
        }
    }
}
