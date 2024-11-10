using DL.FnticCompetition.Models;
using DL.FnticCompetition.Repositories;

namespace BL.FnticCompetition.Services;

public class GroupService
{
    private readonly GroupRepository _groupRepository;

    public GroupService(GroupRepository groupRepository)
    {
        _groupRepository = groupRepository;
    }

    public async Task<IEnumerable<Group>> GetAllGroupsAsync()
    {
        return await _groupRepository.GetAllGroupsAsync();
    }

    public async Task<Group> GetGroupByIdAsync(int id)
    {
        return await _groupRepository.GetGroupByIdAsync(id);
    }

    public async Task AddGroupAsync(Group group)
    {
        await _groupRepository.AddGroupAsync(group);
    }

    public async Task UpdateGroupAsync(Group group)
    {
        await _groupRepository.UpdateGroupAsync(group);
    }

    public async Task DeleteGroupAsync(int id)
    {
        await _groupRepository.DeleteGroupAsync(id);
    }
}
