using IckleUrl.Context;
using System;
using System.Linq;
using System.Net;

namespace IckleUrl.Service
{
    public class Helpers
    {
		public static bool FullUrlIsValid(string fullurl)
		{
			if (!fullurl.StartsWith("http://") && !fullurl.StartsWith("https://"))
			{
				return false;
			}

			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(fullurl);
			request.Timeout = 10000;
			try
			{
				HttpWebResponse response = (HttpWebResponse)request.GetResponse();
			}
			catch (Exception)
			{
				return false;
			}

			return true;

		}

		public static string NewPointer(IckleUrlContext ctx)
		{
			
			int i = 0;
			while (true)
			{
				string pointer = Guid.NewGuid().ToString().Substring(0, 6);
				if (!ctx.ShortUrls.Where(u => u.Pointer == pointer).Any())
				{
					return pointer;
				}
				if (i > 50)
				{
					break;
				}
				i++;
			}
			return string.Empty;

			
		}
		
	}
}
