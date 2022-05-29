using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace WindowsFormsApp1.Class
{
    [Serializable]
    public class Ellipse : ListFigures
    {
        public Ellipse()
        {

        }
        public Ellipse(SerializationInfo info, StreamingContext context)
        {
            P = (int)info.GetValue("P", typeof(int));
            S = (int)info.GetValue("S", typeof(int));
            Name = (string)info.GetValue("Name", typeof(string));
        }
        public override string strname()
        {
            return "Ellipse";
        }
    }
}
