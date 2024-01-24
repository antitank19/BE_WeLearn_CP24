using Microsoft.AspNetCore.SignalR;

namespace API.SignalR
{
    public class GroupHub : Hub
    {
        public static string CountMemberInGroupMsg => "CountMemberInGroup";
        public static string OnLockedUserMsg => "OnLockedUser";
        public static string OnReloadMeetingMsg => "OnReloadMeeting";
    }
}
