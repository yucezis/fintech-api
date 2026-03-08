using Microsoft.EntityFrameworkCore;
using ZenBudget.Domain.Entities;
using ZenBudget.Domain.Interfaces;
using ZenBudget.Infrastructure.Persistence;

namespace ZenBudget.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext _context;

    public CategoryRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Category>> GetByUserIdAsync(Guid userId, TransactionType? type = null)
    {
        var all = await _context.Categories.ToListAsync();
        Console.WriteLine($"DEBUG - Toplam kategori: {all.Count}");
        Console.WriteLine($"DEBUG - UserId null olanlar: {all.Count(c => !c.UserId.HasValue)}");
        Console.WriteLine($"DEBUG - Bu kullanıcıya ait: {all.Count(c => c.UserId == userId)}");

        var query = _context.Categories
            .Where(c => c.UserId == userId || !c.UserId.HasValue);

        if (type.HasValue)
            query = query.Where(c => c.Type == type.Value);

        return await query
            .OrderBy(c => c.IsSystem ? 0 : 1)
            .ThenBy(c => c.Name)
            .ToListAsync();
    }

    public async Task AddAsync(Category category)
    {
        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id, Guid userId)
    {
        var category = await _context.Categories
            .FirstOrDefaultAsync(c => c.Id == id && c.UserId == userId);

        if (category != null)
        {
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }
    }


    public async Task<bool> AnyAsync(Guid id) => await _context.Categories.AnyAsync(c => c.Id == id);
}