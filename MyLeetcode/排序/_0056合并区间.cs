using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.排序
{
    //https://leetcode-cn.com/problems/merge-intervals/

    class _0056合并区间
    {
        public int[][] Merge(int[][] intervals)
        {
            //以首元素为基准，排序二维数组
            Array.Sort(intervals,(x,y) => { return x[0] - y[0]; });


            int[][] merged = new int[intervals.Length][];

            for (int i = 0; i < intervals.Length; i++)
            {
                merged[i] = new int[2];
            }


            int last = -1;

            foreach (int[] interval in intervals)
            {
                
                
                if (last == -1 || interval[0] > merged[last][1])
                {
                    //如果当前区间是遍历的第一个区间(last == -1)，或者左端点在数组 merged 中最后一个区间的右端点之后（interval[0] > merged[last][1]）
                    //那么它们不会重合，我们可以直接将这个区间加入数组 merged 的末尾；
                    last++;
                    merged[last] = interval;
                    
                }
                else
                {
                    //否则，它们重合，我们需要用当前区间的右端点更新数组 merged 中最后一个区间的右端点，将其置为二者的较大值。
                    merged[last][1] = Math.Max(interval[1], merged[last][1]);
                }
            }

            int[][] ans = new int[last + 1][];

            Array.Copy(merged, ans, last + 1);

            return ans;
        }
    }
}
