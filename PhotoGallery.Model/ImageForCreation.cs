using System.ComponentModel.DataAnnotations;

namespace PhotoGallery.Model;

public class ImageForCreation(string title, byte[] bytes)
{
    [Required]
    [MaxLength(150)]
    public string Title { get; set; } = title;

    [Required]
    public byte[] Bytes { get; set; } = bytes;
}
