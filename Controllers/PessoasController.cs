using CRUD.Model;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CRUD.Controllers
{
    public class PessoasController : Controller
    {
        private static List<PessoasModel> ListPessoas = new List<PessoasModel>
        {
            new PessoasModel{ id = 1, nome =" Daniel ", idade = 23, email = "danielmont@gmail.com" },
            new PessoasModel{ id = 2, nome =" Marcio ", idade = 32, email = "Marciopessoa@gmail.com" },
            new PessoasModel{ id = 3, nome =" Camila ", idade = 29, email = "Camilanasci@gmail.com" }
        };

        [HttpPost]
        [Route("api/Pessoas")]
        public IActionResult AdicionarPessoas([FromBody] PessoasModel PessoasNovas)
        {
            if (PessoasNovas == null)
            {
                return BadRequest();
            }
            PessoasNovas.id = ListPessoas.Count + 1;
            ListPessoas.Add(PessoasNovas);
            return Ok(PessoasNovas);

        }
        [HttpGet]
        [Route("api/Pessoas")]
        public IActionResult ListarTodosUsuarios()
        {
            return Ok(ListPessoas);
        }

        [HttpGet]
        [Route("api/Pessoas/{id}")]

        public IActionResult listarUsuariosId(int id)
        {
            var pessoa = ListPessoas.FirstOrDefault(p => p.id == id);   
            if (pessoa == null)
            {
                return NoContent();
            }
            return Ok(pessoa);
        }

        [HttpPut]
        [Route("api/Pessoas/{id}")]
        public IActionResult LstarTodosUsuarios(int id, [FromBody] PessoasModel AtualizacaoPessoas)
        {
            var usuarios = ListPessoas.FirstOrDefault(p => p.id == id);

            if (usuarios == null)
            {
                return BadRequest();
            }

            usuarios.nome = AtualizacaoPessoas.nome;
            usuarios.idade = AtualizacaoPessoas.idade;
            usuarios.email = AtualizacaoPessoas.email;

            return Ok();
        }

        [HttpDelete]
        [Route("api/pessoas/{id}")]

        public IActionResult ExcluirPessoa(int id)
        {
            var Pessoas = ListPessoas.FirstOrDefault(p =>p.id == id);
            if (Pessoas == null)
            {
                return NotFound();
            }
            ListPessoas.Remove(Pessoas);

            return NoContent();
        }




    }
            }
