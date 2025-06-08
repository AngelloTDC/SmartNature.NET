using Microsoft.AspNetCore.Mvc;
using SmartNature.API.Models;

namespace SmartNature.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlertaController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] AlertaRequest request)
        {
            string severidade;
            string mensagem;

            if (request.Fumaca >= 35 && request.Temperatura > 37 && request.Umidade < 25)
            {
                severidade = "ALTA";
                mensagem = "Alerta de queimada detectado com risco elevado";
            }
            else if (request.Fumaca >= 20 && request.Temperatura > 34)
            {
                severidade = "MÉDIA";
                mensagem = "Possível foco de calor com alerta moderado";
            }
            else
            {
                severidade = "BAIXA";
                mensagem = "Nenhum risco imediato identificado";
            }

            return Ok(new { severidade, mensagem });
        }
    }
}
