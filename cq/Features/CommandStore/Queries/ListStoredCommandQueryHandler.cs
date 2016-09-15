using cq.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cq.Features.CommandStore.Queries
{
    public class ListStoredCommandQueryHandler : IRequestHandler<ListStoredCommandsQuery, IEnumerable<SerializedCommand>>
    {
        private CqEntities Db;

        public ListStoredCommandQueryHandler(CqEntities db)
        {
            Db = db;
        }

        public IEnumerable<SerializedCommand> Handle(ListStoredCommandsQuery message)
        {
            return Db.Commands.ToList();
        }
    }
}