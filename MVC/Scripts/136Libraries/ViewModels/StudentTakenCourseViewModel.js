function StudentTakenCourseViewModel() {

    var StudentTakenCourseModelObj = new StudentTakenCourseModel();
    var self = this;
    var initialBind = false;

    var studentTakenCourseViewModel = {
        studentTakenCourseList: ko.observableArray(),
        deleteStudentTakenCourse: function (data) { deleteStudentTakenCourse(data); },
        insertStudentTakenCourse: function (viewModel){insertStudentTakenCourse(viewModel);}
    };

    this.Initialize = function (studentId) {
        console.log(studentId);

        StudentTakenCourseModelObj.GetAll(studentId, function (studentTakenCourse) {
            studentTakenCourseViewModel.studentTakenCourseList.removeAll();
            if (studentTakenCourse != null) {
                for (var i = 0; i < studentTakenCourse.length; i++) {
                    studentTakenCourseViewModel.studentTakenCourseList.push({
                        studentId: studentTakenCourse[i].StudentId,
                        courseId: studentTakenCourse[i].CourseId,
                        courseTitle: studentTakenCourse[i].CourseTitle,
                        year: studentTakenCourse[i].Year,
                        quarter: studentTakenCourse[i].Quarter,
                        grade: studentTakenCourse[i].Grade
                    });
                }
            }

            if (!initialBind) {
                ko.applyBindings({ viewModel: studentTakenCourseViewModel }, document.getElementById("divStudentTakenCourse"));
                initialBind = true; // this is to prevent binding multiple time because "Delete" functio calls GetAll again
            }
        });
    };

    this.CreateStudentTakenCourse = function (data) {
        var model = {
            StudentId: data.studentId(),
            CourseId: data.courseId(),
            CourseTitle: data.courseTitle(),
            Year: data.year(),
            Quarter: data.quarter(),
            Grade: data.grade()
        }

        StudentModelObj.Create(model, function (result) {
            if (result == "ok") {
                alert("Create student successful");
            } else {
                alert("Error occurred");
            }
        });

    };

    var deleteStudentTakenCourse = function (data) {
        StudentTakenCourseModelObj.deleteStudentTakenCourse(data.studentId, data.courseId, function (result) {
            studentTakenCourseViewModel.deleteStudentTakenCourse;
            if (result == "ok") {
                self.Initialize(data.studentId);
            } else {
                alert("Error occurred");
            }
        });
    }
    
   /* var insertStudentTakenCourse = function (data) {
        var model = {
            StudentId: data.studentId(),
            CourseId: data.courseId(),
            CourseTitle: data.courseTitle(),
            Year: data.year(),
            Quarter: data.quarter(),
            Grade: data.grade()
        }
        StudentTakenCourseModelObj.insertStudentTakenCourse(model, function (result) {
            studentTakenCourseViewModel.insertStudentTakenCourse();
            if (result == "ok") {
                self.Initialize(data.studentId);
            } else {
                alert("Error occurred");
            }
        });
    }*/
}
