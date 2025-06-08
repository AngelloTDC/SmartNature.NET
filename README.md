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

| Severidade | Condições |
|------------|-----------|
| **ALTA**   | Fumaça > 50 **OU** Temperatura > 40 |
| **MÉDIA**  | Fumaça > 25 **OU** Temperatura > 35 |
| **BAIXA**  | Qualquer outro valor |

---

## 👨‍💻 Desenvolvedores

- Angello Turano - RM: 556511
- Cauã Sanches - RM:558317
- Leonardo Bianchi - RM:558576

- Projeto Global Solution - FIAP 2025
- Repositório: [github.com/AngelloTDC/SmartNature.NET](https://github.com/AngelloTDC/SmartNature.NET)

---
