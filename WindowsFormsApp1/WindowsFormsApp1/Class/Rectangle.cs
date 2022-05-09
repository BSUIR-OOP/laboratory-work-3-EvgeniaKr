using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Class
{
    [Serializable]
    public class Rectangle : ListFigures
    {
        public override string Sound()
        {
            return "Meow";
        }
    }
}
