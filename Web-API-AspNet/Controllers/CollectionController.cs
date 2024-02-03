using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Web_API_AspNet.Entity;
using Web_API_AspNet.Services;

namespace Web_API_AspNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionController : ControllerBase
    {
        public CollectionController(CollectionService collectionService)
        {
            _collectionService = collectionService;
        }

        //Lista de Serviços
        private readonly CollectionService _collectionService;


        [HttpGet("{dataset}/{collection}")]
        public IEnumerable<string> Get(string dataset, string collection)
        {
            return new string[] { dataset, collection };
        }

        // GET api/<CollectionController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // Criação de um uma coleção apartir de um dataset, caso não exista, crie um dataset.
        [HttpPost("{dataset}/{collection}/{nameCollection}")]
        public void Post(string dataset, string collection, string nameCollection, [FromBody] Data entity)
        {
            Collection NewCollection = new Collection();
            NewCollection.NameCollection = nameCollection;
            NewCollection.Id = collection;

            _collectionService.CreateCollection(dataset, NewCollection, entity);
        }

        // PUT api/<CollectionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CollectionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
