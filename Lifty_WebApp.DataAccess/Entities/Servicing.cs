using System.ComponentModel.DataAnnotations;

namespace Lifty_WebApp.DataAccess.Entities
{
    public class Servicing
    {
        [Key]
        public int Id { get; set; }
        public int Name { get; set; }
        public List<string> Description { get; set; }
    }
}
