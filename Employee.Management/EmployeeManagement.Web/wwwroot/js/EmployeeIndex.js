function openModal() {
    $('#modal-form')[0].reset();
    $('#EmployeeId').val(0);
    $('#modal').modal('show');
}

function editEmployee(id) {
    $.getJSON('employees/Get', { id: id }, function (data) {
        $('#Name').val(data.name);
        $('#Address').val(data.address);
        $('#PhoneNumber').val(data.phoneNumber);
        $('#DepartmentId').val(data.departmentId);
        $('#EmployeeId').val(id);
        $('#modal').modal('show');
    });
}

function deleteEmployee(id) {
    if (confirm("Are you sure!") == true) {
        $.ajax({
            type: "POST",
            url: "employees/Delete?id=" + id,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                if (response == true) {
                    $('#row-' + id).empty();

                } else {
                    alert('error!')
                }
            },
            failure: function (response) {
                alert(response.responseText);
            },
            error: function (response) {
                alert(response.responseText);
            }
        });
    }
}