using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cq.Features.CommandStore.Queries
{
    public class ListStoredCommandsQuery : IRequest<IEnumerable<SerializedCommand>>
    {
    }
}