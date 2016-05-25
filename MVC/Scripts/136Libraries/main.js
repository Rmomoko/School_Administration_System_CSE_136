function goBack() {
    window.history.back();
}

function confirm() {
    dialogBox.confirm("Reasons here", function (result) {
        Example.show("Confirm result: " + result);
    });
}
