

using DL.FnticCompetition.Models;


using Microsoft.EntityFrameworkCore;

namespace DL.FnticCompetition.Repositories;


public class StudentRepository
    {
        private readonly AttendanceDbContext _context;

        public StudentRepository(AttendanceDbContext context)
        {
            _context = context;
        }

        // Get all students asynchronously
        public async Task<List<Student>> GetStudentsAsync()
        {
            try
            {
                return await _context.Students.ToListAsync();
            }
            catch (Exception ex)
            {
                // Log or handle the error as needed
                throw new Exception("An error occurred while fetching students", ex);
            }
        }

        // Add a new student asynchronously
        public async Task AddStudentAsync(Student student)
        {
            try
            {
                await _context.Students.AddAsync(student);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log or handle the error as needed
                throw new Exception("An error occurred while adding a new student", ex);
            }
        }

        // Remove a student asynchronously by their ID
        public async Task RemoveStudentAsync(int studentId)
        {
            try
            {
                var student = await _context.Students.FindAsync(studentId);
                if (student != null)
                {
                    _context.Students.Remove(student);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("Student not found");
                }
            }
            catch (Exception ex)
            {
                // Log or handle the error as needed
                throw new Exception("An error occurred while removing the student", ex);
            }
        }

        // Update a student's information asynchronously
        public async Task UpdateStudentAsync(Student student)
        {
            try
            {
                _context.Students.Update(student);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log or handle the error as needed
                throw new Exception("An error occurred while updating the student", ex);
            }
        }

        // Find a student by their ID asynchronously
        public async Task<Student> GetStudentByIdAsync(int studentId)
        {
            try
            {
                return await _context.Students.FindAsync(studentId);
            }
            catch (Exception ex)
            {
                // Log or handle the error as needed
                throw new Exception("An error occurred while fetching the student by ID", ex);
            }
        }
    }