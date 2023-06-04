$(document).ready(function () {

	$('#Employees').dataTable({
		processing: true,
		serverside: true,
		filter: false,
		ordering: false,
		lengthMenu: [2],
		ajax: {
			url: '/api/Employee',
			type: 'POST',
			datatype: 'json',
			contentType: "application/json; charset=utf-8",
			dataSrc: ""
		},
		columnDefs: [
			{
				targets: [0],
				visible: false,
				searchable: false
			}
		],
		columns: [
			{ data: 'id', name: 'Id', autowidth: true },
			{ data: 'name', name: 'Name', autowidth: true },
			{ data: 'age', name: 'Age', autowidth: true },
			{ data: 'addresses[, <br /> ].description', name: 'Addresses', autowidth: true },
			{
				data: null, render: function (data, type, row) { return '<a class="btn btn-info me-2" href="/Demo/Edit/' + row.id + '">Edit</a>' + '<a class="btn btn-danger me-2" href="/Demo/Delete/' + row.id + '">Delete</a>' }
			}
		],
	});


	$("#AddNewEmployee").on("submit", function (event) {
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

});