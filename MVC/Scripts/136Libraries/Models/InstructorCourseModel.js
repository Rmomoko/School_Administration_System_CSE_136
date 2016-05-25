function InstructorCourseModel(asyncIndicator) {
    if (asyncIndicator == undefined) {
        asyncIndicator = true;
    }

    this.GetAll = function (instructorId, callback) {
        var url = "http://localhost:9393/Api/InstructorCourse/GetInstructorCourseList?instructorId=" + instructorId;

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
                alert('Error while loading instructor course list.  Is your service layer running?');
            }
        });
    };
}
