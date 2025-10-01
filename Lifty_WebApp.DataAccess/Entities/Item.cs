using System.ComponentModel.DataAnnotations;

namespace Lifty_WebApp.DataAccess.Entities
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        public int Name { get; set; }
        public string Brand { get; set; }
        public string Delivery { get; set; }
        public string Payment { get; set; }
        public Dictionary<string,string> Stat { get; set; }
        public string Description { get; set; }

        public List<string> ImgPath { get; set; }
    }
}
