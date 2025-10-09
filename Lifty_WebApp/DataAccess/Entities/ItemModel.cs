namespace Lifty_WebApp.DataAccess.Entities
{
    public class ItemModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Delivery { get; set; }
        public string Payment { get; set; }
        public string Description { get; set; }
        public List<string> StatParameters { get; set; }
        public List<string> StatValues { get; set; }

        public List<string> ImgPath { get; set; }
    }
}
