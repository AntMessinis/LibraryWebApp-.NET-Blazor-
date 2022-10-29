window.ShowToastr = (type, message) => {
    if (type === "success") {
        toastr.success(message, 'Operation Success', { timeOut: 5000 })
    }

    if (type === "error") {
        toastr.error(message, 'Operation fail', { timeOut: 5000 })
    }
}