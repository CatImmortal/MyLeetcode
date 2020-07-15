using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/serialize-and-deserialize-binary-tree/

    class _0297二叉树的序列化与反序列化
    {

        //Encodes a tree to a single string.
        public string serialize(TreeNode root)
        {
            if (root == null)
            {
                return string.Empty;
            }

            if (root.left == null && root.right == null)
            {
                return root.val.ToString();
            }

            List<string> list = new List<string>();
            LevelOrder(root, list);
            while (list[list.Count - 1] == "null")
            {
                //删掉末尾的null
                list.RemoveAt(list.Count - 1);
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < list.Count; i++)
            {
                sb.Append(list[i]);
                if (i != list.Count - 1)
                {
                    sb.Append(",");
                }
            }

            return sb.ToString();
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                return null;
            }

            string[] strArray = data.Split(',');
            if (strArray.Length == 1)
            {
                return new TreeNode(int.Parse(strArray[0]));
            }

            //保存节点的数组
            TreeNode[] nodeArray = new TreeNode[strArray.Length];
            nodeArray[0] = new TreeNode(int.Parse(strArray[0]));

            //根节点索引 用来在nodeArray中找到对应的根节点
            int rootIndex = 0;

            for (int i = 1; i < strArray.Length; i += 2)
            {
                while (nodeArray[rootIndex] == null)
                {
                    //跳过为null的根节点
                    //因为是不正确的根节点
                    rootIndex++;
                }

                TreeNode root = nodeArray[rootIndex];
                rootIndex++;

                //两个一组 与根节点构建父子关系
                if (strArray[i] != "null")
                {
                    TreeNode left = new TreeNode(int.Parse(strArray[i]));
                    root.left = left;
                    nodeArray[i] = left;
                }

                if (i + 1 < strArray.Length && strArray[i + 1] != "null")
                {
                    TreeNode right = new TreeNode(int.Parse(strArray[i + 1]));
                    root.right = right;
                    nodeArray[i + 1] = right;
                }

            }

            return nodeArray[0];

        }

        private void LevelOrder(TreeNode root, List<string> list)
        {
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                TreeNode node = queue.Dequeue();

                if (node == null)
                {
                    //null节点添加个null字符串进去 不对子节点操作了
                    list.Add("null");
                    continue;
                }

                list.Add(node.val.ToString());

                //子节点可能为null
                queue.Enqueue(node.left);
                queue.Enqueue(node.right);
            }
        }
    }
}
