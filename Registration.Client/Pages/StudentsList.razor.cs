using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Registration.Client.BlazorDto;
using Registration.Client.Services.Interfaces;
using Registration.Shared.Models;

namespace Registration.Client.Pages
{
    public partial class StudentsList
    {
        [Inject]
        public AuthenticationStateProvider GetAuthenticationStateAsync { get; set; }
        [Inject]
        public IStudentBlazorService? StudentBlazorService  { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IAdminPermissionBlazorService AdminPermissionBlazorService { get; set; }
        public List<StudentDto> Students { get; set; } = default!;
        public Admin Admin { get; set; }
        protected override async Task OnInitializedAsync()
        {
            var authstate = await GetAuthenticationStateAsync.GetAuthenticationStateAsync();
            var user = authstate.User;
            var name = user.Identity.Name;
            Admin = await AdminPermissionBlazorService.GetAdminByUserId(name);
            Students = (await StudentBlazorService.All()).ToList();
        }

        public void ViewStudent(StudentDto s)
        {
            
            Console.WriteLine(s.Id);
        }
    }
}
