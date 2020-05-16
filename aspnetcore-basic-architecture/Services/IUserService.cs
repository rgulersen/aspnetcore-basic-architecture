using AspnetCoreBasicArchitecture.ViewModel;
using System.Threading.Tasks;

namespace AspnetCoreBasicArchitecture.Services
{
    public interface IUserService
    {
        Task<UserManagerResponseViewModel> RegisterUserAsync(UserRegisterViewModel viewModel);

        Task<UserManagerResponseViewModel> LoginUserAsync(UserLoginViewModel viewModel);
    }
}
