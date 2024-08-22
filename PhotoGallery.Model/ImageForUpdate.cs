using System.ComponentModel.DataAnnotations;

namespace PhotoGallery.Model;

public class ImageForUpdate (string title)
{
    [Required]
    [MaxLength(150)]
    public string Title { get; set; } = title;
}
