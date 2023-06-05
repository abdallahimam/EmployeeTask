$(document).ready(function () {

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
		var newAddressField = '<div class="col-10"><input id="addresses_' + id + '" class="form-control mb-2 addresses-toggle" name="addresses[]" type="text" /></div>';
		$("#addressId").val(id);

		rowAddresses.append(newAddressField);
	});

});
