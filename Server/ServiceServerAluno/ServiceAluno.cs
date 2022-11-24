using BlazorApp1.Server.Data;
using BlazorApp1.Shared;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;

namespace BlazorApp1.Server.ServiceServerAluno
{
    public class ServiceAluno : IServiceAluno
    {
        public ServiceAluno(DataContext dataContext)
        {
            DataContext = dataContext;
        }
        private readonly DataContext DataContext;

        // Vídeo #1.
        public async Task<IEnumerable<AlunosTeste>> GetMetodo1()
        {
            return await DataContext.TableTeste.FromSqlRaw("SELECT * FROM TblTeste").ToArrayAsync();
        }

        // Vídeo #1.
        public async Task<IEnumerable<AlunosTeste>> GetMetodo2()
        {
            return await DataContext.TableTeste.ToArrayAsync();
        }

        // Vídeo #1.
        public async Task<List<AlunosTeste>> GetMetodo3(string sobrenome)
        {
            var resultado = await DataContext.TableTeste.FromSqlRaw(
                "SELECT * FROM TblTeste WHERE Sobrenome LIKE @sobrenome + N'%'",
                new SqlParameter("@sobrenome", sobrenome)).ToListAsync();
            if (resultado.Count > 0)
                return resultado;
            else
            {
                return new List<AlunosTeste> { new AlunosTeste() };
            }
        }

        // Vídeo #2.
        public async Task<List<AlunosTeste>> GetMetodo4(string sobrenome1)
        {
            var sobrenome = new SqlParameter("sobrenome", sobrenome1 ?? string.Empty);
            if (DataContext.TableTeste != null)
            {
                return await DataContext.TableTeste.FromSqlRaw(
                    "EXECUTE uspSearchSobrenomes @sobrenome", sobrenome).ToListAsync();
            }
            else
            {
                return null!;
            }
        }

        // Vídeo #3.
        public async Task<List<AlunosTeste>> GetMetodo5(string sobrenome1)
        {
            if (DataContext.TableTeste != null)
            {
                return await DataContext.TableTeste.FromSqlRaw(
                    "EXECUTE uspSearchSobrenomes {0}", sobrenome1 ?? string.Empty).ToListAsync();
            }
            else
            {
                return null!;
            }
        }

        // Vídeo #3.
        public async Task<List<AlunosTeste>> GetMetodo6(string sobrenome1)
        {
            if (DataContext.TableTeste != null)
            {
                return await DataContext.TableTeste.Where(x => x.Sobrenome == sobrenome1).ToListAsync();
            }
            else
            {
                return null!;
            }
        }

        // Vídeo #4.
        // Listar registros com parâmetros, e após, filtrar.
        public async Task<List<AlunosTeste>> GetMetodo7(string sobrenome1)
        {
            if (DataContext.TableTeste != null)
            {
                return await DataContext.TableTeste.FromSqlRaw(
                    "SELECT * FROM TblTeste WHERE sobrenome = @sobrenome1",
                    new SqlParameter("@sobrenome1", sobrenome1))
                    .Where(x => x.Idade > 5).ToListAsync();
            }
            else
            {
                return null!;
            }
        }

        // Listar registros com parâmetros.
        // Usando FromSqlInterpolated ($).
        // Vídeo #5.
        public async Task<List<AlunosTeste>> GetMetodo8(string sobrenome1)
        {
            if (DataContext.TableTeste != null)
            {
                return await DataContext.TableTeste
                    .FromSqlInterpolated($"EXECUTE uspSearchSobrenomes {sobrenome1}")
                    .ToListAsync();
            }
            else
            {
                return null!;
            }
        }

        // Vídeo #6.
        // Listar registros com parâmetros, e filtrar.
        public async Task<List<AlunosTeste>> GetMetodo9(string sobrenome1, int Idade1)
        {
            return await DataContext.TableTeste.FromSqlRaw(
                "SELECT * FROM TblTeste WHERE sobrenome = @sobrenome1",
            new SqlParameter("@sobrenome1", sobrenome1))
            .Where(x => x.Idade.Equals(Idade1)).ToListAsync();
        }

