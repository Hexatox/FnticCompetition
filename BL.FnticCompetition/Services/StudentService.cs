using DL.FnticCompetition.Repositories;
using DL.FnticCompetition.Models;

namespace BL.FnticCompetition.Services;

public class StudentService
{
    private readonly StudentRepository _studentRepository;

    public StudentService(StudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task<List<Student>> GetStudentsAsync()
    {
        return await _studentRepository.GetStudentsAsync();
    }

    public async Task AddStudentAsync(Student student)
    {
        await _studentRepository.AddStudentAsync(student);
    }

    public async Task RemoveStudentAsync(int studentId)
    {
        await _studentRepository.RemoveStudentAsync(studentId);
    }
}