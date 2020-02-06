using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Adventure.Models.Custom
{
    public class Adventure
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Player Player { get; set; }        
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public virtual List<SelectedChoice> SelectedChoices { get; set; }
    }
}
