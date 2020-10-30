using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.设计
{
    //https://leetcode-cn.com/problems/shuffle-an-array/

    class _0384打乱数组
    {
        public class Solution
        {
            Random r = new Random();
            private int[] original;
            private int[] random;
            public Solution(int[] nums)
            {
                original = new int[nums.Length];
                Array.Copy(nums, original,nums.Length);

                random = nums;
            }

            /** Resets the array to its original configuration and return it. */
            public int[] Reset()
            {
                Array.Copy(original, random, original.Length);
                return original;
            }

            /** Returns a random shuffling of the array. */
            public int[] Shuffle()
            {
                for (int i = 0; i < random.Length; i++)
                {
                    int index = r.Next(i, random.Length);

                    int temp = random[i];
                    random[i] = random[index];
                    random[index] = temp;
                }

                return random;
            }
        }
    }
}
