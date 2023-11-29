using System.Text.Json.Serialization;

namespace Society.Api.Models
{
    public class Friend
    {
        [JsonIgnore]
        public Guid UserId { get; set; }

        [JsonIgnore]
        public User User { get; set; } = new();

        [JsonIgnore]
        public Guid FriendId { get; set; }
        
        public User UserFriend { get; set; } = new();
    }
}
