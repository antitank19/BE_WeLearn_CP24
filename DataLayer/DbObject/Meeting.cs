using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;

namespace DataLayer.DBObject
{
    public class Meeting
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public string Content { get; set; }
        public int CountMember { get; set; }
        public DateTime? Start { get; set; } = null;
        public DateTime? End { get; set; } = null;
        public DateTime? ScheduleStart { get; set; } = null;
        public DateTime? ScheduleEnd { get; set; } = null;

        #region Schedule
        public int? ScheduleId { get; set; }
        [ForeignKey("ScheduleId")]
        public virtual Schedule? Schedule { get; set; }
        #endregion

       
    }
}