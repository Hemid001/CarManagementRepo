namespace Task1510.Data.Entity
{
    public class Marka
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<SpecialModel> SpecialModels { get; set; }

    }
}
