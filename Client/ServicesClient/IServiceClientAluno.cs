using BlazorApp1.Shared;

namespace BlazorApp1.Client.ServicesClient
{
    public interface IServiceClientAluno
    {
        Task<IEnumerable<AlunosTeste>> GetAlunos1();
        Task PostAlunos1(AlunosTeste aluno);
        Task PutAlunos1(AlunosTeste aluno);
    }
}
