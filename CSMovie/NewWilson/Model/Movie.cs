using System.Drawing;
namespace Model
{
    public class Movie
    {
        public string Id { get; set; } 
        public string Name { get; set; } 
        public byte MovieTypeId { get; set; } 
        public byte Duration { get; set; } 
        public Image Poster { get; set; } 
        public string MovieTypeName { get; set; }
    }
}
