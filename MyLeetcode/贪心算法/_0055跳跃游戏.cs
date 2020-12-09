using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.贪心算法
{
    //https://leetcode-cn.com/problems/jump-game/

    class _0055跳跃游戏
    {
        public bool CanJump(int[] nums)
        {

            int rightmost = 0;  //最远可以到达的位置

            for (int i = 0; i < nums.Length; i++)
            {
                if (i <= rightmost)
                {
                    //在最远可以到达的位置之内

                    rightmost = Math.Max(rightmost, i + nums[i]);  //尝试更新最远位置

                    if (rightmost >= nums.Length - 1)
                    {
                        //最远位置可以到达终点
                        return true;
                    }
                }
            }

            return false;

        }
    }
}
