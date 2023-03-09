using Agent.models.Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent.models.Layers
{
    public class SpecialLayer
    {
        public List<Specialty> cells;

        public SpecialLayer(int size)
        {
            cells = new List<Specialty>(size);
            for (int i = 0; i < size; i++)
            {
                cells.Add(new Specialty());
            }
        }
        public void Normalize()
        {
            foreach(Specialty cell in cells)
            {
                cell.Normalize();
            }
        }

        public void MateLayer(SpecialLayer layer, int density)
        {
            for(int j = 0; j < cells.Count; j++)
            {
                for(int i = 0; i < density; i++)
                {
                    int index = (j + i) % layer.cells.Count;

                    cells[j].Connect(layer.cells[index]);

                }
            }
        }
    }
}
