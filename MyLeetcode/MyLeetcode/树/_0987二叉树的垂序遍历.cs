using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/vertical-order-traversal-of-a-binary-tree/

    class _0987二叉树的垂序遍历
    {
        struct Location : IComparable<Location>
        {
            public int x;
            public int y;
            public int val;

            public Location(int x, int y,int val)
            {
                this.x = x;
                this.y = y;
                this.val = val;
            }

            public int CompareTo(Location other)
            {
                //依次按x y val进行多关键字排序

                if (x != other.x)
                {
                    return x.CompareTo(other.x);
                }

                if (y != other.y)
                {
                    return y.CompareTo(other.y);
                }

                return val.CompareTo(other.val);
            }
        }


        private List<Location> locations = new List<Location>();

        public IList<IList<int>> VerticalTraversal(TreeNode root)
        {
            PreOrder(root, 0,0);

            locations.Sort();

            List<IList<int>> ans = new List<IList<int>>();
            ans.Add(new List<int>());

            //上一个元素的x坐标
            int prev = locations[0].x;

            for (int i = 0; i < locations.Count; i++)
            {
                Location loc = locations[i];

                if (loc.x != prev)
                {
                    //开始遍历新的x坐标的元素
                    //放入一个新列表
                    prev = loc.x;
                    ans.Add(new List<int>());
                }

                ans[ans.Count - 1].Add(loc.val);
            }

            return ans;
        }

        private void PreOrder(TreeNode root,int x,int y)
        {
            if (root == null)
            {
                return;
            }

            locations.Add(new Location(x, y, root.val));

            PreOrder(root.left,x - 1,y + 1);
            PreOrder(root.right,x + 1,y + 1);
        }

    }
}
