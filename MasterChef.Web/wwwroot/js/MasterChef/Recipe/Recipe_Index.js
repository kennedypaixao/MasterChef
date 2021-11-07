var model = null;
var activeRecipe = null;

$(document).ready(function () {
	_getList();

	$(".btn-new").click(() => {
		activeRecipe = null;
		$(".edt-name").val("");
		$(".edt-uid").val("");
		$(".modal-recipe").modal("show");
	});

	$(".btn-save").click(() => {
		_save();
	});

});

function _getList() {
	axios.get(API_ROUTE + '/Recipe/GetList')
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
	$(".grid-content").append('<table class="display grid-recipe" style="width:100%"></table>');

	var table = $('.grid-recipe').DataTable({
		data: model,
		columnDefs: [{
			"targets": -1,
			"data": null,
			"defaultContent": ` <button type="button" class="btn btn-outline-primary btn-edit">Editar</button>
								<button type="button" class="btn btn-outline-danger btn-delete">Excluir</button> `
		}],
		columns: [
			{ title: "Nome", "data": "name" },
			{ title: "Opções", "width": "16%", "orderable": false }
		]
	});

	$('.grid-recipe tbody').on('click', '.btn-edit', function () {
		var data = table.row($(this).parents('tr')).data();
		_edit(data);
	});

	$('.grid-recipe tbody').on('click', '.btn-delete', function () {
		var data = table.row($(this).parents('tr')).data();
		_delete(data.uid);
	});
}

function _delete(uid) {
	var r = confirm("Deseja excluir esse registro?");
	if (r == true) {
		axios.delete(API_ROUTE + '/Recipe/delete', { params: { 'uid': uid } })
			.then((response) => {
				if (response.status === 200) {
					$(".modal-recipe").modal("hide");
					_getList();
				} else {
					alert("Ocorreu um erro ao excluir receita");
				}
			}).catch(error => {
				alert("Ocorreu um erro ao excluir receita");
			});
	}
}

function _edit(recipe) {
	activeRecipe = recipe;
	if (activeRecipe != null) {
		$(".edt-name").val(activeRecipe.name);
		$(".edt-uid").val(activeRecipe.uid);
		$(".modal-recipe").modal("show");
	}
}

function _save() {

	var name = $(".edt-name").val();
	if (name == '') {
		alert("Informar o nome da receita");
		return;
	}

	var data = {
		"uid": $(".edt-uid").val() || null,
		"name": name,
		"ingredients": []
	};

	var url = '/Recipe/Insert';
	if (data.uid != null) {
		url = '/Recipe/update';

		axios.put(API_ROUTE + url, data)
			.then((response) => {
				if (response.status === 200) {
					$(".modal-recipe").modal("hide");
					_getList();
				} else {
					alert("Ocorreu um erro ao atualizar receita");
				}
			}).catch(error => {
				alert("Ocorreu um erro ao atualizar receita");
			});
	} else {
		data.uid = generateUUID();

		axios.post(API_ROUTE + url, data)
			.then((response) => {
				if (response.status === 200) {
					$(".modal-recipe").modal("hide");
					_getList();
				} else {
					alert("Ocorreu um erro ao cadastrar receita");
				}
			}).catch(error => {
				alert("Ocorreu um erro ao cadastrar receita");
			});
	}
}
