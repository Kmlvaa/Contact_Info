using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.ContentModel;
using P335_BackEnd.Areas.Admin.Models;
using P335_BackEnd.Data;
using P335_BackEnd.Entities;

namespace P335_BackEnd.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize]
	public class ContactController : Controller
	{
		private readonly AppDbContext _dbContext;

		public ContactController(AppDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public IActionResult ContactInfo()
		{
			var entities = _dbContext.ContactInfo.ToList();

			var model = new ContactInfoVM
			{
				Email = entities[0].Email,
				PhoneNumber = entities[0].PhoneNumber,
			};
			return View(model);
		}

		[HttpPost]
		public IActionResult ContactInfo(ContactInfoVM contactInfo,int id)
		{
			var foundContact = _dbContext.ContactInfo.FirstOrDefault(x => x.Id == id);

            if (foundContact == null) { return RedirectToAction("Index", "Home"); }
            foundContact.Email = contactInfo.Email;
			foundContact.PhoneNumber = contactInfo.PhoneNumber;
            return View();
		}
	}
}
