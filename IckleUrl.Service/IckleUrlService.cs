using IckleUrl.Context;
using IckleUrl.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace IckleUrl.Service
{
    public class IckleUrlService :IIckleUrlService
    {
		private IckleUrlContext _ickleUrlContext;
		public IckleUrlService(IckleUrlContext ickleUrlContext)
        {
			_ickleUrlContext = ickleUrlContext;
        }
        public Task<SmallUrl> MakeUrlShorter(string fullurl, string ip)
        {
			return Task.Run(() =>
			{
				
					SmallUrl url;
					string pointer;

					url = _ickleUrlContext.ShortUrls.Where(u => u.FullUrl == fullurl).FirstOrDefault(); ;

					if (url != null)
					{
						return url;
					}

					if (!Helpers.FullUrlIsValid(fullurl))
					{
						throw new ArgumentException("Invalid URL format");
					}

					try
                    {
						 pointer = Helpers.NewPointer(_ickleUrlContext);
					}
                    catch
                    {
						throw new ArgumentException("Pointer is empty");
					}			

					url = new SmallUrl()
					{
						Ip = ip,
						FullUrl = fullurl,
						Pointer = pointer
					};

					_ickleUrlContext.ShortUrls.Add(url);

					_ickleUrlContext.SaveChanges();

					return url;
			});
		}

		public Task<SmallUrl> GetSmallUrl(string pointer)
		{
			return Task.Run(() =>
			{
				
                try
				{
					SmallUrl url = _ickleUrlContext.ShortUrls.Where(u => u.Pointer == pointer).FirstOrDefault();
					return url;
				}
                catch
                {
					throw new Exception("Unable to retrive URL");
                }


			});

		}

	}
}
