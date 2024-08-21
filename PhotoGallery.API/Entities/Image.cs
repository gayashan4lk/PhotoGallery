using System.ComponentModel.DataAnnotations;

namespace PhotoGallery.API.Entities;

public class Image
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(255)]
    public string Title { get; set; } = string.Empty;

    [Required]
    [MaxLength (255)]
    public string FileName { get; set; } = string.Empty;

    [Required]
    [MaxLength(255)]
    public string OwnerId { get; set; } = string.Empty;
}
