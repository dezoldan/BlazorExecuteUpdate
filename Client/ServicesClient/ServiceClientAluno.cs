using BlazorApp1.Shared;
using System.Net.Http.Json;
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
        // Vídeo #30. Refere-se a implementação no server do vídeo #15.
        public async Task PutAlunos1(AlunosTeste aluno)
        {
            await _httpClient.PutAsJsonAsync($"v0/Aluno/update30", aluno);
        }

        // Vídeo #31.
        public async Task PostAluno1(AlunosTeste aluno)
        {
            await _httpClient.PostAsJsonAsync($"v0/Aluno/create1", aluno);
        }       
    }
}