namespace Goudkoorts
{
    public class Track : ImmovableObject
    {
        public Track() : base()
        {
            CanBePlaced = true;
        }

        public override bool CanBePlaced { get { return _CanBePlaced; } set { _CanBePlaced = value; } }

    }
}