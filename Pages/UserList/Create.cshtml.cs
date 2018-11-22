using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using webvision.Models;


namespace webvision.Pages.UserList
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        
        [TempData]
        public string Message { get; set; }
        public CreateModel(ApplicationDbContext db){
            _db = db;
        }
        [BindProperty]
        public UserInfo userInfo{get;set;}
        public void OnGet()
        {
        }
        public async Task<IActionResult>OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            _db.userInfos.Add(userInfo);
            await _db.SaveChangesAsync();
            Message = "User has been created";
            return RedirectToPage("Index");
        }
    }
}