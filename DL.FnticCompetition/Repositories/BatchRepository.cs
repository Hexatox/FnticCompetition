using DL.FnticCompetition.Models;
using Microsoft.EntityFrameworkCore;

namespace DL.FnticCompetition.Repositories;


  public class BatchRepository
    {
        private readonly AttendanceDbContext _context;

        public BatchRepository(AttendanceDbContext context)
        {
            _context = context;
        }

        // CREATE: Add a new batch to the database
        public async Task<Batch> AddBatchAsync(Batch batch)
        {
            if (batch == null) throw new ArgumentNullException(nameof(batch));

            await _context.Batches.AddAsync(batch); // Assuming Batches is the DbSet for the Batch model
            await _context.SaveChangesAsync();
            return batch;
        }

        // READ: Get a batch by its ID
        public async Task<Batch> GetBatchByIdAsync(int id)
        {
            return await _context.Batches
                .FirstOrDefaultAsync(b => b.BatchID == id); // Assuming Batch has an Id property
        }

        // READ: Get all batches
        public async Task<List<Batch>> GetAllBatchesAsync()
        {
            return await _context.Batches
                .ToListAsync();
        }

        // UPDATE: Update an existing batch
        public async Task<Batch> UpdateBatchAsync(Batch batch)
        {
            if (batch == null) throw new ArgumentNullException(nameof(batch));

            _context.Batches.Update(batch); // Mark as modified
            await _context.SaveChangesAsync();
            return batch;
        }

        // DELETE: Delete a batch by ID
        public async Task<bool> DeleteBatchAsync(int id)
        {
            var batch = await GetBatchByIdAsync(id);
            if (batch == null) return false;

            _context.Batches.Remove(batch);
            await _context.SaveChangesAsync();
            return true;
        }

        // Example of a batch search by some property
        public async Task<List<Batch>> GetBatchesByPropertyAsync(string property)
        {
            return await _context.Batches
                .Where(b => b.BatchName.Contains(property))  // Example: filtering batches by name
                .ToListAsync();
        }
    }