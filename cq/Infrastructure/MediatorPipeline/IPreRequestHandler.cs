using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cq.Infrastructure.MediatorPipeline
{
    public interface IPreRequestHandler<in TRequest>
    {
        void Handle(TRequest request);
    }
}