        // Vídeo #7.
        // Listar registros com parâmetros, utilizando LINQ Query Syntax.
        public async Task<List<AlunosTeste>> GetMetodo10(string sobrenome1)
        {
            return await (from q1 in DataContext.TableTeste
                          where q1.Sobrenome == sobrenome1
                          select q1).ToListAsync();
        }

        // Vídeo #8.
        // Update1, atualizar registro.
        public async Task<string> Update1(int id, string newsobrenome)
        {
            var sobrenomes = await DataContext.TableTeste
                .Where(x => x.Id == id).FirstOrDefaultAsync();
            if (sobrenomes != null)
            {
                sobrenomes.Sobrenome = newsobrenome;
            }
            else
            {
                return $"Id [{id}] não encontrado. Tente novamente, por favor...";
            }
            DataContext.Entry(sobrenomes).State = EntityState.Modified;
            await DataContext.SaveChangesAsync();
            return $"O registro id [{id}] teve o sobrenome atualizado para: {sobrenomes.Sobrenome}";
        }

        // Vídeo #9.
        // Update2. Atualizar registros.
        public async Task<int> Update2(int id, string newsobrenome)
        {
            foreach (var item in DataContext.TableTeste)
            {
                if (item.Id == id)
                {
                    item.Sobrenome = newsobrenome;
                    break;
                }
            }
            await DataContext.SaveChangesAsync();
            return id;
        }

        // Vídeo #10.
        // Deletar registros.
        public async Task<string> Delete1(int id1)
        {
            foreach (var item in DataContext.TableTeste)
            {
                if (item.Id == id1)
                {
                    DataContext.Remove(item);
                    break;
                }
            }
            await DataContext.SaveChangesAsync();
            return $"O item {id1} foi removido com sucesso!";
        }

        // Vídeo #11.
        // Contar os registros da tabela.
        public async Task<int> Count1()
        {
            return await DataContext.TableTeste.CountAsync();
        }

        // Vídeo #12.
        // Contar os registros passando um parâmetro pela rota.
        public async Task<string> Count2(string sobrenome1)
        {
            int resultado = await DataContext.TableTeste
                .FromSqlRaw("SELECT * FROM TblTeste WHERE sobrenome = @sobrenome1",
                new SqlParameter("@sobrenome1", sobrenome1)).CountAsync();
            return $"A tabela tem {resultado} registros para o sobrenome {sobrenome1}";
        }

        // Vídeo #13.
        // Deletar registros. Vídeo anterior, #10.
        public async Task<int> Delete2(int id)
        {
            AlunosTeste ItemRemoveAlunos = new() { Id = id };
            if (ItemRemoveAlunos != null)
            {
                DataContext.Entry(ItemRemoveAlunos).State = EntityState.Deleted;
                await DataContext.SaveChangesAsync();
            }
            return id;
        }

        // Vídeo #14.
        // Passar um parametro e contar.
        public async Task<string> Count3(string sobrenome1, int idade1)
        {
            int resultado = await DataContext.TableTeste
                .FromSqlRaw("SELECT * FROM TblTeste WHERE sobrenome = @sobrenome1",
                new SqlParameter("@sobrenome1", sobrenome1)).
                Where(x => x.Idade > idade1).CountAsync();
            return $"Existem {resultado} registros para o sobrenome {sobrenome1} na tabela" +
                $" cuja idade é maior que {idade1}";
        }

        // Vídeo #15. Vídeos anteriores de updates são o vídeo #8 e o vídeo #9.
        public async Task Update3(AlunosTeste alunosTeste)
        {
            var result = await DataContext.TableTeste
                .Where(x => x.Id == alunosTeste.Id).AsNoTracking().FirstOrDefaultAsync();
            if (result != null)
            {
                DataContext.Entry(alunosTeste).State = EntityState.Modified;
                await DataContext.SaveChangesAsync();
            }            
            DataContext.Entry(alunosTeste).State = EntityState.Modified;
            await DataContext.SaveChangesAsync();
        }

