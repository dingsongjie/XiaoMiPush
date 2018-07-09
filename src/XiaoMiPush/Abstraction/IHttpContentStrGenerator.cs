using System;
using System.Collections.Generic;
using System.Text;

namespace XiaoMiPush.Abstraction
{
    public interface IHttpContentStrGenerator
    {
        string Generate(Dictionary<string, string> parameters);
    }
}
