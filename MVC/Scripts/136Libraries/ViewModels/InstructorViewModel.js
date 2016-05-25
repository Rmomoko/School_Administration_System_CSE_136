function InstructorViewModel() {
    var self = this;

    this.Load = function (id) {
        var instructorModelObj = new InstructorModel();

        // Because the Load() is a async call (asynchronous), we'll need to use
        // the callback approach to handle the data after data is loaded.
        instructorModelObj.Load(id, function (result) {

            var viewModel = {
                first: ko.observable(result.FirstName),
                last: ko.observable(result.LastName),
                id: result.Id,
                update: function () {
                    self.UpdateInstructor(this);
                }
            }

            ko.applyBindings(viewModel, document.getElementById("divAdminEdit"));
        });
    };

    this.UpdateInstructor = function (viewModel) {
        var instructorModelObj = new InstructorModel();

        // convert the viewModel to same structure as PLAdmin model (presentation layer model)
        var instructorData = {
            Id: viewModel.id,
            FirstName: viewModel.first(),
            LastName: viewModel.last()
        };

        instructorModelObj.Update(instructorData, function (message) {
            $('#divMessage').html(message);
        });

    };
}
