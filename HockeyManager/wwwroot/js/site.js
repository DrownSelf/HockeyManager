$("#updateEmployee").click(function () {
    var id = sessionStorage.getItem("ID");
    var salary = $("#salaryRow").val();
    var email = $("#emailRow").val();
    $.ajax({
        type: "PUT",
        url: '/Employee/UpdateEmployee',
        data: { "EmployeeId": id, "USDSalary": salary, "Email": email },
        success: function () {
            window.location.href = "/Employee/Manager"
        }
    });
});

$('a[id = "storeId"]').click(function () {
    var id = $(this).attr("storedId");
    sessionStorage.setItem("ID", id);
});

$("#deleteEmployee").click(function (){
    var EmployeeId = $(this).attr("employeeId");
    $.ajax({
        type: "DELETE",
        url: '/Employee/Delete',
        data: { "id": EmployeeId },
        success: function () {
            $("tr[id='"+EmployeeId+"']").remove();
        },
        error: function (response) {
            alert(response.responseText);
        }
       });
});

$("#deleteRole").click(function () {
    var RoleId = $(this).attr("RoleId");
    $.ajax({
        type: "DELETE",
        url: '/Roles/DeleteRole',
        data: { "id": RoleId },
        success: function () {
            $("tr[id='" + RoleId + "']").remove();
            alert("delete works");
        },
        error: function () {
            alert("bad(");
        }
    });
});

$("#createRole").click(function () {
    var name = $("#rowWithName").val();
    $.ajax({
        type: "POST",
        url: '/Roles/Create',
        data: { "name": name },
        success: function () {
            window.location.href = "/Roles/RolesManager";
        },
        error: function () {
            alert("baad(");
        }
    });
});

$("#setRoleName").click(function () {
    alert("button works");
    var id = sessionStorage.getItem("ID");
    var name = $("#getName").val();
    $.ajax({
        type: "PUT",
        url: 'Roles/RolesUpdate',
        data: { "id": id, "newName": name },
        success: function () {
            window.location.href = "/Roles/RolesManager";
        },
        error: function () {
            alert("something wrong happened");
        }
    });
});

$("#setRoles").click(function () {
    var id = sessionStorage.getItem("ID");
    var acceptedRoles = new Array();
    var checkBoxes = document.getElementsByName("Roles");
    for (var i = 0, length = checkBoxes.length; i < length; i++) {
        if (checkBoxes[i].checked) {
            acceptedRoles.push(checkBoxes[i].getAttribute("storedName"));
            alert(checkBoxes[i].getAttribute("storedName"));
        }
    }
    $.ajax({
        type: "PUT",
        url: "/Roles/EditRoleState",
        data: { "UserId": id, "Roles": acceptedRoles },
        success: function () {
            window.location.href = "/Employee/Manager";
        },
        error: function () {
            alert("bad(");
        }
    });
});

$("#LogOutAction").click(function(){
    $.ajax({
        type: "POST",
        url: "/Employee/LogOut",
        success: function(response){
            alert(response.responseText);
            window.location.href = "/Home/Index";
        },
        error: function(response){
            alert(response.responseText);
        }
    });
});