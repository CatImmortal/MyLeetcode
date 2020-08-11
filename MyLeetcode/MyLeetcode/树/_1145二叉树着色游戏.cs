using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/binary-tree-coloring-game/

    class _1145二叉树着色游戏
    {
        private int redLeftNum = 0;
        private int redRightNum = 0;
        private int x = 0;
        public bool BtreeGameWinningMove(TreeNode root, int n, int x)
        {
            this.x = x;

            PostOrder(root);

            //节点总数量的一半
            int half = n / 2;

            if (redLeftNum > half || redRightNum > half || (redLeftNum + redRightNum) < half)
            {
                //红色节点的左子节点 右子节点 父节点 任意一边构成的子树节点数量大于一半
                //即可胜利
                return true;
            }

            return false ;   
        }

        private int PostOrder(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            int leftNum = PostOrder(root.left);
            int rightNum = PostOrder(root.right);

            if (root.val == x)
            {
                //记录红色节点的左右子树数量
                redLeftNum = leftNum;
                redRightNum = rightNum;
            }

            //返回该子树所有节点数量
            return leftNum + rightNum + 1;
        }
    }
}
