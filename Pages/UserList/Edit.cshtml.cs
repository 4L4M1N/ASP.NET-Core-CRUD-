using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using webvision.Models;

namespace webvision.Pages.UserList
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public UserInfo userInfo {get; set;}
        [TempData]
        public string Message { get; set; }
        public void OnGet(int id)
        {
            userInfo = _db.userInfos.Find(id);
        }
        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                var userFromDb = _db.userInfos.Find(userInfo.Id);
                userFromDb.Name = userInfo.Name;
                userFromDb.Email = userInfo.Email;
                userFromDb.Phone = userInfo.Phone;
                await _db.SaveChangesAsync();
                Message = "User has been updated sucessfully";
                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}