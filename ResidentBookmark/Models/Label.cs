namespace ResidentBookmark.Models
{
    public partial class Label
    {
        public int LabelId { get; set; }

        [Required, MaxLength(50)]
        public string? Name { get; set; }

        [Required, MaxLength(60)]
        public string? Description { get; set; }

        //Navigational Property
        public virtual List<Website>? Websites { get; set; }
    }
}