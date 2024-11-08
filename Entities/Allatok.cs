using System.ComponentModel.DataAnnotations;

namespace Allatmenhely_API.Entities
{
    public class Allatok
    {
        public int Id { get; set; }

        
        public string Name { get; set; }

        [Required]
        public string Species { get; set; }


        public int Age { get; set; }

        
        public DateTime ArrivalDate { get; set; }

        public string HealthStatus { get; set; }


        public bool IsAdopted { get; set; } = false;

        public int? CareTaker { get; set; }

        public virtual Orokbefogadasok Orokbefogadasok { get; set; }

        public virtual Gondozok Gondozok { get; set; }

    }
}
