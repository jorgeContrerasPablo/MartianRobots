﻿using Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.IRepositories
{
    public interface IRouteRepository
    {
        public Route AddAsync(Route route);
    }
}
