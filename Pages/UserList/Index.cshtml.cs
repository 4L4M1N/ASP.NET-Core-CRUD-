using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.EntityFrameworkCore;
using webvision.Models;


namespace webvision.Pages.UserList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [TempData]
        public string Message { get; set; }
        public IEnumerable<UserInfo>userInfos {get;set;}
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task OnGetAsync() 
        {
            userInfos = await _db.userInfos.ToListAsync();
        }
        public async Task<IActionResult> OnPostDelete(int id)
        {
            var user = await _db.userInfos.FindAsync(id);
            _db.userInfos.Remove(user);
            await _db.SaveChangesAsync();
            Message = "User deleted sucessfully";
            return RedirectToPage("Index");
        }
        

    }
}