using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Post.Common.DTO;
using Post.Query.Domain.Entities;

namespace Post.Query.Api.DTO
{
    public  class PostLookupResponse: BaseResponse
    {
        public List<PostEntity> Posts { get; set; }
    }
}
