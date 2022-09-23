namespace Domain.Entites;
public class Todo
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public int Status { get; set; }
}
public enum Status
{
    Todo,
    Inprogress,
    Complete
}