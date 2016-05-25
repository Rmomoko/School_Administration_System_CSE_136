namespace ServiceTest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using IRepository;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using POCO;
    using Service;

    [TestClass]
    public class StudentEnrollmentServiceTest
    {
        [TestMethod]
        ////[ExpectedException(typeof(ArgumentException))]
        public void EnrollmentScheduleNullEnrollmentTest()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<IStudentEnrollmentRepository>();
            var mockRepository2 = new Mock<IEnrollmentRuleRepository>();
            var studentEnrollmentService = new StudentEnrollmentService(mockRepository2.Object, mockRepository.Object);
            var list = new List<StudentEnrollment>();
            //// Act
            studentEnrollmentService.EnrollSchedule(null, 1, "Letter", 1, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        //// [ExpectedException(typeof(ArgumentException))]
        public void EnrollmentScheduleInvalidStudentIdTestSuccess()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<IStudentEnrollmentRepository>();
            var mockRepository2 = new Mock<IEnrollmentRuleRepository>();
            var studentEnrollmentService = new StudentEnrollmentService(mockRepository2.Object, mockRepository.Object);
            var list = new List<StudentEnrollment>();

            //// Act
            studentEnrollmentService.EnrollSchedule("A1117111", 1, "Letter", 1, ref errors);
            studentEnrollmentService.EnrollSchedule("A00000011", 1, "Letter", 1, ref errors);
            studentEnrollmentService.EnrollSchedule("A111111111", 1, "Letter", 1, ref errors);
            studentEnrollmentService.EnrollSchedule("A51111111", 1, "Letter", 1, ref errors);

            //// Assert
            Assert.AreEqual(0, errors.Count);
        }

        [TestMethod]
        //// [ExpectedException(typeof(ArgumentException))]
        public void EnrollmentScheduleInvalidStudentIdTest()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<IStudentEnrollmentRepository>();
            var mockRepository2 = new Mock<IEnrollmentRuleRepository>();
            var studentEnrollmentService = new StudentEnrollmentService(mockRepository2.Object, mockRepository.Object);
            var list = new List<StudentEnrollment>();
            //// Act
            studentEnrollmentService.EnrollSchedule("A111---11", 1, "Letter", 1, ref errors);
            studentEnrollmentService.EnrollSchedule("?00000011", 1, "Letter", 1, ref errors);
            studentEnrollmentService.EnrollSchedule("111111111", 1, "Letter", 1, ref errors);
            studentEnrollmentService.EnrollSchedule("AA1111111", 1, "Letter", 1, ref errors);

            //// Assert
            Assert.AreEqual(4, errors.Count);
        }

        [TestMethod]
        ////[ExpectedException(typeof(ArgumentException))]
        public void EnrollmentScheduleInvalidScheduleIdTest2()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<IStudentEnrollmentRepository>();
            var mockRepository2 = new Mock<IEnrollmentRuleRepository>();
            var studentEnrollmentService = new StudentEnrollmentService(mockRepository2.Object, mockRepository.Object);
            var list = new List<StudentEnrollment>();
            //// Act
            studentEnrollmentService.EnrollSchedule("A000001", -1, "Letter", 1, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        ////[ExpectedException(typeof(ArgumentException))]
        public void EnrollmentScheduleInvalidScheduleIdTest2Success()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<IStudentEnrollmentRepository>();
            var mockRepository2 = new Mock<IEnrollmentRuleRepository>();
            var studentEnrollmentService = new StudentEnrollmentService(mockRepository2.Object, mockRepository.Object);
            var list = new List<StudentEnrollment>();

            //// Act
            studentEnrollmentService.EnrollSchedule("A000001", 5, "Letter", 1, ref errors);

            //// Assert
            Assert.AreEqual(0, errors.Count);
        }

        [TestMethod]
        ////[ExpectedException(typeof(ArgumentException))]
        public void EnrollmentScheduleNullGradeOptionTest()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<IStudentEnrollmentRepository>();
            var mockRepository2 = new Mock<IEnrollmentRuleRepository>();
            var studentEnrollmentService = new StudentEnrollmentService(mockRepository2.Object, mockRepository.Object);
            var list = new List<StudentEnrollment>();
            //// Act
            studentEnrollmentService.EnrollSchedule("A000001", 1, null, 1, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        ////[ExpectedException(typeof(ArgumentException))]
        public void EnrollmentScheduleNullGradeOptionTestSuccess()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<IStudentEnrollmentRepository>();
            var mockRepository2 = new Mock<IEnrollmentRuleRepository>();
            var studentEnrollmentService = new StudentEnrollmentService(mockRepository2.Object, mockRepository.Object);
            var list = new List<StudentEnrollment>();

            //// Act
            studentEnrollmentService.EnrollSchedule("A000001", 1, "Letter", 1, ref errors);

            //// Assert
            Assert.AreEqual(0, errors.Count);
        }

        [TestMethod]
        //// [ExpectedException(typeof(ArgumentException))]
        public void EnrollmentScheduleShortStudentIdTest()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<IStudentEnrollmentRepository>();
            var mockRepository2 = new Mock<IEnrollmentRuleRepository>();
            var studentEnrollmentService = new StudentEnrollmentService(mockRepository2.Object, mockRepository.Object);
            var list = new List<StudentEnrollment>();
            //// Act
            studentEnrollmentService.EnrollSchedule("A", 1, "Letter", 1, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        //// [ExpectedException(typeof(ArgumentException))]
        public void EnrollmentScheduleShortStudentIdTestSuccess()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<IStudentEnrollmentRepository>();
            var mockRepository2 = new Mock<IEnrollmentRuleRepository>();
            var studentEnrollmentService = new StudentEnrollmentService(mockRepository2.Object, mockRepository.Object);
            var list = new List<StudentEnrollment>();

            //// Act
            studentEnrollmentService.EnrollSchedule("A51147417", 1, "Letter", 1, ref errors);

            //// Assert
            Assert.AreEqual(0, errors.Count);
        }

        /*
        [TestMethod]
        //// [ExpectedException(typeof(ArgumentException))]
        public void EnrollmentScheduleExceedMaximumUnitTest()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<IStudentEnrollmentRepository>();
            var mockRepository2 = new Mock<IEnrollmentRuleRepository>();
            var studentEnrollmentService = new StudentEnrollmentService(mockRepository2.Object, mockRepository.Object);
            
            //// Act
            var enrollmentList = new List<StudentEnrollment>();
            enrollmentList.Add(new StudentEnrollment { StudentId = "A000000", ScheduleId = 1, GradeOption = "Letter", PrereqStatus = 1 });
            enrollmentList.Add(new StudentEnrollment { StudentId = "A000000", ScheduleId = 1, GradeOption = "Letter", PrereqStatus = 1 });
            enrollmentList.Add(new StudentEnrollment { StudentId = "A000000", ScheduleId = 1, GradeOption = "Letter", PrereqStatus = 1 });
            enrollmentList.Add(new StudentEnrollment { StudentId = "A000000", ScheduleId = 1, GradeOption = "Letter", PrereqStatus = 1 });
            enrollmentList.Add(new StudentEnrollment { StudentId = "A000000", ScheduleId = 1, GradeOption = "Letter", PrereqStatus = 1 });
            enrollmentList.Add(new StudentEnrollment { StudentId = "A000000", ScheduleId = 1, GradeOption = "Letter", PrereqStatus = 1 });
            enrollmentList.Add(new StudentEnrollment { StudentId = "A000000", ScheduleId = 1, GradeOption = "Letter", PrereqStatus = 1 });
            enrollmentList.Add(new StudentEnrollment { StudentId = "A000000", ScheduleId = 1, GradeOption = "Letter", PrereqStatus = 1 });
            enrollmentList.Add(new StudentEnrollment { StudentId = "A000000", ScheduleId = 1, GradeOption = "Letter", PrereqStatus = 1 });
            enrollmentList.Add(new StudentEnrollment { StudentId = "A000000", ScheduleId = 1, GradeOption = "Letter", PrereqStatus = 1 });
            
            studentEnrollmentService.EnrollSchedule("A123456789123456789", 1, "Letter", 1, ref errors);
            //// Assert
            Assert.AreEqual(1, errors.Count);
        }
        */

        [TestMethod]
        //// [ExpectedException(typeof(ArgumentException))]
        public void EnrollmentScheduleSuccessTest()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<IStudentEnrollmentRepository>();
            var mockRepository2 = new Mock<IEnrollmentRuleRepository>();
            var studentEnrollmentService = new StudentEnrollmentService(mockRepository2.Object, mockRepository.Object);
            var list = new List<StudentEnrollment>();
            //// Act
            list.Add(new StudentEnrollment { StudentId = "A000000", ScheduleId = 1, GradeOption = "Letter", PrereqStatus = 1 });
            studentEnrollmentService.EnrollSchedule("A000000", 1, "Letter", 1, ref errors);

            //// Assert
            Assert.AreEqual(0, errors.Count);
        }

        [TestMethod]
        //// [ExpectedException(typeof(ArgumentException))]
        public void EnrollmentScheduleSuccessTest2()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<IStudentEnrollmentRepository>();
            var mockRepository2 = new Mock<IEnrollmentRuleRepository>();
            var studentEnrollmentService = new StudentEnrollmentService(mockRepository2.Object, mockRepository.Object);
            var list = new List<StudentEnrollment>();
            //// Act
            list.Add(new StudentEnrollment { StudentId = "A000000", ScheduleId = 1, GradeOption = "Letter", PrereqStatus = 1 });

            //// Assert
            Assert.AreEqual(0, errors.Count);
        }
    }
}
