namespace ResidentBookmark.Models
{
    public class Website
    {
        public int WebsiteId { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required, MaxLength(200), RegularExpression("(\b(https?|ftp|file)://)?[-A-Za-z0-9+&@#/%?=~_|!:,.;]+[-A-Za-z0-9+&@#/%=~_|]")]
        public string Location { get; set; }

        [Required, MaxLength(60)]
        public string Note { get; set; }

        public int LabelId { get; set; }

        //Navigational Property
        public Label Label { get; set; }
    }
}