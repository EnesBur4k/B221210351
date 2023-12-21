namespace B221210351.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int BirthDay { get; set; }
        public bool Gender { get; set; }
        public int PersonalId { get; set; }
        public Address Address { get; set; }
    }
}
