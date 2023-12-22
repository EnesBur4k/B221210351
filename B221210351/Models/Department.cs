namespace B221210351.Models
{
    public class Department
    {
        public Department()
        {
            Policlinics = new HashSet<Policlinic>();
        }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public ICollection<Policlinic> Policlinics { get; set; }
    }
}