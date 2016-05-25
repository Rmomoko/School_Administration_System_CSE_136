function InstructorModel() {

    this.Load = function (instructorId, callback) {
        $.ajax({
            method: 'GET',
            url: "http://localhost:9393/Api/Instructor/GetInstructorInfo?InstructorId=" + instructorId,
            data: "",
            dataType: "json",
            success: function (result) {
                // when ajax call recevies data, it'll call the function "callback" which is passed in this as a parameter.
                // See AdminViewModel.load and see how it's being used
                callback(result); // "that" is currently pointing to the AdminModel object
            },
            error: function () {
                // if the call fails, it will return FirstName="First" and LastName="Last"
                alert('Error while loading instructor info.');
                callback("Error while loading instructor info");
            }
        });
    };

    this.Update = function (instructorData, callback) {
        $.ajax({
            method: 'POST',
            url: "http://localhost:9393/Api/Instructor/UpdateInstructorInfo",
            data: instructorData, // note, adminData must be the same as PLAdmin for this to work correctly
            success: function (message) {
                callback(message);
            },
            error: function () {
                callback('Error while updating instructor info');
            }
        });
    };
}

