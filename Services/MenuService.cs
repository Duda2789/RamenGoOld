using RamenGoApi2.Models;

namespace RamenGoApi2.Services
{
    public class MenuService
    {
        public IEnumerable<Broth> GetBroths()
        {
            return new List<Broth>
        {
            new Broth { Id = 1, Name = "Shoyu" },
            new Broth { Id = 2, Name = "Miso" }
        };
        }

        public IEnumerable<Protein> GetProteins()
        {
            return new List<Protein>
        {
            new Protein { Id = 1, Name = "Chicken" },
            new Protein { Id = 2, Name = "Pork" }
        };
        }
    }
