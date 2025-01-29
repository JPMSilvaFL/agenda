const Login = require('../models/LoginModel');

exports.paginaInicial = (req, res) => {
  res.render('login');
};

exports.realizaLogin = async (req, res) => {
  try {
    const login = new Login(req.body);
    await login.login();

    if (login.errors.length > 0) {
      req.flash('errors', login.errors);
      req.session.save(() => res.redirect('/login/index'));
      return;
    }
    req.flash("success", "Logado com sucesso.");
    req.session.user = login.user;
    req.session.save(() => res.redirect('/'));

  } catch (e) {
    console.log(e);
    return res.render('404');
  }
};