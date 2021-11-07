var model = null;
var activeIngredient = null;

$(document).ready(function () {
	_getListRecipe();
	_getList();

	$(".btn-new").click(() => {
		activeIngredient = null;
		$(".edt-uid").val("");
		$(".cbx-recipe").val("");
		$(".edt-description").val("");
		$(".edt-measure-value").val("");
		$(".cbx-measure").val("");
		$(".modal-ingredient").modal("show");
	});

	$(".btn-save").click(() => {
		_save();
	});
});

function _getListRecipe() {
	axios.get(API_ROUTE + '/Recipe/GetList')
		.then((response) => {
			if (response.status === 200) {
				$(".cbx-recipe").empty();
				$(".cbx-recipe").append($("<option></option>"));
				response.data.forEach((element, index) => {
					$(".cbx-recipe").append($("<option></option>").prop("value", element.uid).html(element.name));
				});
			}
		}).catch(error => {
			console.error(error);
		});
}

function _getList() {
	axios.get(API_ROUTE + '/Ingredient/GetList')
		.then((response) => {
			if (response.status === 200) {
				model = response.data;
				_instanceGrid();
			}
		}).catch(error => {
			console.error(error);
		});
}

function _instanceGrid() {

	$(".grid-content").empty();
	$(".grid-content").append('<table class="display grid-ingredient" style="width:100%"></table>');

	var table = $('.grid-ingredient').DataTable({
		data: model,
		columnDefs: [{
			"targets": -1,
			"data": null,
			"defaultContent": ` <button type="button" class="btn btn-outline-primary btn-edit">Editar</button>
								<button type="button" class="btn btn-outline-danger btn-delete">Excluir</button> `
		}],
		columns: [
			{ title: "Ingredient", "data": "description" },
			{ title: "Valor", "data": "valueMeasure" },
			{ title: "Medida", "data": "measureDescription" },
			{ title: "Opções", "width": "16%", "orderable": false }
		]
	});

	$('.grid-ingredient tbody').on('click', '.btn-edit', function () {
		var data = table.row($(this).parents('tr')).data();
		_edit(data);
	});

	$('.grid-ingredient tbody').on('click', '.btn-delete', function () {
		var data = table.row($(this).parents('tr')).data();
		_delete(data.uid);
	});
}

function _delete(uid) {
	var r = confirm("Deseja excluir esse registro?");
	if (r == true) {
		axios.delete(API_ROUTE + '/Ingredient/delete', { params: { 'uid': uid } })
			.then((response) => {
				if (response.status === 200) {
					$(".modal-ingredient").modal("hide");
					_getList();
				} else {
					alert("Ocorreu um erro ao excluir receita");
				}
			}).catch(error => {
				alert("Ocorreu um erro ao excluir receita");
			});
	}
}

function _edit(ingredient) {
	activeIngredient = ingredient;
	if (activeIngredient != null) {
		$(".edt-uid").val(activeIngredient.uid);
		$(".cbx-recipe").val(activeIngredient.uidRecipe);
		$(".edt-description").val(activeIngredient.description);
		$(".edt-measure-value").val(activeIngredient.valueMeasure);
		$(".cbx-measure").val(activeIngredient.measure);
		$(".modal-ingredient").modal("show");
	}
}

function _save() {

	var recipe = $(".cbx-recipe").val();
	if (recipe == '') {
		alert("Informar a receita");
		return;
	}

	var description = $(".edt-description").val();
	if (description == '') {
		alert("Informar o ingredient");
		return;
	}

	var value = $(".edt-measure-value").val();
	if (value == '') {
		alert("Informar o valor");
		return;
	}

	var measure = $(".cbx-measure").val();
	if (measure == '') {
		alert("Informar a medida");
		return;
	}

	var data = {
		"uid": $(".edt-uid").val() || null,
		"uidRecipe": recipe,
		"description": description,
		"valueMeasure": value,
		"measure": parseInt(measure)
	};

	var url = '/Ingredient/Insert';
	if (data.uid != null) {
		url = '/Ingredient/update';

		axios.put(API_ROUTE + url, data)
			.then((response) => {
				if (response.status === 200) {
					$(".modal-ingredient").modal("hide");
					_getList();
				} else {
					alert("Ocorreu um erro ao atualizar ingrediente.");
				}
			}).catch(error => {
				alert("Ocorreu um erro ao atualizar ingrediente.");
			});
	} else {
		data.uid = generateUUID();

		axios.post(API_ROUTE + url, data)
			.then((response) => {
				if (response.status === 200) {
					$(".modal-ingredient").modal("hide");
					_getList();
				} else {
					alert("Ocorreu um erro ao cadastrar ingrediente.");
				}
			}).catch(error => {
				alert("Ocorreu um erro ao cadastrar ingrediente.");
			});
	}
}
