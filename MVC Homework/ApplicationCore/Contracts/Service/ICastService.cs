﻿using ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Service
{
    public interface ICastService
    {
        Casts GetCastDetails(int id);
    }
}
