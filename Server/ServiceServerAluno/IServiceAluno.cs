using BlazorApp1.Shared;

namespace BlazorApp1.Server.ServiceServerAluno
{
    public interface IServiceAluno
    {
        Task<int> Count1();
        Task<string> Count2(string sobrenome1);
        Task<string> Count3(string sobrenome1, int idade1);
        Task CreateAsync1(AlunosTeste alunosTeste);
        Task CreateAsync2(AlunosTeste alunosTeste);
        Task<string> Delete1(int id1);
        Task<int> Delete2(int id);
        Task<IEnumerable<AlunosTeste>> GetMetodo1();
        Task<List<AlunosTeste>> GetMetodo10(string sobrenome1);
        Task<IEnumerable<AlunosTeste>> GetMetodo11();
        Task<IEnumerable<AlunosTeste>> GetMetodo12(string sobrenome);
        Task<IEnumerable<AlunosTeste>> GetMetodo13(string sobrenome);
        Task<IEnumerable<AlunosTeste>> GetMetodo14(string sobrenome, int idade1);
        Task<int[]> GetMetodo15();
        Task<IEnumerable<int>> GetMetodo16();
        Task<IEnumerable<AlunosTeste>> GetMetodo17(string sobrenome);
        Task<IEnumerable<AlunosTeste>> GetMetodo2();
        Task<List<AlunosTeste>> GetMetodo3(string sobrenome);
        Task<List<AlunosTeste>> GetMetodo4(string sobrenome1);
        Task<List<AlunosTeste>> GetMetodo5(string sobrenome1);
        Task<List<AlunosTeste>> GetMetodo6(string sobrenome1);
        Task<List<AlunosTeste>> GetMetodo7(string sobrenome1);
        Task<List<AlunosTeste>> GetMetodo8(string sobrenome1);
        Task<List<AlunosTeste>> GetMetodo9(string sobrenome1, int Idade1);
        Task<string> Update1(int id, string newsobrenome);
        Task<int> Update2(int id, string newsobrenome);
        Task Update3(AlunosTeste alunosTeste);
        Task<int> Update4(int idade1, int id1);
        Task<AlunosTeste> UpdateAlunos(AlunosTeste alunosTeste);
        Task<AlunosTeste> UpdateAlunosById(int id1);
    }
}
