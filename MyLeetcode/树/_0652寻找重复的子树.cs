using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/find-duplicate-subtrees/

    class _0652寻找重复的子树
    {
        private int IdCounter = 1;
        private Dictionary<string, int> treesDict = new Dictionary<string, int>();
        private Dictionary<int, int> countDict = new Dictionary<int, int>();
        private List<TreeNode> ans = new List<TreeNode>();

        public IList<TreeNode> FindDuplicateSubtrees(TreeNode root)
        {
            PostOrder(root);

            return ans;
        }

        private int PostOrder(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            string leftSerial = PostOrder(root.left).ToString();
            string rightSerial = PostOrder(root.right).ToString();

            string rootSerial = $"{root.val.ToString()},{leftSerial},{rightSerial}";

            //获取子树序列化对应的uid
            if (!treesDict.TryGetValue(rootSerial, out int uid))
            {
                uid = IdCounter;
                treesDict.Add(rootSerial, uid);
                ++IdCounter;
            }

            //统计此uid出现的次数
            if (!countDict.TryGetValue(uid,out int count))
            {
                count = 1;
                countDict.Add(uid, 1);
            }
            else
            {
                countDict[uid] += 1;
            }

            //第二次重复出现 加入解答列表
            if (countDict[uid] == 2)
            {
                ans.Add(root);
            }

            return uid;

          





        }


    }
}
