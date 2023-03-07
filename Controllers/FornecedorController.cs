using Microsoft.AspNetCore.Mvc;
using Gestran.Models;

namespace Gestran.Controllers
{
    [Route("v1/fornecedores")]
    public class FornecedorController: ControllerBase
    {
        // private readonly IFornecedorService _fornecedorService;

        // public FornecedorController(IFornecedorService fornecedorService)
        // {
        //     _fornecedorService = fornecedorService;
        // }

        [Route("")]
        public string minhaFuncao()
        {
            return "Olá mundo!";    
        }

        [HttpPost]
        public async Task<ActionResult<Fornecedor>> Post
        (
            [FromBody] Fornecedor fornecedor
        )
        {
            try
            {                
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                
                //_context.Fornecedores.Add(fornecedor);
                //await _context.SaveChangesAsync();
                return Ok(fornecedor);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Não foi possível criar categoria" });
            }
        }

    //     [HttpPut("{id}")]
    //     public async Task<IActionResult> Editar(int id, Fornecedor fornecedor)
    //     {
    //         try
    //         {
    //             fornecedor.Id = id;
    //             var fornecedorAtualizado = await _fornecedorService.Editar(fornecedor);
    //             return Ok(fornecedorAtualizado);
    //         }
    //         catch (Exception ex)
    //         {
    //             return BadRequest(ex.Message);
    //         }
    //     }

    //     [HttpGet]
    //     public async Task<IActionResult> Listar([FromQuery] string nome, [FromQuery] string cnpj, [FromQuery] string cidade)
    //     {
    //         try
    //         {
    //             var fornecedores = await _fornecedorService.Listar(nome, cnpj, cidade);
    //             return Ok(fornecedores);
    //         }
    //         catch (Exception ex)
    //         {
    //             return BadRequest(ex.Message);
    //         }
    //     }

    //     [HttpGet("{id}")]
    //     public async Task<IActionResult> Obter(int id)
    //     {
    //         try
    //         {
    //             var fornecedor = await _fornecedorService.Obter(id);
    //             if (fornecedor == null)
    //                 return NotFound();
    //             return Ok(fornecedor);
    //         }
    //         catch (Exception ex)
    //         {
    //             return BadRequest(ex.Message);
    //         }
    //     }

    // }
    }
}


