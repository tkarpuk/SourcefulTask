using Users.Domain.Entities;

namespace Users.Persistence.Models
{
    public class FilmModel : Film
    {
        public UserInfoModel User { get; set; }
    }
}
