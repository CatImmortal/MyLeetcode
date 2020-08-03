using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/add-one-row-to-tree/

    class _0623在二叉树中增加一行
    {
        public TreeNode AddOneRow(TreeNode root, int v, int d)
        {
            if (d == 1)
            {
                TreeNode newRoot = new TreeNode(v);
                newRoot.left = root;
                return newRoot;
            }

            LevelOrder(root,v,d);
            return root;
        }

        public void LevelOrder(TreeNode root,int v,int d)
        {

            if (root == null)
            {
                return;
            }

            Queue<TreeNode> queue1 = new Queue<TreeNode>();
            Queue<TreeNode> queue2 = new Queue<TreeNode>();

            queue1.Enqueue(root);

            //当前深度
            int depth = 0;

            while (queue1.Count > 0)
            {
                depth++;

                //把queue1里的所有node都出队，并把它们的子节点都暂时放进queue2里
                while (queue1.Count > 0)
                {
                    TreeNode node = queue1.Dequeue();

                    if (depth + 1 == d)
                    {
                        //到达目标深度的前一层
                        //开始插入新层
                        TreeNode oldLeft = node.left;
                        TreeNode oldRight = node.right;

                        node.left = new TreeNode(v);
                        node.right = new TreeNode(v);

                        node.left.left = oldLeft;
                        node.right.right = oldRight;
                    }
                    else
                    {
                        if (node.left != null)
                        {
                            queue2.Enqueue(node.left);
                        }
                        if (node.right != null)
                        {
                            queue2.Enqueue(node.right);
                        }
                    }
                }


                //把queue2里的所有node都放进queue1中
                while (queue2.Count > 0)
                {
                    queue1.Enqueue(queue2.Dequeue());
                }

                
            }



        }
    }
}
