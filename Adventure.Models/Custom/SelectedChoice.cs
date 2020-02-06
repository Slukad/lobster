using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Adventure.Models.Custom
{
    public class SelectedChoice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Adventure Adventure { get; set; }        
        public Choice Choice { get; set; }
        public int DecisionId { get; set; }
        public int ChoiceId { get; set; }
    }
}
