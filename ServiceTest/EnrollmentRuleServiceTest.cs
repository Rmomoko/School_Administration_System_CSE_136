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
    public class EnrollmentRuleServiceTest
    {
        [TestMethod]
        ////[ExpectedException(typeof(ArgumentException))]
        public void InsertEnrollmentRuleErrorTest()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<IEnrollmentRuleRepository>();
            var enrollmentRuleService = new EnrollmentRuleService(mockRepository.Object);

            //// Act
            enrollmentRuleService.InsertEnrollmentRule(null, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        public void InsertEnrollmentRuleSuccessTest()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<IEnrollmentRuleRepository>();
            var enrollmentRuleService = new EnrollmentRuleService(mockRepository.Object);

            var x = new EnrollmentRule { MaximumUnit = 19 };

            //// Act
            enrollmentRuleService.InsertEnrollmentRule(x, ref errors);

            //// Assert
            Assert.AreEqual(0, errors.Count);
        }

        [TestMethod]
        ////[ExpectedException(typeof(ArgumentException))]
        public void UpdateEnrollmentRuleErrorTest()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<IEnrollmentRuleRepository>();
            var enrollmentRuleService = new EnrollmentRuleService(mockRepository.Object);

            //// Act
            enrollmentRuleService.UpdateEnrollmentRule(null, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        ////[ExpectedException(typeof(ArgumentException))]
        public void UpdateEnrollmentRuleErrorTest3()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<IEnrollmentRuleRepository>();
            var enrollmentRuleService = new EnrollmentRuleService(mockRepository.Object);
            var enrollment = new EnrollmentRule { MinimumUnit = 13, MaximumUnit = 20, DropWoWDeadline = "2015-08-25", DropWoFDeadline = "2015-09-28" };

            enrollmentRuleService.UpdateEnrollmentRule(enrollment, ref errors);

            //// Assert
            Assert.AreEqual(0, errors.Count);
        }

        [TestMethod]
        public void UpdateEnrollmentRuleSuccessTest()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<IEnrollmentRuleRepository>();
            var enrollmentRuleService = new EnrollmentRuleService(mockRepository.Object);

            var x = new EnrollmentRule { MaximumUnit = 19 };

            //// Act
            enrollmentRuleService.UpdateEnrollmentRule(x, ref errors);

            //// Assert
            Assert.AreEqual(0, errors.Count);
        }

        [TestMethod]
        ////[ExpectedException(typeof(ArgumentException))]
        public void DeleteEnrollmentRuleErrorTest()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<IEnrollmentRuleRepository>();
            var enrollmentRuleService = new EnrollmentRuleService(mockRepository.Object);

            //// Act
            enrollmentRuleService.DeleteEnrollmentRule(null, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        public void DeleteEnrollmentRuleSuccessTest()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<IEnrollmentRuleRepository>();
            var enrollmentRuleService = new EnrollmentRuleService(mockRepository.Object);

            var x = new EnrollmentRule { MinimumUnit = 11 };

            //// Act
            enrollmentRuleService.UpdateEnrollmentRule(x, ref errors);

            //// Assert
            Assert.AreEqual(0, errors.Count);
        }
    }
}
