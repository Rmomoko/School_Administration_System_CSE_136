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
    public class CapeServiceTest
    {
        /* Test null cape object */
        [TestMethod]
        ////  [ExpectedException(typeof(ArgumentException))]
        public void InsertCapeErrorTest1()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<ICapeRepository>();
            var capeService = new CapeService(mockRepository.Object);

            //// Act
            capeService.InsertCapeData(null, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        /* Test Negative course id */
        [TestMethod]
        //// [ExpectedException(typeof(ArgumentException))]
        public void InsertCapeErrorTest2()
        {
            //// Arranage
            var errors = new List<string>();
            var mockRepository = new Mock<ICapeRepository>();
            var capeService = new CapeService(mockRepository.Object);
            var cape = new Cape { CourseId = -1 };

            //// Act
            capeService.InsertCapeData(cape, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        ////  [ExpectedException(typeof(ArgumentException))]
        public void InsertCapeESuccessTest()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<ICapeRepository>();
            var capeService = new CapeService(mockRepository.Object);
            var cape = new Cape { CourseId = 2, Easiness = 4.8f, Helpfulness = 2.5f, Clarity = 1.0f, Hours_spend = 15.0f };
            //// Act
            capeService.InsertCapeData(cape, ref errors);

            //// Assert
            Assert.AreEqual(0, errors.Count);
        }

        [TestMethod]
        ////  [ExpectedException(typeof(ArgumentException))]
        public void UpdateCapeSuccess()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<ICapeRepository>();
            var capeService = new CapeService(mockRepository.Object);
            var cape = new Cape { CourseId = 2, Easiness = 3.5f, Helpfulness = 2.5f, Clarity = 1.5f, Hours_spend = 12.0f };
            //// Act
            capeService.UpdateCape(cape, 2, ref errors);

            //// Assert
            Assert.AreEqual(0, errors.Count);
        }

        [TestMethod]
        public void GetCapeSuccessTest()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<ICapeRepository>();
            var capeService = new CapeService(mockRepository.Object);

            var capeList = new List<Cape>();
            capeList.Add(new Cape { CourseId = 2, Easiness = 3.5f, Helpfulness = 2.5f, Clarity = 1.5f, Hours_spend = 12.0f });
            capeList.Add(new Cape { CourseId = 2, Easiness = 4.8f, Helpfulness = 2.5f, Clarity = 1.0f, Hours_spend = 15.0f });

            mockRepository.Setup(x => x.GetCape(ref errors)).Returns(capeList);

            var newList = capeService.GetCape(ref errors);

            //// Assert
            Assert.AreEqual(capeList, newList);
        }

        [TestMethod]
        public void GetCapeFailTest()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<ICapeRepository>();
            var capeService = new CapeService(mockRepository.Object);

            var capeList = new List<Cape>();
            capeList.Add(new Cape { CourseId = -2, Easiness = 3.5f, Helpfulness = 2.5f, Clarity = 1.5f, Hours_spend = 12.0f });
            capeList.Add(new Cape { CourseId = 2, Easiness = 4.8f, Helpfulness = 2.5f, Clarity = 1.0f, Hours_spend = 15.0f });

            mockRepository.Setup(x => x.GetCape(ref errors)).Returns(capeList);

            var newList = capeService.GetCape(ref errors);

            //// Assert
            Assert.AreEqual(capeList, newList);
        }

        [TestMethod]
        //// [ExpectedException(typeof(ArgumentException))]
        public void CalculateCapeErrorTest()
        {
            //// Arrange
            var errors = new List<string>();

            var mockRepository = new Mock<ICapeRepository>();
            var capeService = new CapeService(mockRepository.Object);

            //// Act
            capeService.CalculateCapeEasiness(0, null, ref errors);
            capeService.CalculateCapeHelpfulness(0, null, ref errors);
            capeService.CalculateCapeClarity(0, null, ref errors);
            capeService.CalculateCapeHoursSpend(0, null, ref errors);

            //// Assert
            Assert.AreEqual(4, errors.Count);
        }

        [TestMethod]
        //// [ExpectedException(typeof(ArgumentException))]
        public void CalculateCapeErrorTest2()
        {
            //// Arrange
            var errors = new List<string>();

            var mockRepository = new Mock<ICapeRepository>();
            var capeService = new CapeService(mockRepository.Object);

            //// Act
            capeService.CalculateCapeEasiness(2, null, ref errors);
            capeService.CalculateCapeHelpfulness(1, null, ref errors);
            capeService.CalculateCapeClarity(3, null, ref errors);
            capeService.CalculateCapeHoursSpend(5, null, ref errors);

            //// Assert
            Assert.AreEqual(4, errors.Count);
        }

        [TestMethod]
        //// [ExpectedException(typeof(ArgumentException))]
        public void CalculateCapeErrorTest3()
        {
            //// Arrange
            var errors = new List<string>();

            var mockRepository = new Mock<ICapeRepository>();
            var capeService = new CapeService(mockRepository.Object);

            //// Act
            capeService.CalculateCapeEasiness(-2, null, ref errors);
            capeService.CalculateCapeHelpfulness(-1, null, ref errors);
            capeService.CalculateCapeClarity(-4, null, ref errors);
            capeService.CalculateCapeHoursSpend(-3, null, ref errors);

            //// Assert
            Assert.AreEqual(4, errors.Count);
        }
    }
}
