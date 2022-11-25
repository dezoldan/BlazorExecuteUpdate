using BlazorApp1.Server.ServiceServerAluno;
using BlazorApp1.Shared;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp1.Server.Controllers
{
    [ApiController]
    [Route("v0/[controller]")]
    public class AlunoController : ControllerBase
    {
        public AlunoController(IServiceAluno serviceAluno)
        {
            ServiceAluno = serviceAluno;
        }

        private readonly IServiceAluno ServiceAluno;

        //Vídeo #1.
        [HttpGet("metodo1")]
        public async Task<IEnumerable<AlunosTeste>> GetMetodo1()
        {
            return await ServiceAluno.GetMetodo1();
        }

        //Vídeo #1.
        [HttpGet("metodo2")]
        public async Task<IEnumerable<AlunosTeste>> GetMetodo2()
        {
            return await ServiceAluno.GetMetodo2();
        }

        // Vídeo #1.
        [HttpGet("metodo3/{sobrenome}")]
        public async Task<ActionResult<List<AlunosTeste>>> GetMetodo3([FromRoute] string sobrenome)
        {
            return await ServiceAluno.GetMetodo3(sobrenome);
        }

        // Vídeo #2.
        [HttpGet("metodo4/{sobrenome}")]
        public async Task<ActionResult<List<AlunosTeste>>> GetMetodo4([FromRoute] string sobrenome)
        {
            return await ServiceAluno.GetMetodo4(sobrenome);
        }

        // Vídeo #3.
        [HttpGet("metodo5/{sobrenome}")]
        public async Task<ActionResult<List<AlunosTeste>>> GetMetodo5([FromRoute] string sobrenome)
        {
            return await ServiceAluno.GetMetodo5(sobrenome);
        }

        // Vídeo #3.
        [HttpGet("metodo6/{sobrenome}")]
        public async Task<ActionResult<List<AlunosTeste>>> GetMetodo6([FromRoute] string sobrenome)
        {
            return await ServiceAluno.GetMetodo6(sobrenome);
        }

        // Vídeo #4.
        [HttpGet("metodo7/{sobrenome}")]
        public async Task<ActionResult<List<AlunosTeste>>> GetMetodo7([FromRoute] string sobrenome)
        {
            return await ServiceAluno.GetMetodo7(sobrenome);
        }

        // Vídeo #5.
        [HttpGet("metodo8/{sobrenome}")]
        public async Task<ActionResult<List<AlunosTeste>>> GetMetodo8([FromRoute] string sobrenome)
        {
            return await ServiceAluno.GetMetodo8(sobrenome);
        }

        // Vídeo #6.
        [HttpGet("metodo9/{sobrenome}/{idade:int}")]
        public async Task<ActionResult<List<AlunosTeste>>> GetMetodo9([FromRoute] string sobrenome, int idade)
        {
            return await ServiceAluno.GetMetodo9(sobrenome, idade);
        }

        // Vídeo #7.
        [HttpGet("metodo10/{sobrenome}")]
        public async Task<ActionResult<List<AlunosTeste>>> GetMetodo10([FromRoute] string sobrenome)
        {
            return await ServiceAluno.GetMetodo10(sobrenome);
        }

        // Vídeo #8.
        [HttpGet("metodo11/{id:int}/{newsobrenome}")]
        public async Task<ActionResult<string>> Update1([FromRoute] int id, string newsobrenome)
        {
            return await ServiceAluno.Update1(id, newsobrenome);
        }

        // Vídeo #9.
        [HttpGet("update2/{id:int}/{newsobrenome}")]
        public async Task<ActionResult<int>> Update2([FromRoute] int id, string newsobrenome)
        {
            return await ServiceAluno.Update2(id, newsobrenome);
        }

        // Vídeo #10.
        [HttpDelete("delete1/{id:int}")]
        public async Task<ActionResult<string>> Delete1([FromRoute] int id)
        {
            return await ServiceAluno.Delete1(id);
        }

        // Vídeo #11.
        [HttpGet("contar1")]
        public async Task<ActionResult<int>> Count1()
        {
            return await ServiceAluno.Count1();
        }

        // Vídeo #12.
        [HttpGet("contar2/{sobrenome}")]
        public async Task<ActionResult<string>> Count2([FromRoute] string sobrenome)
        {
            return await ServiceAluno.Count2(sobrenome);
        }

        // Vídeo #13.
        [HttpDelete("delete2/{id}")]
        public async Task<ActionResult<int>> Delete2([FromRoute] int id)
        {
            return await ServiceAluno.Delete2(id);
        }

        // Vídeo #14.
        [HttpGet("contar3/{sobrenome}/{idade}")]
        public async Task<ActionResult<string>> Count3([FromRoute] string sobrenome, int idade)
        {
            return await ServiceAluno.Count3(sobrenome, idade);
        }

        // Vídeo #15.
        [HttpPut("update3")]
        public async Task<IEnumerable<AlunosTeste>> Update3([FromBody] AlunosTeste alunosTeste)
        {
            await ServiceAluno.Update3(alunosTeste);
            return await ServiceAluno.GetMetodo1();
        }

        // Vídeo #30.
        [HttpPut("update30")]
        public async Task Update30([FromBody] AlunosTeste aluno)
        {
            await ServiceAluno.Update3(aluno);
        }

        // Vídeo #16. API Rest.
        [HttpPut("{id:int}")]
        public async Task<ActionResult<AlunosTeste>> UpdateAlunos(
            [FromRoute] int id, [FromBody] AlunosTeste alunosTeste)
        {
            try
            {
                if (id != alunosTeste.Id)
                {
                    return BadRequest($"O id {id} informado não existe.");
                }
                var alunoUpdate = await ServiceAluno.UpdateAlunosById(alunosTeste.Id);
                if (alunosTeste == null)
                {
                    return NotFound($"{alunosTeste!.Id} não encontrado");
                }
                return await ServiceAluno.UpdateAlunos(alunosTeste);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Houve um erro na atualização dos dados.");
            }
        }

        // Vídeo #17 e #31.
        [HttpPost("create1")]
        public async Task<IEnumerable<AlunosTeste>> CreateAluno([FromBody] AlunosTeste alunosTeste)
        {
            await ServiceAluno.CreateAsync1(alunosTeste);
            return await ServiceAluno.GetMetodo1();
        }

        // Vídeo #18.
        [HttpPost("create2")]
        public async Task<IActionResult> CreateAsync2([FromBody] AlunosTeste alunosTeste)
        {
            await ServiceAluno.CreateAsync2(alunosTeste);
            return StatusCode(StatusCodes.Status201Created, alunosTeste);
        }

        // Vídeo #25.
        [HttpGet("metodo11")]
        public async Task<IEnumerable<AlunosTeste>> GetMetodo11()
        {
            return await ServiceAluno.GetMetodo11();
        }

        // Vídeo #25.
        [HttpGet("metodo12/{sobrenome}")]
        public async Task<IEnumerable<AlunosTeste>> GetMetodo12([FromRoute] string sobrenome)
        {
            return await ServiceAluno.GetMetodo12(sobrenome);
        }

        // Vídeo #25.
        [HttpGet("metodo13/{sobrenome}")]
        public async Task<IEnumerable<AlunosTeste>> GetMetodo13([FromRoute] string sobrenome)
        {
            return await ServiceAluno.GetMetodo13(sobrenome);
        }

        // Vídeo #26.
        [HttpGet("metodo14/{sobrenome}/{idade}")]
        public async Task<IEnumerable<AlunosTeste>> GetMetodo14([FromRoute] string sobrenome, int idade)
        {
            return await ServiceAluno.GetMetodo14(sobrenome, idade);
        }

        // Vídeo #27.
        [HttpGet("metodo15")]
        public async Task<ActionResult<int[]>> GetMetodo15()
        {
            return await ServiceAluno.GetMetodo15();
        }

        // Vídeo #27.
        [HttpGet("metodo16")]
        public async Task<IEnumerable<int>> GetMetodo16()
        {
            return await ServiceAluno.GetMetodo16();
        }

        // Vídeo #28.
        [HttpGet("metodo17/{sobrenome}")]
        public async Task<IEnumerable<AlunosTeste>> GetMetodo17([FromRoute] string sobrenome)
        {
            return await ServiceAluno.GetMetodo17(sobrenome);
        }

        // Vídeo #32.
        [HttpGet("atualizaidade/{idade1}/{id1}")]
        public async Task<ActionResult<int>> Update4([FromRoute] int idade1, int id1)
        {
            await ServiceAluno.Update4(idade1, id1);
            return id1;
        }

        // Vídeo #33. Outros vídeos sobre DELETE, vídeo #10 e vídeo #13.
        [HttpDelete("delete3/{id1:int}")]
        public async Task Delete3([FromRoute] int id1)
        {
            await ServiceAluno.DeleteAsync3(id1);
        }

        // Vídeo #34. Outros vídeos sobre UPDATE, vídeos #08, #09, #15, #16 e #32.
        [HttpPut("update6/{id1:int}/{sobrenome}")]
        public async Task Update6([FromRoute] int id1, string sobrenome)
        {
            await ServiceAluno.UpdateAsync6(id1, sobrenome);
        }
    }
}