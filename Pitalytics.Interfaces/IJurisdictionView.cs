﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitalytics.Interfaces 
{
    public interface IJurisdictionView : IJurisdiction
    {
        string ProcessingMessage { get; set; }
    }
}
