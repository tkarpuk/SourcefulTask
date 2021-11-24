using Users.Domain.Entities;

namespace Users.Persistence.Models
{
    public class AddressModel : Address
    {
        public UserInfoModel User { get; set; }
    }
}
