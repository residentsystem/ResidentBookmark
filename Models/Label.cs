using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ResidentBookmark.Models
{
    public class Label
    {
        public int LabelId { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; } 

        [Required, MaxLength(60)]
        public string Description { get; set; }

        //Navigational Property
        public List<Website> Websites { get; set; }
    }
}