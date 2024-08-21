using Microsoft.EntityFrameworkCore;
using PhotoGallery.API.DbContexts;
using PhotoGallery.API.Entities;

namespace PhotoGallery.API.Repositories;

public class GalleryRepository(GalleryContext context) : IGalleryRepository
{
    private readonly GalleryContext _context = context ?? throw new ArgumentNullException(nameof(context));

    public void AddImage(Image image)
    {
        _context.Images.Add(image);
    }

    public void DeleteImage(Image image)
    {
        _context.Images.Remove(image);

        // Note: in a real-life scenario, the image itself potentially should 
        // be removed from disk.  We don't do this in this demo
        // scenario to allow for easier testing / re-running the code
    }

    public async Task<Image?> GetImageAsync(Guid id)
    {
        return await _context.Images.FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task<IEnumerable<Image>> GetImagesAsync()
    {
        return await _context.Images
            .OrderBy(i => i.Title).ToListAsync();
    }

    public async Task<bool> ImageExistsAsync(Guid id)
    {
        return await _context.Images.AnyAsync(i => i.Id == id);
    }

    public async Task<bool> IsImageOwnerAsync(Guid id, string ownerId)
    {
        return await _context.Images
            .AnyAsync(i => i.Id == id && i.OwnerId == ownerId);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return (await _context.SaveChangesAsync() >= 0);
    }

    public void UpdateImage(Image image)
    {
        throw new NotImplementedException();
    }
}
