using System.Collections.ObjectModel;

namespace Society.Shared.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public byte[] Image { get; set; } = new byte[0];
        public ICollection<Friend> Friends { get; set; } = new Collection<Friend>();
    }
}
