using CaretakerStories.Data;
using CaretakerStories.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class EditModel : PageModel
{
    private readonly AppDbContext _context;

    public EditModel(AppDbContext context) => _context = context;

    [BindProperty]
    public Story? Story { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        Story = await _context.Stories.FindAsync(id);
        return Story == null ? NotFound() : Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (Story == null || !ModelState.IsValid) return Page();

        var existing = await _context.Stories.FindAsync(Story.Id);
        if (existing == null) return NotFound();

        existing.Title = Story.Title;
        existing.Content = Story.Content;
        existing.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();
        return RedirectToPage("Index");
    }
}
