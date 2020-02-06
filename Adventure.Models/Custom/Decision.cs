using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Adventure.Models.Custom
{
    public class Decision
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }       
        public string Text { get; set; }
        public int Level { get; set; }
        public int Order { get; set; }

        public virtual List<Choice> Choices { get; set; }
        public virtual List<Choice> NextDecisionChoices { get; set; }
    }
}
