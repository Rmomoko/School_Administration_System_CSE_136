function StudentViewModel() {

    var self = this;
    var initialBind = true;
    var studentListViewModel = ko.observableArray();

    this.Load = function (id) {
        var StudentModelObj = new StudentModel();
        
        StudentModelObj.Load(id, function (result) {

            var viewModel = {
                id: ko.observable(result.StudentId),
                ssn: ko.observable(result.SSN),
                first: ko.observable(result.FirstName),
                last: ko.observable(result.LastName),
                email: ko.observable(result.Email),
                password: ko.observable(result.Password),
                shoesize: ko.observable(result.ShoeSize),
                weight: ko.observable(result.Weight),
                level: ko.observable(result.StudentLevel),
                category: ko.observable(result.StudentCategory),
                update: function () {
                    self.UpdateStudent(this);
                }
            }

            ko.applyBindings(viewModel, document.getElementById("divStudentEdit"));
        });
    };

    this.UpdateStudent = function (viewModel) {
        var StudentModelObj = new StudentModel();

        // convert the viewModel to same structure as PLAdmin model (presentation layer model)
        var studentData = {
            StudentId: viewModel.id,
            SSN: viewModel.ssn(),
            FirstName: viewModel.first(),
            LastName: viewModel.last(),
            Email: viewModel.email(),
            Password: viewModel.password(),
            ShoeSize: viewModel.shoesize(),
            Weight: viewModel.weight(),
            StudentLevel: viewModel.level(),
            StudentCategory: viewModel.category()
        };

        StudentModelObj.Update(studentData, function (message) {
            $('#divMessage').html(message);
        });

    };

    this.CreateStudent = function (data) {
        var StudentModelObj = new StudentModel();
        var model = {
            StudentId: data.id(),
            SSN: data.ssn(),
            FirstName: data.first(),
            LastName: data.last(),
            Email: data.email(),
            Password: data.password(),
            ShoeSize: data.shoesize(),
            Weight: data.weight()
        }

        StudentModelObj.Create(model, function(result) {
            if (result == "ok") {
                alert("Create student successful");
            } else {
                alert("Error occurred");
            }
        });
    };

    this.GetAll = function () {
        var StudentModelObj = new StudentModel();
        StudentModelObj.GetAll(function(studentList) {
            studentListViewModel.removeAll();

            for (var i = 0; i < studentList.length; i++) {
                studentListViewModel.push({
                    id: studentList[i].StudentId,
                    first: studentList[i].FirstName,
                    last: studentList[i].LastName,
                    email: studentList[i].Email
                });
            }

            if (initialBind) {
                ko.applyBindings({ viewModel: studentListViewModel }, document.getElementById("divStudentListContent"));
                initialBind = false; // this is to prevent binding multiple time because "Delete" functio calls GetAll again
            }
        });
    };

    this.GetDetail = function (id) {
        var StudentModelObj = new StudentModel();

        StudentModelObj.GetDetail(id, function (result) {

            var student = {
                id: result.StudentId,
                first: result.FirstName,
                last: result.LastName,
                email: result.Email,
                shoesize: result.ShoeSize,
                weight: result.Weight,
                ssn: result.SSN
            };

            if (initialBind) {
                ko.applyBindings({ viewModel: student }, document.getElementById("divStudentContent"));
            }
        });
    };

    ko.bindingHandlers.DeleteStudent = {
        init: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
            $(element).click(function () {
                var StudentModelObj = new StudentModel();
                var id = viewModel.id;

                StudentModelObj.Delete(id, function(result) {
                    if (result != "ok") {
                        alert("Error occurred");
                    } else {
                        studentListViewModel.remove(viewModel);
                    }
                });
            });
        }
    }
}
