using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/recover-binary-search-tree/

    class _0099恢复二叉搜索树
    {
        private List<TreeNode> nodes = new List<TreeNode>();

        public void RecoverTree(TreeNode root)
        {
            InOrder(root);

            TreeNode x = null;
            TreeNode y = null;

            //找到两个位置错误的节点
            for (int i = 0; i < nodes.Count - 1; i++)
            {
                if (nodes[i].val > nodes[i+1].val)
                {
                    y = nodes[i + 1];
                    if (x == null)
                    {
                        x = nodes[i];
                    }
                }
            }

            //交换节点值
            if (x!=null && y!= null)
            {
                int temp = x.val;
                x.val = y.val;
                y.val = temp;
            }
        }

        private void InOrder(TreeNode root)
        {
            if (root == null)
            {
                return;
            }

            InOrder(root.left);

            nodes.Add(root);

            InOrder(root.right);
        }


        public void RecoverTree2(TreeNode root)
        {
            if (root == null)
            {
                return;
            }

            TreeNode x = null;
            TreeNode y = null;
            TreeNode pre = null;
            TreeNode temp = null;

            while (root != null)
            {
                if (root.left != null)
                {
                    temp = root.left;

                    //一直往右走 找root的左子树最右节点
                    while (temp.right != null && temp.right != root)
                    {
                        temp = temp.right;
                    }

                
                    if (temp.right == null)
                    {
                        //root的左子树最右节点的右子节点为空 和root连接
                        temp.right = root;

                        //重新回到root.left
                        root = root.left;
                    }
                    else
                    {
                        if (pre != null && pre.val > root.val)
                        {
                            y = root;
                            if (x == null)
                            {
                                x = pre;
                            }
                        }

                        //已遍历完root的左子树 断开和root的连接

                        pre = root;
                        temp.right = null;

                        //往右走一步
                        root = root.right;
                    }
                }
                else
                {
                    if (pre != null && pre.val > root.val)
                    {
                        y = root;
                        if (x == null)
                        {
                            x = pre;
                        }
                    }

                    //root.left为空 往右走一步

                    pre = root;
                    root = root.right;
                }
            }

            if (x!= null && y != null)
            {
                int temp2 = x.val;
                x.val = y.val;
                y.val = temp2;
            }
        }
    }
}
