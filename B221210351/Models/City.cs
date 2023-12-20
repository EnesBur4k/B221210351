namespace B221210351.Models
{
    public class City
    {
        City()
        {
            Ilceler = new HashSet<District>();
        }
        public int IlId { get; set; }
        public ICollection<District> Ilceler { get; set; }
    }
}