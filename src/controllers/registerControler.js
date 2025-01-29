const Login = require('../models/LoginModel');

exports.paginaInicial = (req, res) => {
  res.render('register');
};
exports.criarConta = async (req, res) => {
  try {
    const login = new Login(req.body);
    await login.register();

    if (login.errors.length > 0) {
      req.flash('errors', login.errors);
      req.session.save(() => res.redirect('/register/index'));
      return;
    }
    req.flash("success", "Seu usuário foi criado com sucesso. Faça login para acessar.");
    req.session.save(() => res.redirect('/login/index'));

  } catch (e) {
    console.log(e);
    return res.render('404');  
  }
};