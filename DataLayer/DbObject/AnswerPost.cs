using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DbObject
{
    public class AnswerPost
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        //Student
        [ForeignKey("GroupMemberId")]
        public int GroupMemberId { get; set; }
        public virtual GroupMember GroupMember { get; set; }
        public string Content { get; set; }
    }
}
