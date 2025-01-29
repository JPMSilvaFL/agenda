const { query } = require('express');
const path = require('path'); // CommonJS
const { TLSSocket } = require('tls');


module.exports = {
  mode: 'production',
  entry: './server.js',
  output: {
    path: path.resolve(__dirname, 'public', 'assets', 'js'),
    filename: 'bundle.js'
  },
  // resolve: {
  //   fallback: {
  //     path: require.resolve("path-browserify"),
  //     crypto: false,
  //     fs: false,
  //     http: false,
  //     https: false,
  //     os: false,
  //     stream: false,
  //     util: false,
  //     zlib: false,
  //     timers: false,
  //     dns: false,
  //     tls: false,
  //     net: false,
  //     querystring: false,
  //     console: false


  //   }
  // },
  module: {

    rules: [{
      exclude: /node_modules/,
      test: /\.js | .ejs$/,
      use: {
        loader: 'babel-loader',
        options: {
          presets: ['@babel/env']
        }
      }
    }, {
      test: /\.css$/,
      use: ['style-loader', 'css-loader']
    }]
  },

  devtool: 'source-map'
};
