
namespace Notes.Domain;

public class Note
{
    public Guid UserId { get; set; }
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public string? Details { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime? UpdateDate { get; set; }
}