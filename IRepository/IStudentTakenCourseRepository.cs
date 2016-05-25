namespace IRepository
{
    using System.Collections.Generic;

    using POCO;

    public interface IStudentTakenCourseRepository
    {
        void InsertStudentTakenCourse(StudentTakenCourse student, ref List<string> errors);

        void UpdateStudentTakenCourse(StudentTakenCourse student, ref List<string> errors);

        void DeleteStudentTakenCourse(string studentId, int courseId, ref List<string> errors);

        List<StudentTakenCourse> GetStudentTakenCourse(string studentId, ref List<string> errors);

        // int CalculateTotalUnits(string studentId, List<StudentTakenCourse> enrollments, ref List<string> errors);
    }
}
