using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[Route("api/[controller]")]
[ApiController]
public class MahasiswaController : ControllerBase
{
    private static List<Mahasiswa> _mahasiswas = new List<Mahasiswa>
    {
        new Mahasiswa { Nama = "LeBron James", Nim = "1302000001" },
        new Mahasiswa { Nama = "Stephen Curry", Nim = "1302000002" }
    };

    [HttpGet]
    public ActionResult<IEnumerable<Mahasiswa>> Get()
    {
        return _mahasiswas;
    }

    [HttpGet("{index}")]
    public ActionResult<Mahasiswa> Get(int index)
    {
        if (index < 0 || index >= _mahasiswas.Count)
        {
            return NotFound();
        }
        return _mahasiswas[index];
    }

    [HttpPost]
    public ActionResult Post(Mahasiswa mahasiswa)
    {
        _mahasiswas.Add(mahasiswa);
        return Ok();
    }

    [HttpDelete("{index}")]
    public ActionResult Delete(int index)
    {
        if (index < 0 || index >= _mahasiswas.Count)
        {
            return NotFound();
        }
        _mahasiswas.RemoveAt(index);
        return Ok();
    }
}
