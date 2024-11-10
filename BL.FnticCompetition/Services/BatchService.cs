using DL.FnticCompetition.Models;
using DL.FnticCompetition.Repositories;

namespace BL.FnticCompetition.Services;

public class BatchService
{
    private readonly BatchRepository _batchRepository;

    public BatchService(BatchRepository batchRepository)
    {
        _batchRepository = batchRepository;
    }

    public async Task<List<Batch>> GetAllBatchesAsync()
    {
        return await _batchRepository.GetAllBatchesAsync();
    }

    public async Task<Batch> GetBatchByIdAsync(int id)
    {
        return await _batchRepository.GetBatchByIdAsync(id);
    }

    public async Task<Batch> AddBatchAsync(Batch batch)
    {
        return await _batchRepository.AddBatchAsync(batch);
    }

    public async Task<Batch> UpdateBatchAsync(Batch batch)
    {
        return await _batchRepository.UpdateBatchAsync(batch);
    }

    public async Task<bool> DeleteBatchAsync(int id)
    {
        return await _batchRepository.DeleteBatchAsync(id);
    }
}