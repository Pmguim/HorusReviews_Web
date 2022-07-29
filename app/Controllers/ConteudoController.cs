using app.Models;
using app.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace app.Controllers
{
    public class ConteudoController : Controller
    {
        private readonly IComentarioRepositorio _comentarioRepositorio;
        private readonly IConteudoRepositorio _conteudoRepositorio;
        public ConteudoController(IComentarioRepositorio comentarioRepositorio, 
                                    IConteudoRepositorio conteudoRepositorio)
        {
            _comentarioRepositorio = comentarioRepositorio;
            _conteudoRepositorio = conteudoRepositorio;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Series_1()
        {
            return View();
        }
        public IActionResult Series_1_Logado()
        {
            return View();
        }
        public IActionResult Series_2()
        {
            return View();
        }
        public IActionResult Series_2_Logado()
        {
            return View();
        }
        public IActionResult Filmes_1()
        {
            return View();
        }
        public IActionResult Filmes_1_Logado()
        {
            return View();
        }
        public IActionResult Filmes_2()
        {
            return View();
        }
        public IActionResult Filmes_2_Logado()
        {
            return View();
        }

        public IActionResult Todos()
        {
            //Listando conteudos do banco na página do conteúdo.
            List<ConteudoModel> conteudos = _conteudoRepositorio.BuscarTodos();
            return View(conteudos);
        }
        public IActionResult Todos_Logado()
        {
            //Listando conteudos do banco na página do conteúdo.
            List<ConteudoModel> conteudos = _conteudoRepositorio.BuscarTodos();
            return View(conteudos);
        }

        public IActionResult Animes()
        {
            return View();
        }
        public IActionResult Animes_Logado()
        {
            return View();
        }

        public IActionResult DStrange()
        {
            //Listando comentários do banco na página do conteúdo.
            List<ComentarioModel> comentarios = _comentarioRepositorio.BuscarTodos();
            return View(comentarios);
        }

        public IActionResult DStrangeLogado()
        {
            //Listando comentários do banco na página do conteúdo logado.
            List<ComentarioModel> comentarios = _comentarioRepositorio.BuscarTodos();
            return View(comentarios);
        }
        public IActionResult Comentario()
        {
            ViewBag.mensagemErro = "Não foi possível enviar seu comentário. Tente novamente!";
            ViewBag.mensagemSucesso = "Comentário enviado com sucesso!";

            return View();
        }

        [HttpPost]
        public IActionResult Criar(ComentarioModel comentario)
        {
            try { 
                if (ModelState.IsValid)
                {
                    _comentarioRepositorio.Adicionar(comentario);
                    TempData["MensagemSucesso"] = "Comentário registrado com sucesso";
                    return RedirectToAction("DStrangeLogado");
                }

                return View("Comentario", comentario);
            } catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Erro ao registrar o comentário. Por favor, tente novamente. Detalhe do erro: {erro.Message}";
                return RedirectToAction("DStrangeLogado");
            }
        }

        public IActionResult EditarC(int CodComent)
        {
            ComentarioModel comentario = _comentarioRepositorio.ListarPorId(CodComent);
            return View(comentario);
        }

        [HttpPost]
        public IActionResult Alterar(ComentarioModel comentario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _comentarioRepositorio.Atualizar(comentario);
                    TempData["MensagemSucesso"] = "Comentário editado com sucesso";
                    return RedirectToAction("DStrangeLogado");
                }

                return View("Editar");
            } 
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Erro ao editar o comentário. Por favor, tente novamente. Detalhe do erro: {erro.Message}";
                return RedirectToAction("DstrangeLogado");
            }
        }

        public IActionResult ApagarC(int CodComent)
        {
            ComentarioModel comentario = _comentarioRepositorio.ListarPorId(CodComent);
            return View(comentario);
        }

        public IActionResult Apagar(int CodComent)
        {
            _comentarioRepositorio.Apagar(CodComent);
            return RedirectToAction("DStrangeLogado", "Conteudo");
        }

        /*public IActionResult Apagar(int CodComent)
        {
            try
            {
                bool apagado = _comentarioRepositorio.Apagar(CodComent);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Comentário deletado com sucesso";
                }
                else
                {
                    TempData["MensagemErro"] = "Erro ao deletar o comentário, tente novamente.";
                }
            
                return RedirectToAction("DStrangeLogado");                
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Erro ao editar o comentário. Por favor, tente novamente. Detalhe do erro: {erro.Message}";
                return RedirectToAction("DstrangeLogado");
            }
        }

        /*[HttpPost]
        public IActionResult Comentario(ComentarioModel comentario)
        {
            _comentarioRepositorio.Adicionar(comentario);
            return RedirectToAction("DStrangeLogado");
        }*/

    }
}
