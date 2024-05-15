using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServiceConcert : Service<Concert>, IServiceConcert
    {
        public ServiceConcert(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
