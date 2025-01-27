using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        // Endpoint para retornar a data e hora atual
        [HttpGet("ObterDataHoraAtual")]
        public IActionResult ObterDataHora()
        {
            // Obtém a data e hora atual do sistema
            var currentDateTime = new
            {
                Data = DateTime.Now.ToLongDateString(),
                Hora = DateTime.Now.ToShortDateString()
            };

            // Retorna a data e hora no formato ISO 8601 como resposta
            return Ok(currentDateTime);
        }
        [HttpGet("Apresentar/{nome}"),]
        public IActionResult Apresentar(string nome)
        {
            var mensagem = $"Olá, {nome}! Bem-vindo ao meu Web API.";
            return Ok(new { mensagem});
        }
    }
}