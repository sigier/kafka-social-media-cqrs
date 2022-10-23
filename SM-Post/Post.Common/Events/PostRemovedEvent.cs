using System.Security.AccessControl;
using CQRS.Core.Events;

namespace Post.Common.Events;

public class PostRemovedEvent: BaseEvent
{
    public PostRemovedEvent(): base(nameof(PostCreatedEvent))
    {
    }
    
    public Guid CommentId { get; set; }

}