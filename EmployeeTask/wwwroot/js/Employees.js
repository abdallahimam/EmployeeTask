$(document).ready(function () {

	//loadEmployeeData();

	$('#Employees').dataTable({
		"processing": true,
		"serverSide": true,
		"filter": false,
		"ajax": {
			"url": "/api/Employee",
			"type": "POST",
			"datatype": "json"
		},
		"lengthMenu": [2],
		"columnDefs": [{
			"targets": [0],
			"visible": false,
			"searchable": false
		}],
		"columns": [
			{ "data": 'id', "name": 'Id', "autowidth": true },
			{ "data": 'name', "name": 'Name', "autowidth": true },
			{ "data": 'age', "name": 'Age', "autowidth": true },
			{ "data": 'addresses[, <br /> ].description', "name": 'Addresses', "autowidth": true },
			{
				"data": null,
				"render": function (data, type, row) {
					return '<a class="btn btn-info mr-2" href="/Demo/Edit/' + row.id + '">Edit</a>' + '<a class="btn btn-danger me-2" href="/Demo/Delete/' + row.id + '">Delete</a>'
				}
			}
		],
	});

	$(".addresses-toggle").keydown(function (event) {
		if (event.keyCode == 9 || event.keyCode == 13 || event.keyCode == 32) {
			event.preventDefault();
			return;
		}

		var value = $(this).val() + "";
		if (event.keyCode == 8) {
			alert(value.trim().length);
			if (value.trim().length - 1 > 0) {
				$("#addNewAddress").prop("disabled", false);
			}
			else {
				$("#addNewAddress").prop("disabled", true);
			}
			return;
		}

		if (value.trim().length + 1 > 0) {
			$("#addNewAddress").prop("disabled", false);
		}
		else {
			$("#addNewAddress").prop("disabled", true);
		}
	});

	$("#AddNewEmployees").on("submit", function (event) {
		event.preventDefault();
		const form = new FormData(event.target);
		var object = {};
		form.forEach(function (value, key) {
			object[key] = value;
		});
		var json = JSON.stringify(object);
		alert(json);

		$.ajax({
			type: "POST",
			datatype: "json",
			url: "/api/Employee",
			data: json, // serializes the form's elements.
			success: function (data) {
				alert(data); // show response from the php script.
			},
			error: function (err) {
				alert(err);
			}
		});
	});

	$("#addNewAddress").on("click", function (event) {
		event.preventDefault();
		var rowAddresses = $("#rowAddresses");
		var id = parseInt($("#addressId").val());
		alert(id);
		
		var old = $("#addresses_" + id + "").val();
		alert(old);
		if (old.trim() == '') {
			return;
		}
		id += 1;
		var newAddressField = '<div class="col-10"><input id="addresses_' + id + '" class="form-control mb-2" name="addresses[]" type="text" /></div>';
		$("#addressId").val(id);

		rowAddresses.append(newAddressField);
	});

});

function loadEmployeeData() {

	var employeeData = [];
	$.ajax({
		type: "POST",
		url: "/Employee/GetAll",
		async: false,
		success: function (data) {
			$.each(data, function (key, value) {
				var editbtn = "<a onclick='FunEditEmlpoyee(this)' class='btn btn-primary'>Edit</a>";
				var removebtn = "<a onclick='FunRemoveEmlpoyee(this)' class='btn btn-danger'>Remove</a>";
				var hdn = "<input type='hidden' value=" + value.id + " />";
				var action = editbtn + " | " + removebtn + hdn;
				empdata.push([value.code, value.name, value.email, value.phone, value.designation, action])
			});
		},
		failure: function (err) {
			alert(err);
		}
	});

	$('#Employeess').dataTable({
		data: employeeData
	});
}

function FunEditEmlpoyee(element) {
	var idStr = $(element).closest("tr").find("input[type=hidden]").val();
	if (id == null || id == undefined)
		return;

}

function validateName(field) {

	if (name == null || name == undefined || name == "") {
		return "Invalid value";
	}
	var name = field + "";
	if (name.includes(" ")) {
		return "Name shouldn't conatins whitespaces!!";
	}

	return name;
}