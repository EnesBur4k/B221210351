namespace B221210351.Models
{
    public class Department
    {
        Department()
        {
            Poliklinikler = new HashSet<Policlinic>();
        }
        public int AnabilimDaliId { get; set; }
        public string Ad { get; set; }

        public ICollection<Policlinic> Poliklinikler { get; set; }
    }
}