        // Vídeo #16. API Rest.
        public async Task<AlunosTeste> UpdateAlunosById(int id1)
        {
            AlunosTeste? alunosTeste = await DataContext.TableTeste
                .FirstOrDefaultAsync(x => x.Id == id1);
            if (alunosTeste != null)
            {
                return alunosTeste;
            }
            else return null!;
        }

        // Vídeo #16. API Rest.
        public async Task<AlunosTeste> UpdateAlunos(AlunosTeste alunosTeste)
        {
            var result = await DataContext.TableTeste
                .FirstOrDefaultAsync(x => x.Id == alunosTeste.Id);
            if (result != null)
            {
                result.Nome = alunosTeste.Nome;
                result.Sobrenome = alunosTeste.Sobrenome;
                result.Idade = alunosTeste.Idade;
                await DataContext.SaveChangesAsync();
                return result;
            }
            else return null!;
        }

        // Vídeo #17.
        public async Task CreateAsync1(AlunosTeste alunosTeste)
        {
            DataContext.Entry(alunosTeste).State = EntityState.Added;
            await DataContext.SaveChangesAsync();
        }

        // Vídeo #18. Status201Created.
        public async Task CreateAsync2(AlunosTeste alunosTeste)
        {
            DataContext.Entry(alunosTeste).State = EntityState.Added;
            await DataContext.SaveChangesAsync();
        }

        // Vídeo #25, fromSql. v. 7.0 EfCore.
        public async Task<IEnumerable<AlunosTeste>> GetMetodo11()
        {
            return await DataContext.TableTeste
                .FromSql($"SELECT * FROM TblTeste").ToArrayAsync();
        }
        public async Task<IEnumerable<AlunosTeste>> GetMetodo12(string sobrenome)
        {
            return await DataContext.TableTeste
                .FromSql($"EXECUTE uspSearchSobrenomes {sobrenome}").ToArrayAsync();
        }

        public async Task<IEnumerable<AlunosTeste>> GetMetodo13(string sobrenome)
        {
            return await DataContext.TableTeste
                .FromSql($"SELECT * FROM TblTeste WHERE Sobrenome = {sobrenome}").ToArrayAsync();
        }

        // Vídeo #26. Compondo com o LINQ.
        public async Task<IEnumerable<AlunosTeste>> GetMetodo14(string sobrenome, int idade1)
        {
            return await DataContext.TableTeste
                .FromSql($"SELECT * FROM TblTeste WHERE Sobrenome({sobrenome})")
                .Where(x => x.Idade >= idade1)
                .OrderByDescending(x => x.Idade)
                .ToArrayAsync();
        }

        // Vídeo #27.
        public async Task<int[]> GetMetodo15()
        {
            return await DataContext.Database
                .SqlQuery<int>($"SELECT [Id] FROM TblTeste").ToArrayAsync();
        }

        // Vídeo #27.
        public async Task<IEnumerable<int>> GetMetodo16()
        {
            return await DataContext.Database
                .SqlQuery<int>($"SELECT [Idade] AS [Value] FROM TblTeste")
                .Where(idade => idade > DataContext.TableTeste.Average(x => x.Idade))
                .ToArrayAsync();
        }

        // Vídeo #28.
        public async Task<IEnumerable<AlunosTeste>> GetMetodo17(string sobrenome)
        {
            return await DataContext.TableTeste
                .FromSql($"EXECUTE uspSearchSobrenomes {sobrenome}").ToArrayAsync();
        }     
        
        // Vídeo #32.
        public async Task<int> Update4(int idade1, int id1)
        {
            AlunosTeste? alunosTeste = await DataContext
                .TableTeste.FirstOrDefaultAsync(x => x.Id == id1);
            if (alunosTeste != null)
            {
                return await DataContext.Database
                    .ExecuteSqlAsync($"EXECUTE uspAtualizaIdade {idade1},{id1}");
            }
            else return 0;
        }
    }
}