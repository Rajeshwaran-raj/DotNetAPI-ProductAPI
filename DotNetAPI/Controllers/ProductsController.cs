using Microsoft.AspNetCore.Mvc;
using ModelsData;

namespace Dotnet8MySqlCrud.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
        => Ok(DataExport.GetAll());

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var item = DataExport.GetById(id);
        return item is null ? NotFound() : Ok(item);
    }

    [HttpPost]
    public IActionResult Create(Product product)
    {
        var created = DataExport.Add(product);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id:int}")]
    public IActionResult Update(int id, Product product)
    {
        if (id != product.Id)
            return BadRequest("ID mismatch");

        return DataExport.Update(product)
            ? NoContent()
            : NotFound();
    }

    [HttpPatch("{id:int}/stock")]
    public IActionResult UpdateStock(int id, int value)
    {
        return DataExport.UpdateStock(id, value)
            ? Ok(DataExport.GetById(id))
            : NotFound();
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        return DataExport.Delete(id)
            ? NoContent()
            : NotFound();
    }
}
