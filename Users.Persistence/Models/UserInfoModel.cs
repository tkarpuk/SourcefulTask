using System.Collections.Generic;
using Users.Domain.Entities;

namespace Users.Persistence.Models
{
    public class UserInfoModel : UserInfo
    {
        public List<FilmModel> Films { get; set; }
        public List<AddressModel> Addresses { get; set; }
    }
}
