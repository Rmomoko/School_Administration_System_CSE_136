function PrereqOverrideViewModel() {

    var PrereqOverrideModelObj = new PrereqOverrideModel();
    var self = this;
    var initialBind = false;

    var prereqOverrideViewModel = {
        prereqOverrideList: ko.observableArray()
    };

    this.Initialize = function (studentId) {
        console.log(studentId);

        PrereqOverrideModelObj.GetAll(function (prereqOverride) {
            prereqOverrideViewModel.prereqOverrideList.removeAll();
            if (prereqOverride != null) {
                for (var i = 0; i < prereqOverride.length; i++) {
                    prereqOverrideViewModel.prereqOverrideList.push({
                        studentId: prereqOverride[i].StudentId,
                        scheduleId: prereqOverride[i].ScheduleId,
                        courseTitle: prereqOverride[i].CourseTitle
                    });
                    if (prereqOverride[i].ProfPrereqOverrideStatus == 1 && prereqOverride[i].AdminPrereqOverrideStatus && 1) {
                        prereqOverrideViewModel.prereqOverrideList.pop()
                    }
                }
            }

            if (!initialBind) {
                ko.applyBindings({ viewModel: prereqOverrideViewModel }, document.getElementById("divPrereqOverride"));
                initialBind = true; // this is to prevent binding multiple time because "Delete" functio calls GetAll again
            }
        });
    };

    this.CreateStudentTakenCourse = function (data) {
        var model = {
            StudentId: data.studentId(),
            ScheduleId: data.ScheduleId(),
            CourseTitle: data.courseTitle(),
            ProfPrereqOverrideStatus: data.profPrereqOverrideStatus(),
            AdminPrereqOverrideStatus: data.adminPrereqOverrideStatus()
        }

        StudentModelObj.Create(model, function (result) {
            if (result == "ok") {
                alert("Create student successful");
            } else {
                alert("Error occurred");
            }
        });

    };
}
