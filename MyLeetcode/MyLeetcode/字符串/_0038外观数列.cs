using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.字符串
{
    //https://leetcode-cn.com/problems/count-and-say/

    class _0038外观数列
    {
        public string CountAndSay(int n)
        {
            string ans = "1";
            StringBuilder sb = new StringBuilder();
            for (int i = 2; i <= n; i++)
            {
                int count = 1;
                char pre = ans[0];
                sb.Clear();
                for (int j = 1; j < ans.Length; j++)
                {
                    char c = ans[j];
                    if (c == pre)
                    {
                        //连续相同的数字 增加计数器
                        count++;
                    }
                    else
                    {
                        //不连续相同 追加到sb中 重置计数器
                        sb.Append(count).Append(pre);
                        pre = c;
                        count = 1;
                    }
                }

                //处理下字符串最后一组
                sb.Append(count).Append(pre);

                ans = sb.ToString();
            }

            return ans;
        }

        
    }
}
