using IckleUrl.Entities;
using IckleUrl.Models;
using IckleUrl.Service;
using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace IckleUrl.API
{
	[RoutePrefix("api/ickleurl")]
	public class IckleUrlApiController : ApiController
	{
		private IIckleUrlService _ickleUrlService;

		public IckleUrlApiController(IIckleUrlService ickleUrlService)
		{
			this._ickleUrlService = ickleUrlService;
		}

		[Route("shorten")]
		[HttpPost]
		public async Task<IHttpActionResult> MakeSmallUrl([FromUri] string url)
		{
			ShortUrl shortened = new ShortUrl();

			try
			{
				SmallUrl shortUrl = await this._ickleUrlService.MakeUrlShorter(HttpUtility.UrlDecode(url), HttpContext.Current.Request.UserHostAddress);
				shortened.FullUrl = url;
				shortened.ShortenedUrl = string.Format("{0}://{1}/{2}", HttpContext.Current.Request.Url.Scheme, HttpContext.Current.Request.Url.Authority, shortUrl.Pointer);
				return Ok(shortened);

			}
			catch (Exception ex)
			{
				shortened.ErrorMessage = ex.Message.ToString();

				return BadRequest(shortened.ErrorMessage);
			}



		}

	}
}