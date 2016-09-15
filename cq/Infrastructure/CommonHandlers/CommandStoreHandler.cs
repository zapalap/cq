using cq.Data;
using cq.Features.CommandStore;
using cq.Infrastructure.MediatorPipeline;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cq.Infrastructure.CommonHandlers
{
    public class CommandStoreHandler<TRequest, TReseponse> : IPostRequestHandler<TRequest, TReseponse>
    {
        private CqEntities Db;

        public CommandStoreHandler(CqEntities db)
        {
            Db = db;
        }

        public string JsonConver { get; private set; }

        public void Handle(TRequest request, TReseponse response)
        {
            var serializedCommand = new SerializedCommand
            {
                Json = JsonConvert.SerializeObject(request),
                StoredAt = DateTime.UtcNow
            };

            Db.Commands.Add(serializedCommand);
            Db.SaveChanges();
        }
    }
}