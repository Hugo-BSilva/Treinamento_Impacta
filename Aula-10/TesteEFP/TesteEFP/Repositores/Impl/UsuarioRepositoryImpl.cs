using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteEFP.Models;

namespace TesteEFP.Repositores
{
    class UsuarioRepositoryImpl : UsuarioRepository
    {
        private TesteEFPDBContext _context;

        public UsuarioRepositoryImpl(TesteEFPDBContext context)
        {
            _context = context;
        }

        public Usuario SelecionarUsuarioID(int idUsuario)
        {
            // Retorna o primeiro usuário que encontrar com o ID passado por parâmetro
            return _context.Usuario.FirstOrDefault(usuario => usuario.Id == idUsuario);
        }
    }
}
