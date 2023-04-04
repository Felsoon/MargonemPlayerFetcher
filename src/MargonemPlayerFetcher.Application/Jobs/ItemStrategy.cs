﻿using MargoFetcher.Domain.Entities;
using MargoFetcher.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MargoFetcher.Application.Jobs
{
    public abstract class ItemStrategy
    {
        public abstract Task HandleItem(Item items);
    }
}
