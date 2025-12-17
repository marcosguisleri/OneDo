# OneDo ✅

**OneDo** é um gerenciador de tarefas simples e moderno, criado para praticar **Fullstack** do zero.  
Este repositório contém a **API em C# (.NET Minimal API)** com endpoints REST e validações.

> Status: **em desenvolvimento** 🚧

---

## 🎯 Objetivo
Consolidar conceitos de:

- API REST (endpoints, métodos HTTP, status codes)
- Organização de código (Domain, DTOs)
- Validação de entrada
- Evolução de persistência (memória → banco)
- (em breve) Front-end com UI caprichada

---

## 🧱 Stack

- **C# / .NET (Minimal API)**
- Testes com **Thunder Client**
- Persistência: **em memória** (por enquanto)

---

## 🚀 Como rodar

Pré-requisito: **.NET SDK** instalado.

```bash
dotnet run
```

A API vai subir em algo como:

- `http://localhost:PORTA`

---

## ✅ Endpoints

### Health
- `GET /health`
- `GET /health/ready`

### Tasks
- `GET /tasks`
- `POST /tasks`

---

### Exemplo de body (POST /tasks)

```json
{
  "title": "Criar primeira mini API em C#"
}
```
## 🗺️ Roadmap
- [ ] `PATCH /tasks/{id}/toggle` (concluir/desfazer)
- [ ] `DELETE /tasks/{id}` (excluir)
- [ ] Persistência com banco (SQLite/Postgres)
- [ ] Front-end (React) com UI bem trabalhada
- [ ] Deploy

## 👨‍💻 Autor
**Marcos Guisleri**

