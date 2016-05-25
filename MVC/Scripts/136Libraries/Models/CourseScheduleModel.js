function CourseScheduleModel(asyncIndicator) {
    if (asyncIndicator == undefined) {
        asyncIndicator = true;
    }

    this.GetAll = function (id,callback) {
        var url = "http://localhost:9393/Api/CourseSchedule/GetCourseScheduleList";
        $.ajax({
            async: asyncIndicator,
            method: "GET",
            url: url,
            data: "",
            dataType: "json",
            success: function (result) {
                callback(result);
            },
            error: function (x, e) {
                alert('Error while loading cape.  Is your service layer running?');
            }
        });
    };

    this.enrollSchedule = function (data, callback) {
        $.ajax({
            async: asyncIndicator,
            method: "POST",
            url: "http://localhost:9393/Api/StudentEnrollment/EnrollSchedule?studentId=" + data.studentId + "&scheduleId=" + data.scheduleId + "&grade_option=Letter" + "&pre_req_status=1",
            data: "",
            dataType: "json",
            success: function (result) {
                callback(result);
            },
            error: function () {
                alert('Error while student enroll schedule.  Is your service layer running?');
            }
        });
    }
}