using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace REIFinal.Core.Common
{
  public interface IDBContext
    {
        DbConnection connection { get; }
    }
}
