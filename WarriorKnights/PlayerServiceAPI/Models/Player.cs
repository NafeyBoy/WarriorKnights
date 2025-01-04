using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayerServiceAPI.Models
{
    [Table("Player", Schema = "dbo")]
    public class Player
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get;set;}
        public int GameId {get;set;}
        public string Name {get;set;}
        public string Colour {get;set;}
        public int Cash  {get;set;}
        public int Order  {get;set;}
        
    }
}