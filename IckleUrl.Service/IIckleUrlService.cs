using IckleUrl.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IckleUrl.Service
{
    public interface IIckleUrlService
    {
        Task<SmallUrl> MakeUrlShorter(string url, string ip);

        Task<SmallUrl> GetSmallUrl(string pointer);

    }
}
