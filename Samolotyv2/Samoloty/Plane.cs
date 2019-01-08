namespace Samoloty
{
    public class Plane
    {
        public int id;
        public bool hasLanded;
        public int fuel;
        public int landingPadNumber;

        public Plane (int ID, int Fuel)
        {
            id = ID;
            hasLanded = false;
            landingPadNumber = 0;
            fuel = Fuel;
        }

        public override bool Equals(object obj)
        {
            Plane other = obj as Plane;
            if (other == null) return false;
            if (this.id != other.id) return false;
            if (this.fuel != other.fuel) return false;
            if (this.hasLanded != other.hasLanded) return false;
            return true;
        }

        public override int GetHashCode()
        {
            return int.MaxValue % (id * fuel);
        }
    }
}