function CapeViewModel() {

    var self = this;
    var initialBind = false;
    var capeViewModel = {
        capeList: ko.observableArray(),
        insertCape: function(){}
    };

    this.Initialize = function () {
        var CapeModelObj = new CapeModel();
        CapeModelObj.GetAll(function (cape) {
            capeViewModel.capeList.removeAll();
            if (cape != null) {
                for (var i = 0; i < cape.length; i++) {
                    capeViewModel.capeList.push({
                        courseTitle: cape[i].CourseTitle,
                        easiness: cape[i].AvgEasiness,
                        helpfulness: cape[i].AvgHelpfulness,
                        clarity: cape[i].AvgClarity,
                        hoursSpend: cape[i].AvgHours_spend
                    });
                }
            }

            if (!initialBind) {
                ko.applyBindings({ viewModel: capeViewModel }, document.getElementById("divCapeContent"));
                initialBind = true; // this is to prevent binding multiple time because "Delete" functio calls GetAll again
            }
        });
    };

    var insertCape = function () {
        alert("here");
    }
}