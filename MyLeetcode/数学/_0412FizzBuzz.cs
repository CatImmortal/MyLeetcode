using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.数学
{
    //https://leetcode-cn.com/problems/fizz-buzz/

    class _0412FizzBuzz
    {
        public IList<string> FizzBuzz(int n)
        {
            List<string> ans = new List<string>(n);
            StringBuilder sb = new StringBuilder();

            for (int i = 1; i <= n; i++)
            {
                sb.Clear();

                int mod3 = i % 3;
                int mod5 = i % 5;

                //3的倍数
                if (mod3 == 0)
                {
                    sb.Append("Fizz");
                }

                //5的倍数
                if (mod5 == 0)
                {
                    sb.Append("Buzz");
                }

                //既不是3的倍数 也不是5的倍数
                if (sb.Length == 0)
                {
                    sb.Append(i.ToString());
                }

                ans.Add(sb.ToString());
            }

            return ans;
        }
    }
}
