function StudentEnrollListViewModel() {

    var studentEnrollListModelObj = new StudentEnrollListModel();
    var self = this;
    var initialBind = false;

    var studentEnrollListViewModel = {
        studentEnrollList: ko.observableArray()
    };

    this.Initialize = function (scheduleId) {
        console.log(scheduleId);

        studentEnrollListModelObj.GetAll(scheduleId, function (studentEnrollList) {
            studentEnrollListViewModel.studentEnrollList.removeAll();
            if (studentEnrollList != null) {
                for (var i = 0; i < studentEnrollList.length; i++) {
                    studentEnrollListViewModel.studentEnrollList.push({
                        scheduleId: studentEnrollList[i].ScheduleId,
                        studentId: studentEnrollList[i].StudentId,
                        courseId: studentEnrollList[i].CourseId,
                        gradeOption: studentEnrollList[i].GradeOption,
                        gradeSel: ko.observableArray(["A","B","C","D","F"]),
                        grade: ko.observable(),
                        updateGrade: function () {
                            self.updateGrade(this);
                        }
                    });
                }
            }

            if (!initialBind) {
                ko.applyBindings({ viewModel: studentEnrollListViewModel }, document.getElementById("divStudentEnrollListContent"));
                initialBind = true; // this is to prevent binding multiple time because "Delete" functio calls GetAll again
            }
        });
    };

    this.updateGrade = function (data) {
        alert("click");
    };
}