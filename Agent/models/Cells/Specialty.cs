namespace Agent.models.Cells
{
    public class Specialty
    {
        public List<(float, Specialty)> connections;

        public float value;
        public float bias;

        public Specialty()
        {
            connections = new List<(float, Specialty)>();
        }

        public void Normalize()
        {
            float factor = connections.Sum(x => x.Item1);
            connections.Select(x => x.Item1 /= factor);
        }

        public void Connect(Specialty cell)
        {
            connections.Add(new(1, cell));
            cell.connections.Add(new(1, this));
        }
    }
}
