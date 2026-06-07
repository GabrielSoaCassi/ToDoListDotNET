namespace Organizer.Domain.Models;

public abstract class Base
{
    public int Id { get; protected set; }
    public DateTime CreatedDate { get; protected set; } = DateTime.Now;
    public DateTime? ModifiedDate { get; set; }
    public string? CreatedBy { get; set; }
    public string? ModifiedBy { get; set; }
}