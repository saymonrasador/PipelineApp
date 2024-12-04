# CI/CD Pipeline para Sistema Web com Banco de Dados

Este repositório contém a configuração de pipelines para um sistema com dois ambientes:
- `develop`: Atualização contínua em pushes e PRs.
- `main`: Atualização agendada às 21:00.

## Estrutura

1. **Ambientes**
   - Sites hospedados no Azure Static Web Apps.
   - Bancos de dados separados para cada branch (Supabase PostgreSQL).

2. **Configuração dos Workflows**
   - **`develop`**: Deploy e migração em cada PR ou push.
   - **`main`**: Deploy e migração diária às 21:00.

## Configuração

### Variáveis de Ambiente
Configure os secrets no GitHub:
- `DEVELOP_DB_URL`: URL do banco de dados `develop`.
- `MAIN_DB_URL`: URL do banco de dados `main`.
- `AZURE_STATIC_WEB_APPS_API_TOKEN_DEVELOP`: Token para o site `develop`.
- `AZURE_STATIC_WEB_APPS_API_TOKEN_MAIN`: Token para o site `main`.

### Deploy Manual
Para forçar o deploy:
```bash
git push origin develop
