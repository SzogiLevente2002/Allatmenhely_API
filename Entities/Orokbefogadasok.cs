using System.ComponentModel.DataAnnotations;

namespace Allatmenhely_API.Entities
{
    public class Orokbefogadasok
    {
        
        public int Id { get; set; }

        
        public DateTime AdoptionDate { get; set; }

        public int AnimalId { get; set; }
        
        public string AdopterName { get; set; }
        public string AdopterContactInfo { get; set; }
    }
}
