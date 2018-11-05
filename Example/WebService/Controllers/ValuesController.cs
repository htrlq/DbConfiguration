using DbConfiguration;
using Microsoft.AspNetCore.Mvc;

namespace WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IDbOptions<PayConfigure> Options { get; }

        public ValuesController(IDbOptions<PayConfigure> options)
        {
            Options = options;
        }

        public PayConfigure Get()
        {
            return Options.Value;
        }
    }
}
