using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.回溯算法
{
    //https://leetcode-cn.com/problems/generate-parentheses/

    class _0022括号生成
    {
        private Stack<char> stack = new Stack<char>();

        public IList<string> GenerateParenthesis(int n)
        {
            //暴力枚举法

            if (n == 0)
            {
                return new List<string>();
            }

            List<string> ans = new List<string>();
            Helper(new StringBuilder(), ans, n * 2);
            return ans;
        }

        private void Helper(StringBuilder sb,List<string> ans,int n)
        {
            if (n == 0)
            {
                //递归到头了 检查当前字符串是否是有效括号
                if (IsValid(sb))
                {
                    ans.Add(sb.ToString());
                }
                return;
            }

            //枚举所有可能的组合

            sb.Append('(');
            Helper(sb, ans, n - 1);
            sb.Remove(sb.Length - 1, 1);

            sb.Append(')');
            Helper(sb, ans, n - 1);
            sb.Remove(sb.Length - 1, 1);
        }

        private bool IsValid(StringBuilder sb)
        {
            stack.Clear();

            for (int i = 0; i < sb.Length; i++)
            {
                char c = sb[i];

                if (c == '(')
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

                    //弹出栈顶字符
                    char pop = stack.Pop();

                    if  ( pop != '(')
                    {
                        //栈顶字符和当前字符和对应不上 无效
                        return false;
                    }
                }
            }

            //栈里没有字符就有效 还有字符就无效
            return stack.Count == 0;


        }

        //--------------------------------------------------------

        public IList<string> GenerateParenthesis2(int n)
        {
            //回溯+剪枝

            List<string> ans = new List<string>();

            if (n == 0)
            {
                return ans;
            }

            Helper2(new StringBuilder(), ans, n, n);

            return ans;
        }

        private void Helper2(StringBuilder sb, List<string> ans,int left,int right)
        {
            //剩余左括号和剩余右括号为0
            if (left == 0 && right == 0)
            {
                ans.Add(sb.ToString());
            }

            if (left > right)
            {
                //剩余左括号比剩余右括号多 剪枝
                return;
            }

            if (left > 0)
            {
                sb.Append('(');
                Helper2(sb,ans, left - 1, right);
                sb.Remove(sb.Length - 1, 1);
            }

            if (right > 0)
            {
                sb.Append(')');
                Helper2(sb, ans, left, right - 1);
                sb.Remove(sb.Length - 1, 1);
            }
        }

    }
}
