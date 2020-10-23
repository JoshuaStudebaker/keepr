using System.ComponentModel.DataAnnotations;

namespace Keepr.Models
{
  public class Keep
  {
    public int Id { get; set; }
    public string CreatorId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Img { get; set; }
    public int Views { get; set; }
    public int Shares { get; set; }
    public int Keeps { get; set; }
    public Profile Creator { get; set; }
  }

  // REVIEW Come back, likely, and make the VaultKeepViewModel
  // plus the creator not in the database, but here in the model, add that on everytime


}