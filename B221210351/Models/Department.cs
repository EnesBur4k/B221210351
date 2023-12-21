namespace B221210351.Models
{
    public class Department
    {
        Department()
        {
            Policlinics = new HashSet<Policlinic>();
        }
        public int DepartmentId { get; set; }
        public string Ad { get; set; }

        public ICollection<Policlinic> Policlinics { get; set; }
    }
}