using Agent.models.Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent.models.Layers
{
    public class InputSpecialLayer : SpecialLayer
    {

        public InputSpecialLayer(int size) 
        {
            cells = new List<InputSpecial>();

            for (int i = 0; i < size; i++)
            {
                cells.Add(new InputSpecial());
            }
        }

    }
}
