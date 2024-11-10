using DL.FnticCompetition.Models;
using Microsoft.EntityFrameworkCore;

namespace DL.FnticCompetition.Repositories;
public class GroupRepository 
{
    private readonly AttendanceDbContext _context;

    public GroupRepository(AttendanceDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Group>> GetAllGroupsAsync()
    {
        return await _context.Groups.Include(g => g.Batch).ToListAsync();
    }

    public async Task<Group> GetGroupByIdAsync(int id)
    {
        return await _context.Groups.Include(g => g.Batch)
            .FirstOrDefaultAsync(g => g.GroupID == id);
    }

    public async Task AddGroupAsync(Group group)
    {
        _context.Groups.Add(group);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateGroupAsync(Group group)
    {
        _context.Groups.Update(group);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteGroupAsync(int id)
    {
        var group = await _context.Groups.FindAsync(id);
        if (group != null)
        {
            _context.Groups.Remove(group);
            await _context.SaveChangesAsync();
        }
    }
}