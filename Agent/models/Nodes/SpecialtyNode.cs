using Agent.models.Layers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent.models.Nodes
{
    public class SpecialtyNode
    {
        public List<SpecialLayer> layers;
        public List<InputSpecialLayer> Interfaces;

        public SpecialtyNode(int inputsize,int outputsize, int[] layers, int density = 8,bool singleSided = false)
        {
            this.layers = new List<SpecialLayer>();
            this.Interfaces = new List<InputSpecialLayer>();

            foreach(int i in layers)
            {
                this.layers.Add(new SpecialLayer(i));
            }
            this.Interfaces.Add(new InputSpecialLayer(inputsize));
            this.Interfaces.Add(new InputSpecialLayer(outputsize));

            this.Interfaces.First().MateLayer(this.layers.First(),1);
            if (singleSided)
            {
                this.Interfaces.Last().MateLayer(this.layers.First(), 1);
            }
            else
            {
                this.Interfaces.Last().MateLayer(this.layers.Last(), 1);
            }


        }
    }
}
