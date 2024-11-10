using DL.FnticCompetition.Models;
using DL.FnticCompetition.Repositories;

namespace BL.FnticCompetition.Services;

public class SectionService
{
    private readonly SectionRepository _sectionRepository;

    public SectionService(SectionRepository sectionRepository)
    {
        _sectionRepository = sectionRepository;
    }

    public async Task<IEnumerable<Section>> GetAllSectionsAsync()
    {
        return await _sectionRepository.GetAllSectionsAsync();
    }

    public async Task<Section> GetSectionByIdAsync(int sectionId)
    {
        return await _sectionRepository.GetSectionByIdAsync(sectionId);
    }

    public async Task<Section> AddSectionAsync(Section section)
    {
        return await _sectionRepository.AddSectionAsync(section);
    }

    public async Task<Section> UpdateSectionAsync(Section section)
    {
        return await _sectionRepository.UpdateSectionAsync(section);
    }

    public async Task<bool> DeleteSectionAsync(int sectionId)
    {
        return await _sectionRepository.DeleteSectionAsync(sectionId);
    }
}