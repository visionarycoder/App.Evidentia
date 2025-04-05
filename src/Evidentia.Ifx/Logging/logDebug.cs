using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evidentia.Ifx.Logging;

public delegate Action<string, object[]> logDebug(string message, object[] args);