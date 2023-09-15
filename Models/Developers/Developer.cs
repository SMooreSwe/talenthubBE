using System.ComponentModel.DataAnnotations.Schema;
using talenthubBE.Models;

public class Developer
{
    [Column("id")]
    public Guid Id {get; set;}
    [Column("name")]
    public String? Name {get; set;}
    [Column("email")]
    public String? Email {get; set;}
    [Column("created_at")]
    public DateTime CreatedAt {get; set;}
    public ICollection<Skill> Skills { get; } = new List<Skill>();
    public ICollection<User> Users { get; } = new List<User>();

}

