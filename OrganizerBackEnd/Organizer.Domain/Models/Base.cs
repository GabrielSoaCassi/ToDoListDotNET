namespace Organizer.Domain.Models;

public abstract class Base
{
    public int Id { get; protected set; }
    DateTime CreatedDate { get; set; } = DateTime.Now;
    DateTime? ModifiedDate { get; set; }
    string CreatedBy { get; set; }
    string ModifiedBy { get; set; } 
}