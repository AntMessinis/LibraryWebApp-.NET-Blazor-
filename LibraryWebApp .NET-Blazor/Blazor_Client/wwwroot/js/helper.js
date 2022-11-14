window.ShowToastr = (type, message) => {
    if (type === "success") {
        toastr.success(message, "Operation Success", {timeout : 5000})
    }

    if (type === "error") {
        toastr.error(message, "Operation Fail", {timeout : 5000})
    }
}

function ShowDeleteModal{
    $('#deleteConfirmationModal').modal("show");
}

function HideDeleteModal{
    $('#deleteConfirmationModal').modal("hide");
}