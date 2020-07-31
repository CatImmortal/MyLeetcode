using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/print-binary-tree/

    class _0655输出二叉树
    {
        List<IList<string>> ans = new List<IList<string>>();

        public IList<IList<string>> PrintTree(TreeNode root)
        {
            int height = GetHeight(root);
            int width = (1 << height) - 1;
            for (int i = 0; i < height; i++)
            {
                List<string> list = new List<string>();

                for (int j = 0; j < width; j++)
                {
                    list.Add("");
                }

                ans.Add(list);
            }

            Fill(root, 0, 0, ans[0].Count);

            return ans;
        }

        private int GetHeight(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            return 1 + Math.Max(GetHeight(root.left), GetHeight(root.right));
        }

        private void Fill(TreeNode root,int row,int left,int right)
        {
            if (root == null)
            {
                return;
            }

            int mid = (left + right) / 2;

            //把根节点放到当前行数的中间位置
            ans[row][mid] = root.val.ToString();

            //更新行数和左右边界
            //递归填充左子树和右子树
            Fill(root.left, row + 1, left, mid - 1);
            Fill(root.right, row + 1, mid + 1, right);
        }

    }
}
