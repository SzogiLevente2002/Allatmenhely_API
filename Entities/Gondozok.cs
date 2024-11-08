using System.ComponentModel.DataAnnotations;

namespace Allatmenhely_API.Entities
{
    public class Gondozok
    {
        
        public int Id { get; set; }

        public string Name { get; set; }

        public string ContactInfo { get; set; }

        public int  PhoneNumber { get; set; }
    }
}

