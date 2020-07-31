using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/binary-tree-zigzag-level-order-traversal/

    class _0103二叉树的锯齿形层次遍历
    {
        public IList<IList<int>> ZigzagLevelOrder (TreeNode root)
        {
            List<IList<int>> result = new List<IList<int>>();
            if (root == null)
            {
                return result;
            }

            //每一层的节点都会按照从左往右的顺序放入此链表
            //然后根据需求决定是从头开始取还是从尾开始取
            LinkedList<TreeNode> nodes = new LinkedList<TreeNode>();

            nodes.AddFirst(root);
            bool isRightToLeft = false;

            while (nodes.Count > 0)
            {
                List<int> list = new List<int>();

                //使用最初的count
                int count = nodes.Count;

                for (int i = 0; i < count; i++)
                {
                    if (!isRightToLeft)
                    {
                        //从左往右的层 从链表头取节点
                        TreeNode cur = nodes.First.Value;
                        nodes.RemoveFirst();

                        list.Add(cur.val);

                        //子节点按照从左往右的顺序放入链表尾部
                        if (cur.left != null)
                        {
                            nodes.AddLast(cur.left);
                        }
                        if (cur.right != null)
                        {
                            nodes.AddLast(cur.right);
                        }
                    }
                    else
                    {
                        //从右往左的层 从链表尾取节点
                        TreeNode cur = nodes.Last.Value;
                        nodes.RemoveLast();

                        list.Add(cur.val);

                        //子节点按照从右往左的顺序放入链表头部
                        if (cur.right != null)
                        {
                            nodes.AddFirst(cur.right);
                        }
                        if (cur.left != null)
                        {
                            nodes.AddFirst(cur.left);
                        }
                        
                    }
                }

               

                result.Add(list);
                isRightToLeft = !isRightToLeft;
            }

            return result;

        }

        public IList<IList<int>> ZigzagLevelOrder2(TreeNode root)
        {
            List<IList<int>> ans = new List<IList<int>>();
            PreOrder(root, 1, ans);
            return ans;
        }

        private void PreOrder(TreeNode root,int level,List<IList<int>> ans)
        {
            if (root == null)
            {
                return;
            }

            if (level > ans.Count)
            {
                //第一次到达该层
                ans.Add(new List<int>());
            }

            IList<int> list = ans[level - 1];

            if (level % 2 == 1)
            {
                //奇数层 需要从左往右 直接加到尾部
                list.Add(root.val);
            }
            else
            {
                //偶数层 需要从右往左 加到头部 
                //因为遍历顺序是从左往右的
                list.Insert(0, root.val);
            }

            PreOrder(root.left, level+1, ans);
            PreOrder(root.right, level+1, ans);
        }
    }
}
