using ContosoPizza.Models;
using ContosoPizza.Data;

namespace ContosoPizza.Services
{
    public class PastaService

    {
        private readonly PizzaContext _context = default!;
        public PastaService(PizzaContext context)
        {
            _context = context;
        }

        public void AddPasta(Pasta pasta)
        {
            if (_context.Pastas != null)
            {
                _context.Pastas.Add(pasta);
                _context.SaveChanges();
            }
        }
        public IList<Pasta> GetPastas()
        {
            if (_context.Pastas != null)
            {
                return _context.Pastas.ToList();
            }
            return new List<Pasta>();
        }
        public void DeletePasta(int id)
        {
            if (_context.Pastas != null)
            {
                var pasta = _context.Pastas.Find(id);
                if (pasta != null)
                {
                    _context.Pastas.Remove(pasta);
                    _context.SaveChanges();
                }
            }
        }
    }
}