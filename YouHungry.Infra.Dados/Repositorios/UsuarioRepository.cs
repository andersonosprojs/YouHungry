using YouHungry.Dominio.Entidades;
using YouHungry.Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using YouHungry.Infra.Dados.Contexto;

namespace YouHungry.Infra.Dados.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _usuarioContext;

        public UsuarioRepository(AppDbContext context)
        {
            _usuarioContext = context;
        }

        public async Task<Usuario> CreateAsync(Usuario usuario)
        {
            _usuarioContext.Add(usuario);
            await _usuarioContext.SaveChangesAsync();

            return usuario;
        }

        public async Task<Usuario> GetByIdAsync(long? id)
        {
            return await _usuarioContext.Usuarios.FindAsync(id);
        }

        public async Task<IEnumerable<Usuario>> GetUsuariosAsync()
        {
            return await _usuarioContext.Usuarios.ToListAsync();
        }

        public async Task<Usuario> RemoveAsync(Usuario usuario)
        {
            _usuarioContext.Remove(usuario);
            await _usuarioContext.SaveChangesAsync();

            return usuario;
        }

        public async Task<Usuario> UpdateAsync(Usuario usuario)
        {
            _usuarioContext.Update(usuario);
            await _usuarioContext.SaveChangesAsync();

            return usuario;
        }
    }
}
