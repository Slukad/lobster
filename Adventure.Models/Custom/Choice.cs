using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Adventure.Models.Custom
{
    public class Choice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Text { get; set; }

        public virtual Decision Decision { get; set; }
        public virtual Decision NextDecision { get; set; }
        public virtual List<SelectedChoice> SelectedChoices { get; set; }
    }
}
