using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.栈
{
    //https://leetcode-cn.com/problems/valid-parentheses/

    class _0020有效的括号
    {
        public bool IsValid(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                //空字符串 有效
                return true;
            }

            if ((s.Length & 1) == 1)
            {
                //奇数数量的字符串 无效
                return false;   
            }

            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];

                if (c == '(' || c == '[' || c == '{')
                {
                    stack.Push(c);
                }
                else
                {
                    if (stack.Count == 0)
                    {
                        //栈里没有字符了 无效
                        return false;
                    }

                    char pop = stack.Pop();
                    if (
                        (pop == '(' && c != ')')
                        || (pop == '[' && c != ']')
                        || (pop == '{' && c != '}')
                        )
                    {
                        //和栈顶字符配不上 无效
                        return false;
                    }
                }
            }

            //栈里没有字符就有效 还有字符就无效
            return stack.Count == 0;

            
        }
    }
}
