using Microsoft.AspNetCore.Mvc;
using QuickBuy.Dominio.Contratos;
using QuickBuy.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickBuy.Web.Controllers
{
   [Route("api/[controller]")]//informando como vai ser invocado 
    public class ProdutoController : Controller//tem que herda de controller pra ser um controlador api
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        public ProdutoController(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;//no asp tem que passar um produto instanciando se não da pau
        }// eu só informei a maneira como ele vai utilizar pra comunicar no caso a classe que é a interface irepositorio e criei uma memoria

        [HttpGet]//comando http

        public IActionResult Get()//metodo para buscar todos os produtos
        {
            try//tenta
            {


                return Ok(_produtoRepositorio.ObterTodos());//tem que retorna ok no caso todos os produtos
            }//ok siginifica 200 que foi tudo certinho
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());//se não der coloca uma exceção no caso mensagem se ele se perde

            }

        }

        [HttpPost]//comando para inserir

        public IActionResult Post([FromBody]Produto produto)
        {//frombody vai usar o corpo da requisção em um produto valido pra gente sem precisar escrever no que vai gerar
            try
            {
                _produtoRepositorio.Adicionar(produto);//tenta adicionar o produto
                return Created("api/controller", produto);//retorna o produto que criou pra ter certeza
            }
            catch(Exception ex)
            {

                return BadRequest(ex.ToString());//to string é pra não vim cagado a mnsg
            }


        }

    }
}
