﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IpAddressApi.Output
{
    public interface IOutputWriter
    {
        void WriteLine(string message);
    }
}
