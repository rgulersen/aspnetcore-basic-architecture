namespace AspnetCoreBasicArchitecture.Model
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public int Code { get; set; }
        public double Price { get; set; }
    }
}
