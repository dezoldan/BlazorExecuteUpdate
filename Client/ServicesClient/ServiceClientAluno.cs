using BlazorApp1.Shared;
<<<<<<< HEAD
using System.Net.Http.Json;
=======
>>>>>>> 9af2f9ea61077024645110214d750cb5e70c607a
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace BlazorApp1.Client.ServicesClient
{
    public class ServiceClientAluno : IServiceClientAluno
    {
        private readonly HttpClient _httpClient;
        public ServiceClientAluno(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Vídeo #20. Recuperar uma lista de alunos.
        public async Task<IEnumerable<AlunosTeste>> GetAlunos1()
        {
            using HttpResponseMessage? httpResponse =
                await _httpClient.GetAsync($"v0/Aluno/metodo1");
            if (httpResponse.IsSuccessStatusCode)
            {
                var responseString = await httpResponse.Content.ReadAsStringAsync();
                var result = string.IsNullOrEmpty(responseString) ? null : JsonNode.Parse(responseString);
                IEnumerable<AlunosTeste>? alunosTestes = JsonSerializer.Deserialize<IEnumerable<AlunosTeste>>
                    (result, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true});
                if (alunosTestes !=  null)
                {
                    return alunosTestes.ToArray();
                }
                else
                {
                    return null!;
                }
            }
            return null!;   
        }
<<<<<<< HEAD

        // Vídeo #30. Refere-se a implementação no server do vídeo #15.
        public async Task PutAlunos1(AlunosTeste aluno)
        {
            await _httpClient.PutAsJsonAsync($"v0/Aluno/update30", aluno);
        }
    }
}
=======
    }
}
>>>>>>> 9af2f9ea61077024645110214d750cb5e70c607a
