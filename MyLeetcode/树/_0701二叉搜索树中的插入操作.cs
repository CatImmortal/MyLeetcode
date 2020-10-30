using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/insert-into-a-binary-search-tree/

    class _0701二叉搜索树中的插入操作
    {
        public TreeNode InsertIntoBST(TreeNode root, int val)
        {
            if (root == null)
            {
                return new TreeNode(val);
            }

            TreeNode cur = root;
            while (cur != null)
            {
                if (cur.val == val)
                {
                    break;
                }

                if (cur.val > val)
                {
                    if (cur.left == null)
                    {
                        cur.left = new TreeNode(val);
                        break;
                    }
                    else
                    {
                        cur = cur.left;
                    }
                }
                else
                {
                    if (cur.right == null)
                    {
                        cur.right = new TreeNode(val);
                        break;
                    }
                    else
                    {
                        cur = cur.right;
                    }
                }
            }

            return root;
        }
    }
}
