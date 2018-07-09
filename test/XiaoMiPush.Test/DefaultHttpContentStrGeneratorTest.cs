using System;
using System.Collections.Generic;
using System.Text;
using XiaoMiPush.Abstraction;
using Xunit;

namespace XiaoMiPush.Test
{

    public class DefaultHttpContentStrGeneratorTest
    {
        IHttpContentStrGenerator httpContentStrGenerator = new DefaultHttpContentStrGenerator();
        [Theory()]
        [InlineData("id","10",  "id=10")]
        [InlineData("name", "100", "name=100")]
        public void Get_Single_Perameter_CorrentStr(string k1,string p1,string result)
        {
            var dic = new Dictionary<string, string>();
            dic.Add(k1, p1);
            var str = httpContentStrGenerator.Generate(dic);
            Assert.Equal(result, str);
        }
        [Fact]
        public void Get_Mutiple_Perameter_CorrentStr()
        {
            var dic = new Dictionary<string, string>();
            dic.Add("name", "serge");
            dic.Add("id", "100");
            dic.Add("number", "1300");
            var str = httpContentStrGenerator.Generate(dic);
            Assert.Equal("name=serge&id=100&number=1300", str);
        }
    }


}
