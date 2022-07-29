using app.Helper;
using app.Models;
using app.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace app.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessao _sessao;

        public UsuarioController (IUsuarioRepositorio usuarioRepositorio,
                                    ISessao sessao)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
        }
        public IActionResult IndexLogado()
        {
            //Se usuário estiver logado, redirecionar para home.

            if (_sessao.BuscarSessaoUsuario() != null) return RedirectToAction("IndexLogado", "Home");
            return View();
        }

        public IActionResult Sair()
        {
            _sessao.RemoverSessaoDoUsuario();

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    usuario = _usuarioRepositorio.Adicionar(usuario);

                    TempData["MensagemSucesso"] = $"Usuário cadastrado com sucesso!";
                }
                return View();
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar seu usuário, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Cadastro");
            }

        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                //Login feito com sucesso:
                if (ModelState.IsValid)
                {
                    UsuarioModel usuario = _usuarioRepositorio.BuscarPorLogin(loginModel.Email);

                    //Procurando usuário no banco de dados
                    if (usuario != null)
                    {
                        //Caso o email digitado exista no banco, ele fará a confirmação da senha.
                        //Se também existir, será feito o login, se não, será mostrada a mensagem de erro.
                        if (usuario.SenhaValida(loginModel.Senha))
                        {
                            _sessao.CriarSessaoDoUsuario(usuario);

                            //return RedirectToAction ("Nome da view", "Nome da controller dela");
                            return RedirectToAction("IndexLogado", "Home");
                        }

                        TempData["MensagemErro"] = $"Senha do usuário é inválida. Tente novamente.";                        
                    }

                    TempData["MensagemErro"] = $"Usuário e/ou senha inválidos, tente novamente.";

                }
                return View("Login");
            }
            //Erro durante o login:
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos realizar seu login, tente novamente. Detalhe do erro: {erro.Message}";
                return RedirectToAction("Login");
            }
        }

        public IActionResult Perfil()
        {
            List<UsuarioModel> usuario = _usuarioRepositorio.BuscarTodos();
            return View(usuario);
        }

        /*[HttpPost]
        public IActionResult EditarU(/*string UserNamee)
        {
            //UsuarioModel usuario = _usuarioRepositorio.BuscarPorID(UserName);
            //
            //return View(usuario);

            return View();
        }*/

        public IActionResult EditarU()
        {
            return View();
        }

        public IActionResult ApagarConfirm(string UserName)
        {
            UsuarioModel usuario = _usuarioRepositorio.BuscarPorUserName(UserName);
            return View(usuario);
        }
        public IActionResult Apagar(string UserName)
        {
            try
            {
                bool apagado = _usuarioRepositorio.Apagar(UserName);

                if (apagado) TempData["MensagemSucesso"] = "Usuário apagado com sucesso!"; else TempData["MensagemErro"] = "Ops, não conseguimos apagar seu usuário, tente novamante!";
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos apagar seu usuário, tente novamante, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index", "Home");
            }
        }

    }
}
