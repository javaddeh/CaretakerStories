using CaretakerStories.Data;
using CaretakerStories.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class DetailsModel : PageModel
{
    private readonly AppDbContext _context;

    public DetailsModel(AppDbContext context) => _context = context;

    public Story? Story { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        Story = await _context.Stories.FindAsync(id);
        return Story == null ? NotFound() : Page();
    }
}
