using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.字符串
{
    //https://leetcode-cn.com/problems/add-binary/

    class _0067二进制求和
    {
        public string AddBinary(string a, string b)
        {
            StringBuilder sb = new StringBuilder();

            int p1 = a.Length - 1;
            int p2 = b.Length - 1;

            int carry = 0;

            while (p1 >= 0 || p2 >= 0)
            {
                int x = 0;
                if (p1 >= 0)
                {
                    x = a[p1] - 48;
                }

                int y = 0;
                if (p2 >= 0)
                {
                    y = b[p2] - 48;
                }

                int sum = x + y + carry;
                carry = sum / 2;

                sum = sum % 2;

                sb.Insert(0, sum);

                if (p1 >= 0)
                {
                    p1--;
                }

                if (p2 >= 0)
                {
                    p2--;
                }
            }

            if (carry > 0)
            {
                sb.Insert(0, carry);
            }

            return sb.ToString();
        }

    }
}
