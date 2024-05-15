using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServiceChanson : Service<Chanson>, IServiceChanson
    {
        public ServiceChanson(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public List<Chanson> GetChansonByTitre(string Titre)
        {
            return GetMany(f => f.Titre == Titre).ToList();
        }
      
    }
}
