$(document).ready(function () {
	$('.btn-login').click(function () {
		var email = $('.edt-email').val();
		var pwd = $('.edt-senha').val();

		if (email == '') {
			alert("E-mail inválido.");
			return;
		}

		if (pwd == '') {
			alert("Senha inválida.");
			return;
		}

		axios.get(API_ROUTE + '/Account?email=' + email + '&password=' + pwd)
			.then((response) => {
				if (response.status === 200) {
					window.location.href = '/Recipe/Index';
				} else {
					$('.edt-senha').val('');
					alert("Usuário ou Senha inválidos.");
				}
			}).catch(error => {
				$('.edt-senha').val('');
				alert("Usuário ou Senha inválidos.");
			});
	});
});
