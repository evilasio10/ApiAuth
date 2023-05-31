using ApiAuth.Model;

namespace ApiAuth.Repositories
{
    public static class UserRepository
    {
        public static UserModel Get(string usuario, string password)
        {
            var usuarios = new List<UserModel>
            {
                new UserModel{Id=1, UserName="carlos", Password="bahia", Role="Adm" },
                new UserModel{Id=2, UserName="joao", Password="vitoria", Role="atendimento" }
            };
            return usuarios.Where(p => p.UserName == usuario && p.Password == password).FirstOrDefault();
        }
    }
}
