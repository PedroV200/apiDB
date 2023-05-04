using Microsoft.AspNetCore.Mvc;

namespace apiDB.Controllers;

[ApiController]
[Route("[controller]")]
public class ExpressionsController : ControllerBase
{
    private IUnitOfWork _uWork;
    public ExpressionsController(IUnitOfWork myUWork)
    {
        _uWork=myUWork;
    }

    [HttpGet(Name = "GetExpressions")]
    //public async Task<IEnumerable<expression>> Get()
    public async Task<IEnumerable<expression>> Get()
    {
        var expresiones=await _uWork.expressions.getAll();
        return expresiones;
    }

    [HttpGet("{id}")]
    public async Task<expression>Get(int id)
    {
        var expresion=await _uWork.expressions.getById(id);
        return expresion;
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult>Delete(int id, expression exp)
    {
        if(id!=exp.expid)
        {
            return BadRequest();
        }
        var result=await _uWork.expressions.delete(exp);
        if(result==0)
        {
            return NotFound();
        }
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult>Post(expression exp)
    {

        var result=await _uWork.expressions.add(exp);
        if(result==0)
        {
            return NotFound();
        }
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult>Put(int id,expression exp)
    {
        if(id!=exp.expid)
        {
            return BadRequest();
        }

        var result=await _uWork.expressions.update(exp);
        if(result==0)
        {
            return NotFound();
        }
        return Ok(result);
    }

}
