using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nobatkar_WinUI.Interfaces.IServices;

public interface IPageService
{
    Type GetPageType(string key);
}
