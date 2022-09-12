using Microsoft.AspNetCore.Mvc;

namespace WebApplication1;

public class HelloController : ControllerBase
{
    [HttpGet("/api/hello")]
    public object Get() => new { Name = "David", Age = 35 };
}
