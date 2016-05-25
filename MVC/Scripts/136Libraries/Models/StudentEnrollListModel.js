function StudentEnrollListModel(asyncIndicator) {
    if (asyncIndicator == undefined) {
        asyncIndicator = true;
    }

    this.GetAll = function (scheduleId, callback) {
        var url = "http://localhost:9393/Api/StudentEnrollment/GetStudentEnrollList?scheduleId=" + scheduleId;

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
                alert('Error while loading student enroll course list.  Is your service layer running?');
            }
        });
    };
}
