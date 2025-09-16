# Pixels
Este projeto implementa uma API em .NET que consome a API do Pexels, permitindo buscar fotos e vídeos de acordo com a palavra-chave informada. A arquitetura segue o padrão Clean Architecture.

# Como clonar o projeto
git clone https://github.com/msuttobr/pixels.git

# Configurando a API Key
Crie um arquivo chamado appsettings.Development.json dentro da API e inclua a API Key
da seguinte maneira

{
  "Pexels": {
    "ApiKey": "SUA_API_KEY_AQUI"
  }
}

# Rodando o projeto
cd src/Pixels.Api
dotnet run

# Acesse os endpoints
° Fotos: GET /api/photo/search?query=palavra
° Vídeos: GET /api/video/search?query=palavra

# Documentação
Acesse o Swagger em http://localhost:5221/swagger para testar os endpoints.