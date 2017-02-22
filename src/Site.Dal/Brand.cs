namespace Site.Dal
{
    public class Brand
    {
        public Brand()
        {
        }
        public Brand(string description)
        {
            Description = description;
        }
        public Brand(int id, string description)
        {
            Id = id;
            Description = description;
        }
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
