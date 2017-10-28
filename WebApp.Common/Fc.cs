using System;
using System.Collections.Generic;
using System.Text;

namespace WebApp.Common
{
    public static class Fc
    {
        /// <summary>
        /// Guid + Guid 난수코드 생성 후 대문자로 반환
        /// </summary>
        /// <returns></returns>
        public static string GetDoubleGuid()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Guid.NewGuid().ToString().ToUpper());
            sb.Append("-");
            sb.Append(Guid.NewGuid().ToString().ToUpper());
            return sb.ToString();
        }
    }
}
