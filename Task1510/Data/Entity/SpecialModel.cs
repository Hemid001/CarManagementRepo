namespace Task1510.Data.Entity
{
    public class SpecialModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MarkaID { get; set; }
        public Marka Marka { get; set; }
    }
}
