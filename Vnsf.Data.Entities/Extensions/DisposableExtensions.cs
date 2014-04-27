﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vnsf.Data.Entities.Extensions
{
    public static class DisposableExtensions
    {
        public static bool TryDispose(this IDisposable item)
        {
            if (item == null) return false;
            item.Dispose();
            return true;
        }

    }
}
