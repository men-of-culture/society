namespace Society.Api.Models
{
    public class Friend
    {
        public Guid UserId { get; set; }
        public Guid FriendId { get; set; }
        public string FriendName { get; set; } = string.Empty;
        public byte[]? FriendImage { get; set; }
    }
}
