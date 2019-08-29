using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pitalytics.Interfaces;

namespace Pitalytics.Domain.Services
{
    public class LookupServices : ILookupService
    {

        private readonly ILookupRepository lookupRepository;
        private readonly IGeneralFactory generalFactory;


        public LookupServices(ILookupRepository lookupRepository, IGeneralFactory generalFactory)
        {
            this.generalFactory = generalFactory;
            this.lookupRepository = lookupRepository;
        }

    }
}
