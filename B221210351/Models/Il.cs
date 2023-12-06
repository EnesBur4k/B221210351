namespace B221210351.Models
{
    public class Il
    {
        Il()
        {
            Ilceler = new HashSet<Ilce>();
        }
        public int IlId { get; set; }
        public ICollection<Ilce> Ilceler { get; set; }
    }
}