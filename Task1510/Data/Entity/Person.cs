namespace Task1510.Data.Entity
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? SpecialModelID { get; set; }
        public SpecialModel? SpecialModel { get; set; }
    }
}
