using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; 


namespace TrabalhoApi;
[ApiController]
[Route("api/[controller]")]
public class CategoriaController : ControllerBase{
    private readonly AppDbContext _context;

    public CategoriaController(AppDbContext context){
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Categoria>>> GetAllAsync(){
        var categorias = await _context.Categorias.AsNoTracking().ToListAsync();
        return Ok(categorias);
    }

    [HttpGet("{id:int}", Name = "GetCategoriaByID")]
    public async Task<ActionResult<Categoria>> GetByIdAsync(int id)
    {
        var categoria = await _context.Categorias.FindAsync(id);

        if (categoria is null)
            return NotFound();

        return Ok(categoria);
    }

    [HttpPost]
    public async Task<ActionResult<Categoria>> CreateAsync(Categoria categoria){
        _context.Categorias.Add(categoria);
        await _context.SaveChangesAsync();

        return CreatedAtRoute("GetCategoriaByID", new {id = categoria.Id}, categoria);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateAsync(int id, Categoria categoria)
    {
        if (id != categoria.Id)
            return BadRequest("Id do corpo diferente do parâmetro");

        var existente = await _context.Categorias.FindAsync(id);

        if (existente is null)
            return NotFound();

        existente.Nome = categoria.Nome;
        existente.Descricao = categoria.Descricao;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteAsync(int id){
        var Categoria = await _context.Categorias.FindAsync(id);
        if(Categoria is null) return NotFound();

        _context.Categorias .Remove(Categoria);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}