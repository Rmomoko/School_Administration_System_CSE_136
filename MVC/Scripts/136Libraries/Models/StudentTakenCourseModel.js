//// THe reason for asyncIndicator is to make sure Jasmine test cases can run without error
//// Due to async nature of ajax, the Jasmine's compare function would throw an error during
//// a callback. By allowing this optional paramter for StudentModel function, it forces the ajax
//// call to be synchronous when running the Jasmine tests.  However, the viewModel will not pass
//// this parameter so the asynncIndicator would be undefined which is set to "true". Ajax would
//// be async when called by viewModel.
function StudentTakenCourseModel(asyncIndicator) {
    if (asyncIndicator == undefined) {
        asyncIndicator = true;
    }

    this.GetAll = function (studentId, callback) {
        var url = "http://localhost:9393/Api/StudentTakenCourse/GetStudentTakenCourse?studentId=" + studentId;
       
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
                alert('Error while loading student taken course list.  Is your service layer running?');
            }
        });
    };

    this.deleteStudentTakenCourse = function (studentId, courseId, callback) {
        $.ajax({
            async: asyncIndicator,
            method: "POST",
            url: "http://localhost:9393/Api/StudentTakenCourse/DeleteStudentTakenCourse?studentId=" + studentId + "&courseId=" +courseId,
            data: "",
            dataType: "json",
            success: function (result) {
                callback(result);
            },
            error: function () {
                alert('Error while deleteing student.  Is your service layer running?');
            }
        });
    }

    this.insertStudentTakenCourse = function (data, callback) {
        $.ajax({
            async: asyncIndicator,
            method: "POST",
            url: "http://localhost:9393/Api/StudentTakenCourse/InsertStudentTakenCourse",
            data: data,
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
