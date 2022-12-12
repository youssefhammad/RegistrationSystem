using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Registration.Client.BlazorDto;
using Registration.Client.Services.Interfaces;
using Registration.Shared.Models;

namespace Registration.Client.Pages
{
    public partial class AdminPermission
    {
        [Inject]
        public IAdminPermissionBlazorService? adminPermissionBlazorService  { get; set; }

        [Inject]
        public AuthenticationStateProvider GetAuthenticationStateAsync { get; set; }
        public NavigationManager NavigationManager { get; set; }
        public PermissionDto Permission { get; set; } = default!;
        public Admin Admin { get; set; } 
        public string name { get; set; }
 
        
        public PostPermissionDto PostPermission { get; set; } = new PostPermissionDto();
        public bool Issuccess = false;
        public string message;
        protected override async Task OnInitializedAsync()
        {
            var authstate = await GetAuthenticationStateAsync.GetAuthenticationStateAsync();
            var user = authstate.User;
            this.name = user.Identity.Name;
            Admin = await adminPermissionBlazorService.GetAdminByUserId(name);
            Permission = await adminPermissionBlazorService.GetLastPermissionTime();
        }

        public async Task UpdatePermissiondate()
        {
            PostPermission.AdminId = Admin.Id;
            Console.WriteLine($"start date = {PostPermission.StartDate.ToString()}" +
                $"end date = {PostPermission.EndDate.ToString()}" +
                $"adminId = {PostPermission.AdminId.ToString()}");
            var result = await adminPermissionBlazorService.AddNewTimePermisssion(PostPermission);
            Console.WriteLine(result);
            if(result == true)
            {
                Issuccess = true;
                message = "The Update success";
            }
        }

    }
}
