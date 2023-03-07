using Gestran.Data;
using Gestran.Models;

namespace Gestran.Repositories.Enderecos {
    public class EnderecosRepository : IEnderecosRepository
    {
        private readonly DataContext _context;

        public EnderecosRepository(DataContext context)
        {
            _context = context;
        }

        public void Update(Endereco endereco)
        {
            _context.Enderecos.Update(endereco);
            _context.SaveChanges();
        }
    }
}