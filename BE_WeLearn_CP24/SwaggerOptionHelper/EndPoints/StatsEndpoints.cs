using API.SwaggerOption.Const;

namespace API.SwaggerOption.Endpoints
{
    public class StatsEndpoints
    {
        public const string GetStatForStudentInMonthNew = $"[{Actor.Student_Parent}/{Finnished.False}/{Auth.True}] Student's stat by month";
        public const string GetStatForStudent = $"[{Actor.Student_Parent}/{Finnished.False}/{Auth.True}] Student's stat by month";
    }
}
