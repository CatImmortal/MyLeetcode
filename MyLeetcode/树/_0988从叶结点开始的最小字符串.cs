using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/smallest-string-starting-from-leaf/

    class _0988从叶结点开始的最小字符串
    {
        string ans = "~";

        public string SmallestFromLeaf(TreeNode root)
        {
            PreOrder(root, new StringBuilder());

            //翻转ans
            char[] chars = new char[ans.Length];
            for (int i = 0; i < chars.Length; i++)
            {
                chars[i] = ans[ans.Length - 1 - i];
            }

            return new string(chars);
        }

        private void PreOrder(TreeNode root,StringBuilder sb)
       {
            if (root == null)
            {
                return;
            }

            sb.Append((char)('a' + root.val));

            if (root.left == null && root.right == null)
            {
                //叶子节点 开始进行比对
                string str = sb.ToString();
                ans = GetMinString(ans, str);
            }

            PreOrder(root.left, sb);
            PreOrder(root.right, sb);
            sb.Remove(sb.Length - 1, 1);
       }

    

        private string GetMinString(string s1,string s2)
        {
            int p1 = s1.Length - 1;
            int p2 = s2.Length - 1;

            while (true)
            {

                int c1 = s1[p1];
                int c2 = s2[p2];

                if (c1 < c2)
                {
                    return s1;
                }

                if (c2 < c1)
                {
                    return s2;
                }

                if (p1 == 0)
                {
                    return s1;
                }

                if (p2 == 0)
                {
                    return s2;
                }

                p1--;
                p2--;
            }
        }
    }
}
