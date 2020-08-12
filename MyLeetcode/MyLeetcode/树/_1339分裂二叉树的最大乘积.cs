using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/maximum-product-of-splitted-binary-tree/

    class _1339分裂二叉树的最大乘积
    {
        private Dictionary<TreeNode, long> sumDict = new Dictionary<TreeNode, long>();
        private long rootSum = 0;
        private long ans = 0;
        private long mod = (long)(Math.Pow(10, 9)) + 7;

        public int MaxProduct(TreeNode root)
        {
            GetSum(root);
            rootSum = sumDict[root];

            PreOrder(root);


            return (int)(ans % mod);
        }

        private long GetSum(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            long sum = root.val + GetSum(root.left) + GetSum(root.right);
            sumDict[root] = sum;
            return sum;
        }

        private void PreOrder(TreeNode root)
        {
            if (root == null)
            {
                return;
            }

            //获取左子节点或右子节点的节点和
            //用总节点和减去子节点和，得到切开后的另一半树的节点和
            //最后更新ans

            if (root.left != null)
            {
                long leftSum = sumDict[root.left];
                long rightSum = rootSum - leftSum;
                ans = Math.Max(ans, (leftSum * rightSum));
            }

            if (root.right != null)
            {
                long rightSum = sumDict[root.right];
                long leftSum = rootSum - rightSum;
                ans = Math.Max(ans, (leftSum * rightSum));
            }

            PreOrder(root.left);
            PreOrder(root.right);
        }

        //----------------------------------------
        private List<long> sums = new List<long>();
        public int MaxProduct2(TreeNode root)
        {
            //后序遍历计算每个节点的子树节点和
            PostOrder(root);

            long ans = 0;
            for (int i = 0; i < sums.Count; i++)
            {
                //计算每个子树节点和与另一半子树节点和的乘积
                //然后更新ans
                ans = Math.Max(ans,sums[i] * (sums[sums.Count - 1] - sums[i]));
            }
            int mod = (int)(1e9 + 7);
            return (int)(ans % mod);
        }

        private long PostOrder(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            long sum = root.val + PostOrder(root.left) + PostOrder(root.right);

            sums.Add(sum);

            return sum;
        }
    }
}
