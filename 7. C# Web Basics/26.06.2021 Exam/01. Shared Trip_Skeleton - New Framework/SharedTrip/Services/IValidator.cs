using SharedTrip.Models.Users;
using System.Collections.Generic;

namespace SharedTrip.Controllers
{
    public interface IValidator
    {
        ICollection<string> ValidateUser(RegisterUserModel model);
    }
}