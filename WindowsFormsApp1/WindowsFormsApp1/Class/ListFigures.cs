using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Class
{
    [Serializable]
    public abstract class ListFigures
    {
        private int p;
        private int s;
        private string name;
        
        public int P { get => p; set => p = value; }
        public int S { get => s; set => s = value; }
        public string Name { get => name; set => name = value; }
        public abstract string Sound();
    }
}
