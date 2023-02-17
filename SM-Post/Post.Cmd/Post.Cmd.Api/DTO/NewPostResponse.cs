
using Post.Common.DTO;

namespace Post.Cmd.Api.DTO
{
    public class NewPostResponse : BaseResponse
    {
        public Guid Id { get; set; }
    }
}