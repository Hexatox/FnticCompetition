using DL.FnticCompetition.Models;
using DL.FnticCompetition.Repositories;

public class AttendanceService
{
    private readonly AttendanceRepository _attendanceRepository;

    public AttendanceService(AttendanceRepository attendanceRepository)
    {
        _attendanceRepository = attendanceRepository;
    }

    public async Task<List<Attendance>> GetAllAttendancesAsync()
    {
        return await _attendanceRepository.GetAttendancesByClassAsync(1); // Example with ClassID = 1
    }

    public async Task<Attendance> AddAttendanceAsync(Attendance attendance)
    {
        return await _attendanceRepository.AddAttendanceAsync(attendance);
    }

    public async Task<bool> DeleteAttendanceAsync(int attendanceId)
    {
        return await _attendanceRepository.DeleteAttendanceAsync(attendanceId);
    }

    // Add more methods for updating, querying by status, etc.
}