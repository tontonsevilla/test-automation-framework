﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomationFramework.Core.WebUI.Abstraction
{
    public interface ILogging
    {
        void Debug(string message);
        void Error(string message);
        void Fatal(string message);
        void Warning(string message);
        void Information(string message);
    }
}
