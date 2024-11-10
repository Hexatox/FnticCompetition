using DL.FnticCompetition.Models;
using Microsoft.EntityFrameworkCore;
namespace DL.FnticCompetition.Repositories;


    public class AttendanceRepository
    {
        private readonly AttendanceDbContext _context;

        public AttendanceRepository(AttendanceDbContext context)
        {
            _context = context;
        }

        // CREATE: Add a new attendance record
        public async Task<Attendance> AddAttendanceAsync(Attendance attendance)
        {
            if (attendance == null) throw new ArgumentNullException(nameof(attendance));

            await _context.Attendances.AddAsync(attendance);
            await _context.SaveChangesAsync();
            return attendance;
        }

        // READ: Get attendance by its ID
        public async Task<Attendance> GetAttendanceByIdAsync(int attendanceId)
        {
            return await _context.Attendances
                .Include(a => a.Class) // Include related class data
                .Include(a => a.Student) // Include related student data
                .FirstOrDefaultAsync(a => a.AttendanceID == attendanceId);
        }

        // READ: Get all attendance records for a specific class
        public async Task<List<Attendance>> GetAttendancesByClassAsync(int classId)
        {
            return await _context.Attendances
                .Where(a => a.ClassID == classId)
                .Include(a => a.Student)  // Include student data
                .ToListAsync();
        }

        // READ: Get all attendance records for a specific student
        public async Task<List<Attendance>> GetAttendancesByStudentAsync(int studentId)
        {
            return await _context.Attendances
                .Where(a => a.StudentID == studentId)
                .Include(a => a.Class)  // Include class data
                .ToListAsync();
        }

        // UPDATE: Update an existing attendance record
        public async Task<Attendance> UpdateAttendanceAsync(Attendance attendance)
        {
            if (attendance == null) throw new ArgumentNullException(nameof(attendance));

            _context.Attendances.Update(attendance);
            await _context.SaveChangesAsync();
            return attendance;
        }

        // DELETE: Delete an attendance record by its ID
        public async Task<bool> DeleteAttendanceAsync(int attendanceId)
        {
            var attendance = await GetAttendanceByIdAsync(attendanceId);
            if (attendance == null) return false;

            _context.Attendances.Remove(attendance);
            await _context.SaveChangesAsync();
            return true;
        }

        // Example: Get attendance by class and status
        public async Task<List<Attendance>> GetAttendancesByClassAndStatusAsync(int classId, string status)
        {
            return await _context.Attendances
                .Where(a => a.ClassID == classId && a.Status == status)
                .Include(a => a.Student)  // Include student data
                .ToListAsync();
        }
    }

