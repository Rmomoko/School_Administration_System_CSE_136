namespace ServiceTest
{
    using System;
    using System.Collections.Generic;

    using IRepository;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using POCO;
    using Service;

    [TestClass]
    public class StudentTakenCourseServiceTest
    {
        [TestMethod]
        ////[ExpectedException(typeof(ArgumentException))]
        public void InsertStudentTakenCourseErrorTest()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<IStudentTakenCourseRepository>();
            var studenttakencourseService = new
StudentTakenCourseService(mockRepository.Object);

            //// Act
            studenttakencourseService.InsertStudentTakenCourse(null, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        ////[ExpectedException(typeof(ArgumentException))]
        public void InsertStudentTakenCourseErrorTest2()
        {
            //// Arranage
            var errors = new List<string>();
            var mockRepository = new Mock<IStudentTakenCourseRepository>();
            var studenttakencourseService = new
StudentTakenCourseService(mockRepository.Object);
            var enrollments = new StudentTakenCourse { StudentId = "A01" };

            //// Act
            studenttakencourseService.InsertStudentTakenCourse(enrollments, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        ////[ExpectedException(typeof(ArgumentException))]
        public void InsertStudentTakenCourseErrorTest2Success()
        {
            //// Arranage
            var errors = new List<string>();
            var mockRepository = new Mock<IStudentTakenCourseRepository>();
            var studenttakencourseService = new
StudentTakenCourseService(mockRepository.Object);
            var enrollments = new StudentTakenCourse { StudentId = "A01242343" };

            //// Act
            studenttakencourseService.InsertStudentTakenCourse(enrollments, ref errors);

            //// Assert
            Assert.AreEqual(0, errors.Count);
        }

        [TestMethod]
        ////[ExpectedException(typeof(ArgumentException))]
        public void UpdateStudentTakenCourseErrorTest()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<IStudentTakenCourseRepository>();
            var studenttakencourseService = new
StudentTakenCourseService(mockRepository.Object);

            //// Act
            studenttakencourseService.UpdateStudentTakenCourse(null, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        ////[ExpectedException(typeof(ArgumentException))]
        public void UpdateStudentTakenCourseErrorTest2()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<IStudentTakenCourseRepository>();
            var studenttakencourseService = new
StudentTakenCourseService(mockRepository.Object);
            var enrollments = new StudentTakenCourse { StudentId = "A111" };

            //// Act
            studenttakencourseService.UpdateStudentTakenCourse(enrollments, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        ////[ExpectedException(typeof(ArgumentException))]
        public void UpdateStudentTakenCourseErrorTest2Success()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<IStudentTakenCourseRepository>();
            var studenttakencourseService = new
StudentTakenCourseService(mockRepository.Object);
            var enrollments = new StudentTakenCourse { StudentId = "A111345656" };

            //// Act
            studenttakencourseService.UpdateStudentTakenCourse(enrollments, ref errors);

            //// Assert
            Assert.AreEqual(0, errors.Count);
        }

        [TestMethod]
        ////[ExpectedException(typeof(ArgumentException))]
        public void StudentTakenCourseErrorTest()
        {
            //// Arranage
            var errors = new List<string>();
            var mockRepository = new Mock<IStudentTakenCourseRepository>();
            var studenttakencourseService = new
StudentTakenCourseService(mockRepository.Object);

            //// Act
            studenttakencourseService.GetStudentTakenCourse(null, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        ////[ExpectedException(typeof(ArgumentException))]
        public void StudentTakenCourseErrorTest2()
        {
            //// Arranage
            var errors = new List<string>();
            var mockRepository = new Mock<IStudentTakenCourseRepository>();
            var studenttakencourseService = new
StudentTakenCourseService(mockRepository.Object);
            string id = "A123456";

            //// Act
            studenttakencourseService.GetStudentTakenCourse(id, ref errors);

            //// Assert
            Assert.AreEqual(0, errors.Count);
        }

        [TestMethod]
        ////[ExpectedException(typeof(ArgumentException))]
        public void DeleteStudentTakenCourseErrorTest()
        {
            //// Arrange
            var errors = new List<string>();

            var mockRepository = new Mock<IStudentTakenCourseRepository>();
            var studenttakencourseService = new
StudentTakenCourseService(mockRepository.Object);

            //// Act
            studenttakencourseService.DeleteStudentTakenCourse(null, 1, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        ////[ExpectedException(typeof(ArgumentException))]
        public void DeleteStudentTakenCourseErrorTestSuccess()
        {
            //// Arrange
            var errors = new List<string>();

            var mockRepository = new Mock<IStudentTakenCourseRepository>();
            var studenttakencourseService = new
StudentTakenCourseService(mockRepository.Object);

            //// Act
            studenttakencourseService.DeleteStudentTakenCourse("A12345798", 1, ref errors);

            //// Assert
            Assert.AreEqual(0, errors.Count);
        }
    }
}