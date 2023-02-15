using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPi.Models;

namespace SuperHeroAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroController : ControllerBase
    {
        private static List<Hero> _heroes = new List<Hero>()
        {
            new Hero() { Id = 1, Name = "Tony Lark", Team = "Avengers", SuperHeroName = "Ironman" },
            new Hero() { Id = 2, Name = "Bruce Wayne", Team = "Justice League", SuperHeroName = "Batman" }
        };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_heroes);
        }

        [HttpGet("{Id}")]
        public IActionResult Get(int id)
        {
            return Ok(_heroes.FirstOrDefault(x => x.Id == id));
        }

        [HttpPost]
        public IActionResult Post(Hero hero)
        {
            _heroes.Add(hero);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(Hero hero)
        {
            var heroToUpdate = _heroes.FirstOrDefault(x => x.Id == hero.Id);
            if (heroToUpdate == null)
            {
                return NotFound();
            }
            heroToUpdate.Name = hero.Name;
            heroToUpdate.Team = hero.Team;
            heroToUpdate.SuperHeroName = hero.SuperHeroName;
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var heroToDelete = _heroes.FirstOrDefault(x => x.Id == id);
            if (heroToDelete == null)
            {
                return NotFound();
            }
            _heroes.Remove(heroToDelete);
            return Ok();
        }
    }
}
