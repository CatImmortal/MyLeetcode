using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/number-of-good-leaf-nodes-pairs/

    class _1530好叶子节点对的数量
    {

        private List<string> paths = new List<string>();

        public int CountPairs(TreeNode root, int distance)
        {
            int ans = 0;

            PreOrder(root, "");

            for (int i = 0; i < paths.Count; i++)
            {
                for (int j = i + 1; j < paths.Count; j++)
                {
                    //公共前缀长度
                    int k = 0;

                    string path1 = paths[i];
                    string path2 = paths[j];

                    int minLength = Math.Min(path1.Length, path2.Length);
                    while (k < minLength)
                    {
                        if (path1[k] != path2[k])
                        {
                            //公共前缀结束
                            break;  
                        }

                        k++;
                    }

                    if (path1.Length + path2.Length - 2 * k <= distance)
                    {
                        //距离小于distance
                        ans++;
                    }
                }
            }

            return ans;
        }

        private void PreOrder(TreeNode root,string path)
        {
            //叶子节点 路径加入列表
            if (root.left == null && root.right == null)
            {
                paths.Add(path);
                return;
            }

            //左子节点编码0
            if (root.left != null)
            {
                PreOrder(root.left, path + "0");
            }

            //右子节点编码1
            if (root.right != null)
            {
                PreOrder(root.right, path + "1");
            }
        }

    }
}
