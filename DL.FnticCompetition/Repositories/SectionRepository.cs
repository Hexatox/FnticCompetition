using DL.FnticCompetition.Models;
using Microsoft.EntityFrameworkCore;

namespace DL.FnticCompetition.Repositories;


public class SectionRepository
{
    private readonly AttendanceDbContext _context;

    public SectionRepository(AttendanceDbContext context)
    {
        _context = context;
    }

    // CREATE: Add a new section to the database
    public async Task<Section> AddSectionAsync(Section section)
    {
        if (section == null) throw new ArgumentNullException(nameof(section));

        await _context.Sections.AddAsync(section);
        await _context.SaveChangesAsync();
        return section;
    }

    // READ: Get a section by its ID
    public async Task<Section> GetSectionByIdAsync(int sectionId)
    {
        return await _context.Sections
            .FirstOrDefaultAsync(s => s.SectionID == sectionId);
    }

    // READ: Get all sections
    public async Task<List<Section>> GetAllSectionsAsync()
    {
        return await _context.Sections
            .ToListAsync();
    }

    // UPDATE: Update an existing section
    public async Task<Section> UpdateSectionAsync(Section section)
    {
        if (section == null) throw new ArgumentNullException(nameof(section));

        _context.Sections.Update(section);
        await _context.SaveChangesAsync();
        return section;
    }

    // DELETE: Delete a section by its ID
    public async Task<bool> DeleteSectionAsync(int sectionId)
    {
        var section = await GetSectionByIdAsync(sectionId);
        if (section == null) return false;

        _context.Sections.Remove(section);
        await _context.SaveChangesAsync();
        return true;
    }
}