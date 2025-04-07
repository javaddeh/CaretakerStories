using CaretakerStories.Data;
using CaretakerStories.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

public class IndexModel : PageModel
{
    private readonly AppDbContext _context;

    public IndexModel(AppDbContext context) => _context = context;

    public List<Story> Stories { get; set; } = new();

    public async Task OnGetAsync()
    {
        Stories = await _context.Stories
            .OrderByDescending(s => s.UpdatedAt)
            .ToListAsync();
    }
}
