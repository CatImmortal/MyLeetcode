using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/serialize-and-deserialize-bst/

    class _0449序列化和反序列化二叉搜索树
    {
        public class Codec
        {

            // Encodes a tree to a single string.
            public string serialize(TreeNode root)
            {
                if (root == null)
                {
                    return "#,";
                }
                //2, 1,#,#, 3,#,#,
                string s = root.val.ToString() + ",";
                s += serialize(root.left);
                s += serialize(root.right);

                return s;
            }

            // Decodes your encoded data to tree.
            public TreeNode deserialize(string data)
            {
                string[] strs = data.Split(',');

                int index = 0;
                TreeNode root = deserialize(strs, ref index);

                return root;
            }

            private TreeNode deserialize(string[] arr,ref int index)
            {
                string s = arr[index];
                index++;
                if (s == "#")
                {
                    return null;
                }

                

                TreeNode root = new TreeNode(int.Parse(s));

                //这里需要对index作引用传递
                //保证递归完左子树后 index是在右子树开头处的
                root.left = deserialize(arr, ref index);
                root.right = deserialize(arr, ref index);

                return root;
            }
        }
    }
}
