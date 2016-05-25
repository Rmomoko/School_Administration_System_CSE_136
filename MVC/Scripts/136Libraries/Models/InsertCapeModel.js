function InsertCapeModel(asyncIndicator) {
    if (asyncIndicator == undefined) {
        asyncIndicator = true;
    }

    this.Load = function (id, callback) {
        $.ajax({
            method: '',
            url: "",
            data: "",
            dataType: "json",
            success: function (result) {
                // when ajax call recevies data, it'll call the function "callback" which is passed in this as a parameter.
                // See AdminViewModel.load and see how it's being used
                callback(result); // "that" is currently pointing to the AdminModel object
            },
            error: function () {
                // if the call fails, it will return FirstName="First" and LastName="Last"
                alert('Error while loading cape info.');
                callback("Error while loading cape info");
            }
        });
    };


    this.InsertCape = function (cape, callback) {
        $.ajax({
            async: asyncIndicator,
            method: "POST",
            url: "http://localhost:9393/Api/Cape/InsertCapeData",
            data: cape,
            dataType: "json",
            success: function (result) {
                callback(result);
            },
            error: function () {
                alert('Error while adding student.  Is your service layer running?');
            }
        });
    };
}
