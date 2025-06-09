# 🌱 SmartNature.API (.NET 7 + Razor Pages)

Este projeto é uma aplicação ASP.NET Core que permite o gerenciamento e monitoramento de sensores ambientais com leituras de temperatura, umidade e fumaça — incluindo alertas com base em severidade.

---

## 🎯 Funcionalidades

- ✅ Cadastro de sensores com Nome e Localização
- ✅ Listagem de sensores com visual moderno (Razor Pages + Bootstrap)
- ✅ Exclusão de sensores com botão funcional
- ✅ Seed de dados (Sensor + Leituras simuladas)
- ✅ Página de **Leituras** (tabela com dados por sensor)
- ✅ Página de **Alertas** com severidade (Baixa, Média, Alta)
- ✅ API RESTful com Swagger para:
  - Sensores (GET, POST, PUT, DELETE)
  - Leituras (GET, POST, DELETE)
  - Alerta (endpoint extra com lógica de severidade)
- ✅ Deploy automatizado via GitHub (repositório público)
- ✅ Bootstrap 5 aplicado nas páginas Razor (pasta `wwwroot`)

---

## 🗂️ Estrutura de Pastas

```
SmartNature.API/
├── Controllers/        # APIs REST de Sensor, Leitura, Alerta
├── Models/             # Entidades + DTOs (Sensor, Leitura)
├── Pages/
│   ├── Sensores/       # Razor Pages com TagHelpers (CRUD)
│   ├── Leituras/       # Histórico de leituras
│   └── Alertas/        # Página com severidade visual
├── wwwroot/            # CSS Bootstrap
├── Program.cs          # Configurações principais
├── SmartNature.API.csproj
```

---

## 🚀 Tecnologias Utilizadas

- ASP.NET Core 7.0
- Razor Pages + TagHelpers
- Entity Framework Core
- Oracle DB / LocalDB compatível
- Swagger UI
- Bootstrap 5.3 (via CDN e local)
- GitHub (deploy versionado)

---

## 🧠 Lógica de Alerta

A lógica de severidade na página de Alertas é baseada nos seguintes critérios:

| Severidade | Condições                           |
| ---------- | ----------------------------------- |
| **ALTA**   | Fumaça > 50 **OU** Temperatura > 40 |
| **MÉDIA**  | Fumaça > 25 **OU** Temperatura > 35 |
| **BAIXA**  | Qualquer outro valor                |

---

## 🧪 Instruções para Testes

O projeto pode ser testado facilmente via Swagger:

1. Execute o projeto (`dotnet run`)
2. Acesse [https://localhost:5001/swagger](https://localhost:5001/swagger)

### Exemplo de Requisição POST (Criar Leitura)

```json
POST /api/Leitura
Content-Type: application/json

{
  "temperatura": 37.5,
  "umidade": 28,
  "fumaca": 32,
  "dataHora": "2025-06-08T06:00:00",
  "sensorId": 1
}
```

### Exemplo de Requisição GET (Todas as Leituras)

```
GET /api/Leitura
```

### Exemplo de DELETE (Excluir Leitura)

```
DELETE /api/Leitura/4
```

### Exemplo de GET Alertas com Severidade

```
GET /api/Alerta
```

---

## ⚙️ Execução Local

Para rodar o projeto localmente:

```bash
# Restore dependências
dotnet restore

# Build
dotnet build

# Executar aplicação
dotnet run
```

Depois, acesse:

- Frontend: [https://localhost:5001/Sensores](https://localhost:5001/Sensores)
- Swagger: [https://localhost:5001/swagger](https://localhost:5001/swagger)

---

## 👨‍💻 Desenvolvedores

- Angello Turano - RM: 556511
- Cauã Sanches - RM: 558317
- Leonardo Bianchi - RM: 558576

Global Solution - FIAP 2025  
🔗 Repositório: [github.com/AngelloTDC/SmartNature.NET](https://github.com/AngelloTDC/SmartNature.NET)

🔗 Video Pitch: [https://www.youtube.com/watch?v=QJbUhtgRur4](https://www.youtube.com/watch?v=QJbUhtgRur4)

🔗 Video .NET: [https://www.youtube.com/watch?v=Q8nJ_H1wMAs](https://youtu.be/nAqNmpNykbQ)

🔗 Video 2 de .NET:

🔗 Video JAVA: [https://www.youtube.com/watch?v=Q8nJ_H1wMAs](https://www.youtube.com/watch?v=Q8nJ_H1wMAs)
