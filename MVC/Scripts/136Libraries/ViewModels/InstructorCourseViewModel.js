function InstructorCourseViewModel() {

    var instructorCourseModelObj = new InstructorCourseModel();
    var self = this;
    var initialBind = false;

    var instructorCourseViewModel = {
        instructorCourseList: ko.observableArray()
    };

    this.Initialize = function (instructorId) {
        console.log(instructorId);

        instructorCourseModelObj.GetAll(instructorId, function (instructorCourse) {
            instructorCourseViewModel.instructorCourseList.removeAll();
            if (instructorCourse != null) {
                for (var i = 0; i < instructorCourse.length; i++) {
                    instructorCourseViewModel.instructorCourseList.push({
                        scheduleId: instructorCourse[i].ScheduleId,
                        instructorId: instructorCourse[i].InstructorId,
                        courseTitle: instructorCourse[i].CourseTitle,
                        year: instructorCourse[i].Year,
                        quarter: instructorCourse[i].Quarter,
                        session: instructorCourse[i].Session
                    });
                }
            }

            if (!initialBind) {
                ko.applyBindings({ viewModel: instructorCourseViewModel }, document.getElementById("divInstructorCourseContent"));
                initialBind = true; // this is to prevent binding multiple time because "Delete" functio calls GetAll again
            }
        });
    };
}