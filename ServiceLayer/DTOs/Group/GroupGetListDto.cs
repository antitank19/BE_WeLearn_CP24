using System.Collections.ObjectModel;

namespace ServiceLayer.DTOs
{
    public class GroupGetListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MemberCount { get; set; }
        public int ClassId { get; set; }
        public ICollection<string> Subjects { get; set; }=new Collection<string>();
    }
}
