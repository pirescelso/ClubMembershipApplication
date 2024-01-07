Learning C#

criar uma aplicação "console" especificando a versão do framework

```bash
dotnet new console -f "net7.0"
```

de dentro da pasta executar o programa com dotnet run
```bash
@pirescelso ➜ /workspaces/c-sharp/MyConsoleApp (main) $ dotnet run
```

Comandos para instalar e atualizar a ferramenta de migração
dotnet tool install --global dotnet-ef --version 7.0.14
dotnet tool update --global dotnet-ef --version 7.0.14

Criar migração
dotnet ef migrations add FirstCreate

Alterar o banco de dados (aplicar a migração)
dotnet ef database update
