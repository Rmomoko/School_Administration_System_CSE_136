namespace Service
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using IRepository;
    using POCO;

    public class StudentTakenCourseService
    {
        private readonly IStudentTakenCourseRepository repository;

        public StudentTakenCourseService(IStudentTakenCourseRepository repository)
        {
            this.repository = repository;
        }

        public void InsertStudentTakenCourse(StudentTakenCourse studenttakencourse, ref List<string> errors)
        {
            if (studenttakencourse == null)
            {
                errors.Add("StudentTakenCourse cannot be null");
                return;
                ////throw new ArgumentException();
            }

            if (studenttakencourse.StudentId.Length < 5)
            {
                errors.Add("Invalid student ID length");
                return;
                ////throw new ArgumentException();
            }

            this.repository.InsertStudentTakenCourse(studenttakencourse, ref errors);
        }

        public void UpdateStudentTakenCourse(StudentTakenCourse studenttakencourse, ref List<string> errors)
        {
            if (studenttakencourse == null)
            {
                errors.Add("StudentTakencourse cannot be null");
                return;
                ////throw new ArgumentException();
            }

            if (studenttakencourse.StudentId.Length < 5)
            {
                errors.Add("Invalid student id length");
                return;
                ////throw new ArgumentException();
            }

            this.repository.UpdateStudentTakenCourse(studenttakencourse, ref errors);
        }

        public List<StudentTakenCourse> GetStudentTakenCourse(string studentId, ref List<string> errors)
        {
            if (string.IsNullOrEmpty(studentId))
            {
                errors.Add("Invalid student id");
                ////throw new ArgumentException();
                return null;
            }

            return this.repository.GetStudentTakenCourse(studentId, ref errors);
        }

        public void DeleteStudentTakenCourse(string studentId, int courseId, ref List<string> errors)
        {
            if (string.IsNullOrEmpty(studentId))
            {
                errors.Add("Invalid student id");
                ////throw new ArgumentException();
            }

            if (courseId < 0)
            {
                errors.Add("Invalid course id");
                ////throw new ArgumentException();
            }

            this.repository.DeleteStudentTakenCourse(studentId, courseId, ref errors);
        }

        public int CalculateTotalUnits(List<StudentTakenCourse> enrollments, ref List<string> errors)
        {
            if (enrollments == null)
            {
                errors.Add("Bad list");
                ////throw new ArgumentException();
                return 0;
            }

            var sum = 0;

            foreach (var enrollment in enrollments)
            {
                sum = sum + 4;
            }

            return sum;
        }
    }
}