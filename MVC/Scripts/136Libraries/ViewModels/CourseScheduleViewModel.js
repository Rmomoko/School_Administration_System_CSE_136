function CourseScheduleViewModel() {

    var self = this;
    var initialBind = false;
    var courseScheduleViewModel = {
        courseScheduleList: ko.observableArray(),
        enrollSchedule: function (data) { enrollSchedule(data); },
        insertStudentTakenCourse: function (data) { insertStudentTakenCourse(data); }
    };
    var StudentTakenCourseModelObj = new StudentTakenCourseModel();
    var studentTakenCourseList = ko.observableArray();

    this.Initialize = function (id) {
        var arrayLength;
        StudentTakenCourseModelObj.GetAll(id, function (studentTakenCourse) {
            if (studentTakenCourse != null) {
                for (var i = 0; i < studentTakenCourse.length; i++) {
                    studentTakenCourseList[i] = studentTakenCourse[i].CourseId
                    console.log(studentTakenCourseList[i])
                }
                arrayLength = i;
            }
            test = studentTakenCourseList;
        })
        var CourseScheduleModelObj = new CourseScheduleModel();
        CourseScheduleModelObj.GetAll(id, function (courseSchedule) {
            courseScheduleViewModel.courseScheduleList.removeAll();

            if (courseSchedule != null) {
                var temp;
                for (var i = 0; i < courseSchedule.length; i++) {
                    for (var j = 0; j < arrayLength ; j++) {
                        if (studentTakenCourseList[j] == courseSchedule[i].CourseId) {
                            temp = j;
                            break;
                        }
                    }

                    if (studentTakenCourseList[temp] == courseSchedule[i].CourseId) {
                    }
                    else {
                        courseScheduleViewModel.courseScheduleList.push({
                            studentId: id,
                            scheduleId: courseSchedule[i].ScheduleId,
                            courseId: courseSchedule[i].CourseId,
                            year: courseSchedule[i].Year,
                            quarter: courseSchedule[i].Quarter,
                            session: courseSchedule[i].Session,
                            courseTitle: courseSchedule[i].CourseTitle,
                            courseDescription: courseSchedule[i].CourseDescription,
                        });
                    }
                }
            }

            if (!initialBind) {
                ko.applyBindings({ viewModel: courseScheduleViewModel }, document.getElementById("divCourseSchedule"));
                initialBind = true; // this is to prevent binding multiple time because "Delete" functio calls GetAll again
            }
        });
    };

    var enrollSchedule = function (data) {
        var CourseScheduleModelObj = new CourseScheduleModel();
        CourseScheduleModelObj.enrollSchedule(data, function () {
            self.Initialize(data.studentId);
        });
        insertStudentTakenCourse(data);
    }

    var insertStudentTakenCourse = function (data) {
        var StudentTakenCourseModelObj = new StudentTakenCourseModel();
        StudentTakenCourseModelObj.insertStudentTakenCourse(data, function () {
            self.Initialize(data.studentId);
        });

    }
}