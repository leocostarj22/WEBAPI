using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Context;
using WebApi.Entities;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContatoController : ControllerBase
    {
        private readonly AgendaContext _context;
       
       //Este método serve para buscar um contato pelo ID
        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var contato = _context.Contatos.Find(id);
            if (contato == null)
            return NotFound();
            return Ok(contato);
        }
        public ContatoController(AgendaContext context)
        {
            _context = context;
        }
        
    //Este método serve para buscar um contato pelo Nome
        [HttpGet("ObterPorNome")]
        public IActionResult ObterNome(String nome)
        {
                var contatos = _context.Contatos.Where(x => x.Nome.Contains(nome));
                return Ok(contatos);
        }



        //Este método serve para Criar um Novo contato pelo ID
        [HttpPost]
        public IActionResult Create(Contato contato)
        {
            _context.Add(contato);
            _context.SaveChanges();
            return CreatedAtAction(nameof(ObterPorId), new { id = contato.Id }, contato);
        }

        //Este método serve para atualizar um contato pelo ID
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Contato contato)
        {
            var contatobanco = _context.Contatos.Find(id);
            
            if (contatobanco == null)
            return NotFound();
            
            contatobanco.Nome = contato.Nome;
            contatobanco.Telefone = contato.Telefone;
            contatobanco.Ativo = contato.Ativo;

            _context.Contatos.Update(contatobanco);
            _context.SaveChanges();

            return Ok(contatobanco);

        }

                //Este método serve para apagar um contato pelo ID
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var contatobanco = _context.Contatos.Find(id);
            
            if (contatobanco == null)
            return NotFound();
            
            _context.Contatos.Remove(contatobanco);
            _context.SaveChanges();

            return NoContent();

        }
    }
}