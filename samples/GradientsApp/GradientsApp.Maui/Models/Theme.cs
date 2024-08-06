using LiteDB;

namespace GradientsApp.Maui.Models
{
    public class Theme
    {
        public int Id { get; set; }

        [BsonField("color")]
        public string Color { get; set; }
    }
}
