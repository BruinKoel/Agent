using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent.models.Cells
{
    public class InputSpecial : Specialty
    {
        public float value;
        public float expectedValue;
        bool isFixed;

        List<Specialty> connections;

        public InputSpecial()
        {
            connections = new List<Specialty>();
        }
    }
}
