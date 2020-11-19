using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.哈希表
{
    //https://leetcode-cn.com/problems/top-k-frequent-elements/

    class _0347前K个高频元素
    {
        struct Counter : IComparable<Counter>
        {
            public int num;
            public int count;

            public Counter(int num,int count)
            {
                this.num = num;
                this.count = count;
            }

            public int CompareTo(Counter other)
            {
                if (count == other.count)
                {
                    return 0;
                }

                if (count > other.count)
                {
                    return -1;
                }

                return 1;
            }
        }

        public int[] TopKFrequent(int[] nums, int k)
        {
            int[] ans = new int[k];

            //数字与其计数器的字典
            Dictionary<int, Counter> dict = new Dictionary<int, Counter>();

            for (int i = 0; i < nums.Length; i++)
            {
                int num = nums[i];

                if (!dict.ContainsKey(num))
                {
                    dict[num] = new Counter(num,0);
                }

                Counter counter = dict[num];
                counter.count += 1;
                dict[num] = counter;
            }

            Counter[] counters = dict.Values.ToArray();
            Array.Sort(counters);  //根据出现次数排序

            //取couters前k个返回
            for (int i = 0; i < k; i++)
            {
                ans[i] = counters[i].num;
            }

            return ans;
        }

        public int[] TopKFrequent2(int[] nums, int k)
        {
            //桶排序解法

            List<int> ans = new List<int>(k);

            //数字与其出现次数的字典
            Dictionary<int, int> dict = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                int num = nums[i];

                if (!dict.ContainsKey(num))
                {
                    dict[num] = 0;
                }

                dict[num] += 1;
            }

            //桶列表
            List<int>[] lists = new List<int>[nums.Length + 1];

            foreach (var item in dict)
            {
                int num = item.Key;
                int count = item.Value;

                if (lists[count] == null)
                {
                    lists[count] = new List<int>();
                }

                //根据出现次数装进对应桶下标里
                lists[count].Add(num);
            }

            for (int i = lists.Length - 1; i >= 0; i--)
            {
                if (lists[i] == null)
                {
                    continue;
                }

                List<int> list = lists[i];
                for (int j = 0; j < list.Count && ans.Count < k; j++)
                {
                    ans.Add(list[j]);
                }
            }

            return ans.ToArray();

        }
    }
}
