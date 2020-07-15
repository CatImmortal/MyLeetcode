using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/all-elements-in-two-binary-search-trees/

    class _1305两棵二叉搜索树中的所有元素
    {

        public IList<int> GetAllElements(TreeNode root1, TreeNode root2)
        {
            List<int> result1 = new List<int>();
            List<int> result2 = new List<int>();

            //中序遍历两棵二叉搜索树 然后归并排序即可
            Inorder(root1, result1);
            Inorder(root2, result2);
            List<int> result3 = MergeSort(result1, result2);

            return result3;
        }

        private void Inorder(TreeNode root, List<int> result)
        {
            if (root == null)
            {
                return;
            }
            Inorder(root.left, result);
            result.Add(root.val);
            Inorder(root.right, result);
        }

        private List<int> MergeSort(List<int> list1, List<int> list2)
        {
            List<int> result = new List<int>(list1.Count + list2.Count);
            int i = 0;
            int j = 0;

            while (true)
            {
                if (i >= list1.Count)
                {
                    result.Add(list2[j]);
                    j++;
                }
                else if (j >= list2.Count)
                {
                    result.Add(list1[i]);
                    i++;
                }
                else if (list1[i] < list2[j])
                {
                    result.Add(list1[i]);
                    i++;
                }
                else
                {
                    result.Add(list2[j]);
                    j++;
                }

                if (i >= list1.Count && j >= list2.Count)
                {
                    break;
                }
            }

            return result;
        }
    }
}
