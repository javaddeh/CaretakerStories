using CaretakerStories.Data;
using CaretakerStories.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class CreateModel : PageModel
{
    private readonly AppDbContext _context;

    public CreateModel(AppDbContext context) => _context = context;

    [BindProperty]
    public Story Story { get; set; } = new();

    public IActionResult OnGet() => Page();

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        Story.CreatedAt = Story.UpdatedAt = DateTime.UtcNow;
        _context.Stories.Add(Story);
        await _context.SaveChangesAsync();
        return RedirectToPage("Index");
    }
}
