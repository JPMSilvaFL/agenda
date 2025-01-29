const express = require('express');
const route = express.Router();
const homeController = require('./src/controllers/homeController');
const erroController = require('./src/controllers/404Controller');
const loginController = require('./src/controllers/loginController');
const registerControler = require('./src/controllers/registerControler');
const cadastroContatoController = require('./src/controllers/cadastroContatoController');

// Rotas da home
route.get('/', homeController.paginaInicial);
route.post('/', homeController.trataPost);

// Rotas de contato
route.get('/404', erroController.paginaInicial);
route.get('/login', loginController.paginaInicial);
route.get('/register', registerControler.paginaInicial);
route.get('/cadastroContato', cadastroContatoController.paginaInicial);


module.exports = route;
