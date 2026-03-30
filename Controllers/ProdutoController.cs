using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; 


namespace TrabalhoApi;
[ApiController]
[Route("api/[controller]")]
public class ProdutosController : ControllerBase{
    private readonly AppDbContext _context;

    public ProdutosController(AppDbContext context){
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Produto>>> GetAllAsync(){
        var produtos = await _context.Produtos.AsNoTracking().ToListAsync();
        return Ok(produtos);
    }

    [HttpGet("{id:int}", Name = "GetProdByID")]
    public async Task<ActionResult<Produto>> GetByIdAsync(int id)
    {
        var produto = await _context.Produtos.FindAsync(id);

        if (produto is null)
            return NotFound();

        return Ok(produto);
    }

    [HttpPost]
    public async Task<ActionResult<Produto>> CreateAsync(Produto produto){
        _context.Produtos.Add(produto);
        await _context.SaveChangesAsync();

        return CreatedAtRoute("GetProdByID", new {id = produto.Id}, produto);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateAsync(int id, Produto produto)
    {
        if (id != produto.Id)
            return BadRequest("Id do corpo diferente do parâmetro");

        var existente = await _context.Produtos.FindAsync(id);

        if (existente is null)
            return NotFound();

        existente.Nome = produto.Nome;
        existente.Preco = produto.Preco;
        existente.Estoque = produto.Estoque;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteAsync(int id){
        var Produto = await _context.Produtos.FindAsync(id);
        if(Produto is null) return NotFound();

        _context.Produtos.Remove(Produto);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}