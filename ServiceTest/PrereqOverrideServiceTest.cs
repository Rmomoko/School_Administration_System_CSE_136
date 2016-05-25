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
    public class PrereqOverrideServiceTest
    {
        [TestMethod]
        ////[ExpectedException(typeof(ArgumentException))]
        public void InsertPrereqOverrideErrorTest()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<IPrereqOverrideRepository>();
            var prereqOverrideService = new PrereqOverrideService(mockRepository.Object);

            //// Act
            prereqOverrideService.InsertPrereqOverride(null, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        ////[ExpectedException(typeof(ArgumentException))]
        public void InsertPrereqOverrideInvalidCharacterStudentIdTest()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<IPrereqOverrideRepository>();
            var prereqOverrideService = new PrereqOverrideService(mockRepository.Object);

            var prereq = new PrereqOverride { StudentId = "A012_346", ScheduleId = 000123, ProfPrereqOverrideStatus = 1, AdminPrereqOverrideStatus = 0 };

            //// Act
            prereqOverrideService.InsertPrereqOverride(prereq, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        //// [ExpectedException(typeof(ArgumentException))]
        public void InsertPrereqOverrideNegativeScheduleIdTest()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<IPrereqOverrideRepository>();
            var prereqOverrideService = new PrereqOverrideService(mockRepository.Object);
            var prereq = new PrereqOverride { StudentId = "A01234567", ScheduleId = -1, ProfPrereqOverrideStatus = 1, AdminPrereqOverrideStatus = 0 };

            //// Act
            prereqOverrideService.InsertPrereqOverride(prereq, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        //// [ExpectedException(typeof(ArgumentException))]
        public void InsertPrereqOverrideEmptyStudentIdTest()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<IPrereqOverrideRepository>();
            var prereqOverrideService = new PrereqOverrideService(mockRepository.Object);

            var prereq = new PrereqOverride { StudentId = "k12kh", ScheduleId = 012345, ProfPrereqOverrideStatus = 1, AdminPrereqOverrideStatus = 0 };

            //// Act
            prereqOverrideService.InsertPrereqOverride(prereq, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        ////[ExpectedException(typeof(ArgumentException))]
        public void InsertPrereqOverrideEmptyScheduleIdTest()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<IPrereqOverrideRepository>();
            var prereqOverrideService = new PrereqOverrideService(mockRepository.Object);

            var prereq = new PrereqOverride { StudentId = "012345", ProfPrereqOverrideStatus = 1, AdminPrereqOverrideStatus = 0 };

            //// Act
            prereqOverrideService.InsertPrereqOverride(prereq, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        ////[ExpectedException(typeof(ArgumentException))]
        public void UpdatePrereqOverrideNullStudentTest()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<IPrereqOverrideRepository>();
            var prereqOverrideService = new PrereqOverrideService(mockRepository.Object);

            //// Act
            prereqOverrideService.UpdatePrereqOverride(null, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        ////[ExpectedException(typeof(ArgumentException))]
        public void UpdatePrereqOverrideEmptyStudentIdTest()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<IPrereqOverrideRepository>();
            var prereqOverrideService = new PrereqOverrideService(mockRepository.Object);

            var prereq = new PrereqOverride { StudentId = string.Empty };

            //// Act
            prereqOverrideService.UpdatePrereqOverride(prereq, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        //// [ExpectedException(typeof(ArgumentException))]
        public void UpdatePrereqOverrideSuccessTest()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<IPrereqOverrideRepository>();
            var prereqOverrideService = new PrereqOverrideService(mockRepository.Object);

            var prereq = new PrereqOverride { StudentId = "A0123456", ScheduleId = 2, ProfPrereqOverrideStatus = 1, AdminPrereqOverrideStatus = 0 };

            //// Act
            prereqOverrideService.UpdatePrereqOverride(prereq, ref errors);

            //// Assert
            Assert.AreEqual(0, errors.Count);
        }

        [TestMethod]
        public void GetPrereqOverrideTest()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<IPrereqOverrideRepository>();
            var prereqOverrideService = new PrereqOverrideService(mockRepository.Object);

            var prereqList = new List<PrereqOverride>();
            prereqList.Add(new PrereqOverride { StudentId = "A0123456", ScheduleId = 445678, ProfPrereqOverrideStatus = 1, AdminPrereqOverrideStatus = 0 });
            prereqList.Add(new PrereqOverride { StudentId = "A0123886", ScheduleId = 445678, ProfPrereqOverrideStatus = 1, AdminPrereqOverrideStatus = 1 });
            mockRepository.Setup(x => x.GetPrereqOverride(445678, ref errors)).Returns(prereqList);

            //// Act
            var newList = prereqOverrideService.GetPrereqOverride(445678, ref errors);

            //// Assert
            Assert.AreEqual(prereqList, newList);
        }
    }
}
