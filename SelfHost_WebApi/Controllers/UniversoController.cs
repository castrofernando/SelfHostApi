using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace SelfHost_WebApi.Controllers
{
    [Route("api/universo")]
    public class UniversoController : ApiController
    {
        private static List<Planeta> planetas = new List<Planeta>()
        {
            new Planeta { Id=1, Nome = "Mercúrio", Distancia = 0.39},
            new Planeta { Id=2, Nome = "Vênus", Distancia = 0.72 },
            new Planeta { Id=3, Nome = "Terra", Distancia = 1.00 },
            new Planeta { Id=4, Nome = "Marte", Distancia = 1.52 },
            new Planeta { Id=5, Nome = "Júpiter", Distancia = 5.20 },
            new Planeta { Id=6, Nome = "Saturno", Distancia = 9.53 },
            new Planeta { Id=7, Nome = "Urano", Distancia = 19.10 },
            new Planeta { Id=8, Nome = "Netuno", Distancia = 30.00 }
        };

        public IEnumerable<Planeta> Get()
        {
            Startup.command.Enqueue("Abrir porta");
            return planetas;
        }

        public Planeta Get(int id)
        {
            return planetas.Where(p => p.Id == id).FirstOrDefault();
        }
    }
}
