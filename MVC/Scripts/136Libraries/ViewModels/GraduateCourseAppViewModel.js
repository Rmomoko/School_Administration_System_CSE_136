function GraduateCourseAppViewModel() {

    var GraduateCourseAppModelObj = new GraduateCourseAppModel();
    var self = this;
    var initialBind = false;

    var graduateCourseAppViewModel = {
        graduateCourseAppList: ko.observableArray()
    };

    this.Initialize = function (studentId) {
        console.log(studentId);

        GraduateCourseAppModelObj.GetAll(function (graduateCourseApp) {
            graduateCourseAppViewModel.graduateCourseAppList.removeAll();
            if (graduateCourseApp != null) {
                for (var i = 0; i < graduateCourseApp.length; i++) {
                    graduateCourseAppViewModel.graduateCourseAppList.push({
                        studentId: graduateCourseApp[i].StudentId,
                        scheduleId: graduateCourseApp[i].ScheduleId,
                        courseTitle: graduateCourseApp[i].CourseTitle
                    });
                }
            }

            if (!initialBind) {
                ko.applyBindings({ viewModel: graduateCourseAppViewModel }, document.getElementById("divGraduateCourseApp"));
                initialBind = true; // this is to prevent binding multiple time because "Delete" functio calls GetAll again
            }
        });
    };
}
