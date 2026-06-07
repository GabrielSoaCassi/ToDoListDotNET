namespace Organizer.Domain.Models;

public abstract class Base
{
    public int Id { get; protected set; }
    private DateTime CreatedDate { get; set; } = DateTime.Now;
    private DateTime? ModifiedDate { get; set; }
    private string CreatedBy { get; set; }
    private string ModifiedBy { get; set; }
}