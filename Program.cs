using one_do.Domain;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/health", () => new { status = "ok" });

app.MapGet("/health/ready", () => new { status = "ok" });

List<TaskItem> listTask = new List<TaskItem>();

listTask.Add(new TaskItem { Id = Guid.NewGuid(), Title = "Criar endpoints de health para novo projeto", Done = false, CreatedAt = DateTime.UtcNow });

listTask.Add(new TaskItem { Id = Guid.NewGuid(), Title = "Criar pasta domain com classe para tarefas", Done = false, CreatedAt = DateTime.UtcNow });

app.MapGet("/tasks", () => listTask);

app.Run();
