using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/all-nodes-distance-k-in-binary-tree/

    class _0863二叉树中所有距离为_K_的结点
    {
        public IList<int> DistanceK(TreeNode root, TreeNode target, int K)
        {
            List<int> ans = new List<int>();

            if (K == 0)
            {
                ans.Add(target.val);
                return ans;
            }

            Stack<TreeNode> stack = new Stack<TreeNode>();

            if (root != null)
            {
                stack.Push(root);
            }


            while (stack.Count != 0)
            {
                TreeNode node = stack.Pop();

                if (node != target)
                {
                    //获取当前节点和target的最近公共祖先
                    TreeNode commonAncestor = LowestCommonAncestor(root, node, target);

                    //计算两个节点与最近公共祖先的距离
                    if (GetDistance(commonAncestor, node) + GetDistance(commonAncestor, target) == K)
                    {
                        //距离为K的话 就加入解答列表
                        ans.Add(node.val);
                    }
                }

                //pop root后先push right，再push left，以实现前序遍历

                if (node.right != null)
                {
                    stack.Push(node.right);
                }

                if (node.left != null)
                {
                    stack.Push(node.left);
                }



            }

            return ans;
        }

        /// <summary>
        /// 获取p和q在root下的最近公共祖先
        /// </summary>
        private TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null || root == p || root == q)
            {
                return root;
            }

            // LowestCommonAncestor的返回值如果不为null（p和q都不存在root下）
            //那么返回值是p和q其中至少一个的公共祖先（或者是其本身）

            TreeNode leftNode = LowestCommonAncestor(root.left, p, q);
            TreeNode rightNode = LowestCommonAncestor(root.right, p, q);

            if (leftNode != null && rightNode != null)
            {
                //p和q分别在左子树和右子树中 root是它俩的公共祖先
                return root;
            }

            if (leftNode != null)
            {
                //p和q都在左子树 leftNode是它俩的公共祖先
                return leftNode;
            }

            if (rightNode != null)
            {
                //p和q都在右子树 rightNode是它俩的公共祖先
                return rightNode;
            }

            return null;
        }

        /// <summary>
        /// 获取从root到子树节点target的距离
        /// </summary>
        private int GetDistance(TreeNode root,TreeNode target)
        {
            if (root == target)
            {
                return 0;
            }

            if (root.left != null)
            {
                int leftDistance = GetDistance(root.left, target);
                if (leftDistance != -1)
                {
                    return leftDistance + 1;
                }
            }

            if (root.right != null)
            {
                int rightDistance = GetDistance(root.right, target);
                if (rightDistance != -1)
                {
                    return rightDistance + 1;
                }
            }

            return -1;
        }

        //----------------------------------------------------

        private Dictionary<TreeNode, TreeNode> parentDict = new Dictionary<TreeNode, TreeNode>();
        public IList<int> DistanceK2(TreeNode root, TreeNode target, int K)
        {
            List<int> ans = new List<int>();

            PreOrder(root, null);

            //已经查看过的节点
            HashSet<TreeNode> seen = new HashSet<TreeNode>();
            seen.Add(target);

            Queue<TreeNode> queue1 = new Queue<TreeNode>();
            Queue<TreeNode> queue2 = new Queue<TreeNode>();
            queue1.Enqueue(target);

            //距离
            int dist = 0;


            while (queue1.Count > 0)
            {

                if (dist == K)
                {

                    foreach (TreeNode n in queue1)
                    {
                        ans.Add(n.val);
                    }
                    return ans;
                }

                dist++;
                
                while (queue1.Count > 0)
                {
                    TreeNode node = queue1.Dequeue();

                    seen.Add(node);

                    //把当前节点未查看过的左子节点 右子节点 父节点 放入queue2中

                    if (node.left != null && !seen.Contains(node.left))
                    {
                        queue2.Enqueue(node.left);
                    }
                    if (node.right != null && !seen.Contains(node.right))
                    {
                        queue2.Enqueue(node.right);
                    }

                    TreeNode parent = parentDict[node];
                    if (parent != null && !seen.Contains(parent))
                    {
                        queue2.Enqueue(parent);
                    }

                    
                }


                //把queue2里的所有node都放进queue1中
                while (queue2.Count > 0)
                {
                    queue1.Enqueue(queue2.Dequeue());
                }
            }


            return ans;
        }

        private void PreOrder(TreeNode root,TreeNode parent)
        {
            if (root == null)
            {
                return;
            }

            parentDict.Add(root, parent);
            PreOrder(root.left, root);
            PreOrder(root.right, root);
        }
    }
}
