using IckleUrl.Service;
using IckleUrl.Entities;
using IckleUrl.Models;
using System;
using System.Web.Mvc;
using System.Threading.Tasks;

namespace IckleUrl.Controllers
{
    public class IckleUrlController : Controller
    {
		private IIckleUrlService _ickleUrlService;

		public IckleUrlController(IIckleUrlService ickleUrlService)
		{
			this._ickleUrlService = ickleUrlService;
		}

		[HttpGet]
		public ActionResult Index()
		{
			ShortUrl url = new ShortUrl();
			return View(url);
		}

		public async Task<ActionResult> Index(ShortUrl url)
		{
			if (ModelState.IsValid)
			{
                try
                {
					SmallUrl shortUrl = await this._ickleUrlService.MakeUrlShorter(url.FullUrl, Request.UserHostAddress);
					url.ShortenedUrl = string.Format("{0}://{1}{2}{3}", Request.Url.Scheme, Request.Url.Authority, "/", shortUrl.Pointer);
				}
                catch(Exception ex)
                {
					url.ErrorMessage = ex.Message.ToString();
                }
				
			}
			return View(url);
		}

		public async Task<ActionResult> Click(string pointer)
		{
			var url =  await this._ickleUrlService.GetSmallUrl(pointer);

			return Redirect(url.FullUrl);
		}

	}
}