$("#updateEmployee").click(function () {
    alert("JS is bad");
    var id = sessionStorage.getItem("ID");
    var salary = $("#salaryRow").val();
    var email = $("#emailRow").val();
    $.ajax({
        type: "PUT",
        url: '/Employee/UpdateEmployee',
        data: { "EmployeeId": id, "USDSalary": salary, "Email": email },
        succes: function () {
            alert('Act happened');
        }
    });
});

$('a[id = "storeId"]').click(function () {
    alert("Button works");
    var id = $(this).attr("storedId");
    sessionStorage.setItem("ID", id);
});

$("#deleteEmployee").click(function (){
    alert("JS is bad");
    var EmployeeId = $(this).attr("employeeId");
    $.ajax({
        type: "DELETE",
        url: '/Employee/Delete',
        data: { "id": EmployeeId },
        success: function (response) {
            $("tr[id='EmployeeId']").remove();
        },
        error: function (response) {
            $("tr[id='EmployeeId']").remove();
            alert("Something wrong happened");
        }
       });
});

$("#createRole").click(function () {
    alert("post request works");
    var name = $("#rowWithName").val();
    $.ajax({
        type: "POST",
        url: '/Roles/Create',
        data: { "name": name },
        success: function () {
            alert("well");
        },
        error: function () {
            alert("baad(");
        }
    });
});

$("#setRoles").click(function () {
    alert("button works");
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
            alert("yahoo");
        },
        error: function () {
            alert("bad(");
        }
    });
});

$("#LogOutAction").click(function(){
    $.ajax({
        type: "POST",
        url: "/Account/LogOut",
        success: function(response){
            alert(response.responseText);
            window.location.href = "/Home/Index";
        },
        error: function(response){
            alert(response.responseText);
        }
    });
});