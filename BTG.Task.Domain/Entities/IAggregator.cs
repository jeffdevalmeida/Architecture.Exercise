﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTG.Task.Domain.Entities
{
    public interface IAggregator
    {
        Guid Id { get; }
    }
}
