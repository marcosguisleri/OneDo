using one_do.Domain;
using one_do.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/health", () => new { status = "ok" });

app.MapGet("/health/ready", () => new { status = "ok" });

List<TaskItem> listTask = new List<TaskItem>();

listTask.Add(new TaskItem { Id = Guid.NewGuid(), Title = "Criar endpoints de health para novo projeto", Done = false, CreatedAt = DateTime.UtcNow });

listTask.Add(new TaskItem { Id = Guid.NewGuid(), Title = "Criar pasta domain com classe para tarefas", Done = false, CreatedAt = DateTime.UtcNow });

app.MapGet("/tasks", () => listTask);

app.MapPost("/tasks", (CreateTaskRequest request) =>
{
  var title = request.Title?.Trim();

  if(string.IsNullOrWhiteSpace(title))
  {
    return Results.BadRequest(new { error = "O título é obrigatório!" });
  }

  if(title.Length < 3 || title.Length > 80)
  {
    return Results.BadRequest(new { error = "Número de caracteres inválido!" });
  }

  var task = new TaskItem
  {
    Id = Guid.NewGuid(),
    Title = title,
    Done = false,
    CreatedAt = DateTime.UtcNow
  };

  listTask.Add(task);

  return Results.Created($"/tasks/`{task.Id}", task);
  
});

app.Run();
