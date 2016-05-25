function EnrollmentViewModel() {

    var self = this;
    var initialBind = false;
    var EnrollmentModelObj = new EnrollmentModel();
    var enrollmentViewModel = {
        enrollmentList: ko.observableArray(),
        deleteStudentEnrollment: function (data) { deleteStudentEnrollment(data); }
    };

    this.Initialize = function (id) {
        EnrollmentModelObj.GetAll(id, function (enrollment) {
            enrollmentViewModel.enrollmentList.removeAll();
            if (enrollment != null) {
                for (var i = 0; i < enrollment.length; i++) {
                    enrollmentViewModel.enrollmentList.push({
                        studentId:id,
                        courseId: enrollment[i].ScheduleId,
                        courseTitle: enrollment[i].CourseTitle,
                    });
                }
            }

            if (!initialBind) {
                ko.applyBindings({ viewModel: enrollmentViewModel }, document.getElementById("divEnrollmentContent"));
                initialBind = true; // this is to prevent binding multiple time because "Delete" functio calls GetAll again
            }
        });
    };

    var deleteStudentEnrollment = function (data) {
        EnrollmentModelObj.deleteStudentEnrollment(data.studentId, data.courseId, function () {
            enrollmentViewModel.deleteStudentEnrollment;
            parent.Initialize(data.studentId);
        });
    }
}