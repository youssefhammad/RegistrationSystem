using Microsoft.AspNetCore.Components;
using Registration.Client.AuthServices;
using Registration.Shared.AuthModels;

namespace Registration.Client.Pages
{
    public partial class Login
    {
        private LoginModel _LoginModel = new LoginModel();

        [Inject]
        public IAuthService AuthService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public bool ShowAuthError { get; set; }
        public string Errorr { get; set; }

        


        public async Task ExecuteLogin()
        {
            //_LoginModel.IsAdmin = false;
            ShowAuthError = false;

            var result = await AuthService.Login(_LoginModel);
            if (!result.IsAuthSuccessful)
            {
                Errorr = result.Error;
                ShowAuthError = true;
            }
            else
            {
                NavigationManager.NavigateTo("/", true);
            }
        }
    }
}
