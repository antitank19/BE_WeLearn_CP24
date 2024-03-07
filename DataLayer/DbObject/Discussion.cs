using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace DataLayer.DbObject
{
    public class Discussion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // Student
        [ForeignKey("AccountId")]
        public int AccountId { get; set; }
        public virtual Account Account { get; set; }

        [ForeignKey("GroupId")]
        public int GroupId { get; set; }
        public virtual Group Group { get; set; }

        public string Question { get; set; }
        public ICollection<AnswerDiscussion> AnswerDiscussion { get; set; } = new Collection<AnswerDiscussion>();
    }
}
