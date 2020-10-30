using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/binary-search-tree-iterator/

    class _0173二叉搜索树迭代器
    {
        public class BSTIterator
        {

            private List<int> values = new List<int>();
            private int index = 0;
            public BSTIterator(TreeNode root)
            {
                InOrder(root);
            }

            private void InOrder(TreeNode root)
            {
                if (root == null)
                {
                    return;
                }

                InOrder(root.left);

                values.Add(root.val);

                InOrder(root.right);
            }

            /** @return the next smallest number */
            public int Next()
            {
                if (index >= values.Count)
                {
                    return 0;
                }

                return values[index++];
            }

            /** @return whether we have a next smallest number */
            public bool HasNext()
            {
                return index < values.Count;
            }
        }
    }
}
