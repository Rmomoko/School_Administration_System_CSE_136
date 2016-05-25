function EnrollmentModel(asyncIndicator) {
    if (asyncIndicator == undefined) {
        asyncIndicator = true;
    }

    this.GetAll = function (id, callback) {
        var url = "http://localhost:9393/Api/StudentEnrollment/GetEnrollments?studentId=" + id;
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

    this.deleteStudentEnrollment = function (studentId, scheduleId) {
        $.ajax({
            async: asyncIndicator,
            method: "POST",
            url: "http://localhost:9393/Api/StudentEnrollment/DropEnrolledSchedule?studentId=" + studentId + "&scheduleId=" + scheduleId,
            data: "",
            dataType: "json",
            success: function (result) {
            },
            error: function () {
            }
        });
    }
}