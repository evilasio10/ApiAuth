using ApiAuth.Model;

namespace ApiAuth.Repositories
{
    public class UserRepository
    {
        AppDbContext _db = new AppDbContext();
        public Usuario Get(string usuario, string password)
        {
            var data = _db.Usuario.Where(p => p.UserName == usuario && p.Password == password).FirstOrDefault();
            return data;
        }

        public List<Usuario> GetList()
        {
            var data = _db.Usuario.ToList();
            foreach (var item in data)
            {
                item.Password = string.Empty;
            }
            return data;
        }
        public Usuario Add(Usuario usuario)
        {
            _db.Usuario.Add(usuario);
            _db.SaveChanges();            
            return usuario;
        }
    }
}
