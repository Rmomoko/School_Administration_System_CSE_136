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
    public class GraduateCourseAppServiceTest
    {
        [TestMethod]
        ////[ExpectedException(typeof(ArgumentException))]
        public void InsertGraduateCourseAppErrorTest()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<IGraduateCourseAppRepository>();
            var graduatecourseappService = new GraduateCourseAppService(mockRepository.Object);

            //// Act
            graduatecourseappService.InsertGraduateCourseApp(null, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        ////[ExpectedException(typeof(ArgumentException))]
        public void InsertGraduateCourseAppErrorTestSuccess()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<IGraduateCourseAppRepository>();
            var graduatecourseappService = new GraduateCourseAppService(mockRepository.Object);
            var x = new GraduateCourseApp { StudentId = "A4894165" };
            //// Act
            graduatecourseappService.InsertGraduateCourseApp(x, ref errors);

            //// Assert
            Assert.AreEqual(0, errors.Count);
        }

        [TestMethod]
        ////[ExpectedException(typeof(ArgumentException))]
        public void UpdateGraduateCourseAppErrorTest()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<IGraduateCourseAppRepository>();
            var graduatecourseappService = new GraduateCourseAppService(mockRepository.Object);

            //// Act
            graduatecourseappService.UpdateGraduateCourseApp(null, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        ////[ExpectedException(typeof(ArgumentException))]
        public void UpdateGraduateCourseAppErrorTestSuccess()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<IGraduateCourseAppRepository>();
            var graduatecourseappService = new GraduateCourseAppService(mockRepository.Object);
            var x = new GraduateCourseApp { StudentId = "A15614654564" };
            //// Act
            graduatecourseappService.UpdateGraduateCourseApp(x, ref errors);

            //// Assert
            Assert.AreEqual(0, errors.Count);
        }

        [TestMethod]
        ////[ExpectedException(typeof(ArgumentException))]
        public void GraduateCourseAppErrorTest()
        {
            //// Arranage
            var errors = new List<string>();
            var mockRepository = new Mock<IGraduateCourseAppRepository>();
            var graduatecourseappService = new GraduateCourseAppService(mockRepository.Object);

            //// Act
            graduatecourseappService.GetGraduateCourseApp(0, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        ////[ExpectedException(typeof(ArgumentException))]
        public void GraduateCourseAppErrorTestSuccess()
        {
            //// Arranage
            var errors = new List<string>();
            var mockRepository = new Mock<IGraduateCourseAppRepository>();
            var graduatecourseappService = new GraduateCourseAppService(mockRepository.Object);

            //// Act
            graduatecourseappService.GetGraduateCourseApp(2, ref errors);

            //// Assert
            Assert.AreEqual(0, errors.Count);
        }
    }
}