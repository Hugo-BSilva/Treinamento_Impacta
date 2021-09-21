using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteEFP.Models;

namespace TesteEFP.Repositores
{
    interface UsuarioRepository
    {
        Usuario SelecionarUsuarioID(int idUsuario);
    }
}
