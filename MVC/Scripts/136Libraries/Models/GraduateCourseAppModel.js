function GraduateCourseAppModel(asyncIndicator) {
    if (asyncIndicator == undefined) {
        asyncIndicator = true;
    }

    this.GetAll = function (callback) {
        var url = "http://localhost:9393/Api/GraduateCourseApp/GetAllGraduateCourseApp";

        console.log(url);
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
}
