namespace Car.DAL.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public byte[] Image { get; set; }
        public string Valume { get; set; }
        public string Color { get; set; }
        public string Transmission { get; set; }

        public string ModelName { get; set; }
        public Model Model { get; set; }
    }
}
