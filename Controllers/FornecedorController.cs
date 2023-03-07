using Microsoft.AspNetCore.Mvc;
using Gestran.Models;
using Gestran.Data;
using Gestran.Repositories.Enderecos;
using Microsoft.EntityFrameworkCore;

namespace Gestran.Controllers
{
    [Route("v1/fornecedores")]
    public class FornecedorController: ControllerBase
    {
        private readonly IEnderecosRepository _enderecoRepository;

        public FornecedorController(IEnderecosRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fornecedor>>> Get
        (
            [FromQuery] string nome,
            [FromQuery] string cnpj,
            [FromQuery] string cidade,
            [FromServices]DataContext context
        )
        {
            try
            {
                var fornecedores = context.Fornecedores.Include(f => f.Enderecos)
                .Where(f =>
                    (string.IsNullOrEmpty(nome) || f.Nome.ToLower().Contains(nome.ToLower())) &&
                    (string.IsNullOrEmpty(cnpj) || f.CNPJ == cnpj) &&
                    (string.IsNullOrEmpty(cidade) || f.Enderecos.Any(e => e.Cidade.ToLower().Contains(cidade.ToLower())))
                ).ToList();
                return Ok(fornecedores);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Erro ao buscar fornecedores." });
            }

        }

        [Route("{id:int}")]
        [HttpGet]
        public async Task<ActionResult<List<Fornecedor>>> GetById
        (
            int id,
            [FromServices]DataContext context
        )
        {
            try
            {
                var fornecedores = await context
                    .Fornecedores
                    .Include(c => c.Enderecos)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(c => c.Id == id);

                if (fornecedores?.Id != id)
                {
                    return NotFound(new { message = "Fornecedor não encontrado" });
                }

                return Ok(fornecedores);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível encontrar o fornecedor." });
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<Fornecedor>> Put
        (
            int id, 
            [FromBody]Fornecedor model,
            [FromServices]DataContext context
        )
        {
            try
            {
                if (model.Id != id)
                    return NotFound(new { message = model.Id });

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var fornecedor = context.Fornecedores.Include(f => f.Enderecos).AsNoTracking().FirstOrDefault(f => f.Id == id);

                if (fornecedor == null)
                    return NotFound(new { message = "Não foi possível encontrar o fornecedor." });

                context.Entry<Fornecedor>(model).State = EntityState.Modified;                

                foreach (var endereco in model.Enderecos)
                {
                    var enderecoExistente = model.Enderecos.FirstOrDefault(e => e.Id == endereco.Id);

                    if (enderecoExistente != null)
                    {
                        _enderecoRepository.Update(endereco);
                    }
                }                

                await context.SaveChangesAsync();
                return Ok(model);

            } 
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest(new { message = "Este registro já foi atualizado" });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }


        [HttpPost]
        public async Task<ActionResult<Fornecedor>> Post
        (
            [FromBody]Fornecedor model,
            [FromServices]DataContext context
        )
        {
            try
            {                
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                
                context.Fornecedores.Add(model);
                await context.SaveChangesAsync();
                return Ok(model);
            }
            catch
            {
                return BadRequest(new { message = "Não foi possível criar fornecedor" });
            }
        }
    }
}


