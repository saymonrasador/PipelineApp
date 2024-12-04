# **CI/CD Pipeline para Sistema Web com Banco de Dados**

Este repositório contém a configuração de pipelines para um sistema web simples com dois ambientes distintos, integrados com bancos de dados e deploy automatizado. 

O foco principal deste projeto é demonstrar a implementação de **CI/CD** para diferentes branches (`main` e `develop`) com migrações de banco de dados e sites hospedados no Azure Static Web Apps.

---

## **Estrutura do Projeto**

### **1. Pastas Principais**

- **`src/PipelineApp`**: Contém o código-fonte principal do sistema. 
  - **`web/index.html`**: Arquivo estático de demonstração.
  - **`PipelineApp.csproj`**: Arquivo de configuração do projeto .NET.
  - **`Program.cs`**: Código base para executar a aplicação.
  - **`appsettings.json`**: Configurações do sistema, incluindo as strings de conexão dos bancos de dados.

- **`.github/workflows`**: Configurações de workflows do GitHub Actions.
  - **`azure-static-web-apps-delightful-wave-07af55c10.yml`**: Configura o deploy automatizado para o Azure Static Web Apps.
  - **`main.yaml`**: Configura a pipeline principal de CI/CD com suporte para múltiplos ambientes (`main` e `develop`).

---

### **2. Bancos de Dados**
- Dois bancos de dados PostgreSQL hospedados no **Supabase**:
  - **Banco `develop`:** Usado para o ambiente de desenvolvimento (branch `develop`).
  - **Banco `main`:** Usado para o ambiente de produção (branch `main`).

Os bancos de dados possuem controle de migração usando o **Entity Framework Core**.

---

### **3. Configuração de CI/CD**

- **Branch `develop`:**
  - Atualização contínua a cada **push** ou **pull request**.
  - Deploy do site no Azure Static Web Apps.
  - Aplicação das migrações de banco de dados no banco de desenvolvimento.

- **Branch `main`:**
  - Atualização agendada para **21:00 todos os dias**.
  - Deploy do site no Azure Static Web Apps.
  - Aplicação das migrações no banco de produção.

Os workflows do GitHub Actions gerenciam esses processos automaticamente.

---

## **Configuração**

### **Variáveis de Ambiente**
Certifique-se de configurar as variáveis de ambiente como secrets no GitHub:
- **Conexão com bancos de dados:**
  - `DEVELOP_DB_URL`: String de conexão para o banco de desenvolvimento.
  - `MAIN_DB_URL`: String de conexão para o banco de produção.
- **Tokens do Azure Static Web Apps:**
  - `AZURE_STATIC_WEB_APPS_API_TOKEN_DEVELOP`: Token para o site do ambiente `develop`.
  - `AZURE_STATIC_WEB_APPS_API_TOKEN_MAIN`: Token para o site do ambiente `main`.

---

### **Workflows do GitHub Actions**
#### Arquivo: `.github/workflows/azure-static-web-apps-delightful-wave-07af55c10.yml`
- **Ativado por:**
  - Push para a branch `main`.
  - Pull requests na branch `main`.
- **O que faz:**
  - Realiza o deploy do site estático no Azure Static Web Apps.

#### Arquivo: `.github/workflows/main.yaml`
- **Ativado por:**
  - Push ou PR na branch `develop`.
  - Atualização agendada para a branch `main` às 21:00.
- **O que faz:**
  - Realiza o deploy do site.
  - Executa as migrações do banco de dados com base no ambiente.

---

### **Banco de Dados**
#### Estrutura e Migração:
- A migração de banco de dados é gerenciada pelo **Entity Framework Core**.
- As migrações aplicadas são registradas na tabela interna `__EFMigrationsHistory`.

#### Comandos Úteis:
1. **Criar uma nova migração:**
   ```bash
   dotnet ef migrations add NomeDaMigracao --project src/PipelineApp
2. **Aplicar migrações:**
   ```bash
   dotnet ef database update --project src/PipelineApp

---

#### Dependências:
Caso queira forçar o deploy manualmente, faça um push para a branch correspondente:
```bash
   git push origin develop


### **Banco de Dados**
1. **Frameworks e Pacotes:**
- .NET 8.0
- Entity Framework Core 8.0.2
- Npgsql para PostgreSQL
2. **Ferramentas de CI/CD:**
- GitHub Actions
- Azure Static Web Apps
- Supabase PostgreSQL


### **Execução do Projeto**
1. **Restaure as dependências:**
   ```bash
   dotnet restore src/PipelineApp/PipelineApp.csproj
2. **Compile o projeto:**
   ```bash
   dotnet build src/PipelineApp/PipelineApp.csproj
3. **Execute a aplicação:**
   ```bash
   dotnet run --project src/PipelineApp/PipelineApp.csproj


No Azure o deploy será realizado automaticamente com base nos workflows configurados.
