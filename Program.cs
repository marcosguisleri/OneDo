using one_do.Domain;
using one_do.Dtos;
using System.Linq;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/health", () => new { status = "ok" });

app.MapGet("/health/ready", () => new { status = "ok" });

List<TaskItem> listTask = new List<TaskItem>();

listTask.Add(new TaskItem { Id = Guid.NewGuid(), Title = "Criar endpoints de health para novo projeto", Done = false, CreatedAt = DateTime.UtcNow });

listTask.Add(new TaskItem { Id = Guid.NewGuid(), Title = "Criar pasta domain com classe para tarefas", Done = false, CreatedAt = DateTime.UtcNow });

app.MapGet("/tasks", () => listTask);

app.MapGet("/tasks/{id}", (Guid id) =>
{
    var task = listTask.FirstOrDefault(t => t.Id == id);

    if(task == null)
      return Results.NotFound(new { error = "Tarefa não encontrada!" });
    
    return Results.Ok(task);

});

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

  return Results.Created($"/tasks/{task.Id}", task);
  
});

app.MapPatch("/tasks/{id}/toggle", (Guid id) =>
{
  var task = listTask.FirstOrDefault(t => t.Id == id);

  if(task == null)
    return Results.NotFound(new { error = "Tarefa não encontrada!" });
  
  task.Done = !task.Done;

  return Results.Ok(task);
});

app.MapPatch("/tasks/{id}", (Guid id, UpdateTaskRequest request) =>
{

  var task = listTask.FirstOrDefault(t => t.Id == id);

  if(task == null)
    return Results.NotFound(new { error = "Tarefa não encontrada!" });

  var title = request.Title?.Trim();

  if(string.IsNullOrWhiteSpace(title))
  {
    return Results.BadRequest(new { error = "O título é obrigatório!" });
  }

  if(title.Length < 3 || title.Length > 80)
  {
    return Results.BadRequest(new { error = "Número de caracteres inválido!" });
  }

  task.Title = title;

  return Results.Ok(task);
  
});

app.MapDelete("/tasks/{id}", (Guid id) =>
{
  var task = listTask.FirstOrDefault(t => t.Id == id);

  if(task == null)
    return Results.NotFound(new { error = "Tarefa não encontrada!" });

  listTask.Remove(task);

  return Results.NoContent();

});

app.Run();
