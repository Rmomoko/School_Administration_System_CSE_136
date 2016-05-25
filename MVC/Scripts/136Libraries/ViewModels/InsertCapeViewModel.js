function InsertCapeViewModel() {

    var self = this;
    var initialBind = false;

    this.Load = function (id) {
            var viewModel = {
                courseTitle: id,
                easinessSel: ko.observableArray([1,2,3,4,5]),
                helpfulnessSel: ko.observableArray([1, 2, 3, 4, 5]),
                claritySel: ko.observableArray([1, 2, 3, 4, 5]),
                easiness: ko.observable(),
                helpfulness: ko.observable(),
                clarity: ko.observable(),
                hoursSpend: 0.0,
                insertCape: function () {
                    self.InsertCape(this);
                }
            }
            ko.applyBindings(viewModel, document.getElementById("divCapeData"));
    };
   
    this.InsertCape = function (data) {
        var InsertCapeModelObj = new InsertCapeModel();

        var viewModel = {
            CourseTitle: data.courseTitle,
            Easiness: data.easiness,
            Helpfulness: data.helpfulness,
            Clarity: data.clarity,
            Hours_spend: data.hoursSpend
        };

        InsertCapeModelObj.InsertCape(viewModel, function (result) {
            if (result == "ok") {
                history.back();
            } else {
                alert("Error occurred");
            }
        });
    };
}