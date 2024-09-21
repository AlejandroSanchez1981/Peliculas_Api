using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Peliculas_Api.Entidades;

namespace Peliculas_Api.Controllers
{
    [Route("Api/Generos")]
    [ApiController]
    public class GenerosController: ControllerBase
    {
        //private readonly IRepositorio repositorio;
        private readonly IOutputCacheStore outputCacheStore;
        private readonly IConfiguration configuration;
        private readonly ApplicationDbContext context;
        private const string cacheTag = "generos";

        public GenerosController( IOutputCacheStore outputCacheStore, IConfiguration configuration, ApplicationDbContext context)
        {
            //this.repositorio = repositorio;:
            this.outputCacheStore = outputCacheStore;
            this.configuration = configuration;
            this.context = context;
        }


        [HttpGet]
        [OutputCache(Tags = [cacheTag])]
        public List<Genero> Get()
        {
            //var repositorio = new RepositorioEnMemoria();
            return new List<Genero>() { new Genero { Id =1, Nombre = "Comedia" },
                new Genero {Id= 2, Nombre="Accion" } };
                    
        }

        [HttpGet("{id:int}", Name = "ObtenerGeneroPorId")]
        [OutputCache(Tags = [cacheTag])]
        public async Task<ActionResult<Genero>> Get(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Genero genero)
        {

            context.Add(genero);

            await context.SaveChangesAsync();
            return CreatedAtRoute("ObtenerGeneroPorId", new { id = genero.Id }, genero);


        }

    }
}
