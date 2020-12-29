using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.设计
{
    class _0380常数时间插入删除和获取随机元素
    {
        public class RandomizedSet
        {
            //key 元素 ,value 该元素在list中的坐标
            private Dictionary<int, int> dict = new Dictionary<int, int>();

            //存储所有元素
            private List<int> list = new List<int>();

            private Random random = new Random();

            /** Initialize your data structure here. */
            public RandomizedSet()
            {

            }

            /** Inserts a value to the set. Returns true if the set did not already contain the specified element. */
            public bool Insert(int val)
            {
                if (dict.ContainsKey(val))
                {
                    return false;
                }

                list.Add(val);
                int index = list.Count - 1;

                dict.Add(val, index);

                return true;
            }

            /** Removes a value from the set. Returns true if the set contained the specified element. */
            public bool Remove(int val)
            {
                if (!dict.ContainsKey(val))
                {
                    return false;
                }

                //将末尾元素复制到index处 然后删除末尾
                int index = dict[val];
                int lastVal = list[list.Count - 1];

                list[index] = lastVal;
                dict[lastVal] = index;  //更新新位置

                dict.Remove(val);
                list.RemoveAt(list.Count - 1);

                return true;
            }

            /** Get a random element from the set. */
            public int GetRandom()
            {
                int randomIndex = random.Next(list.Count);
                return list[randomIndex];
            }
        }

        /**
         * Your RandomizedSet object will be instantiated and called as such:
         * RandomizedSet obj = new RandomizedSet();
         * bool param_1 = obj.Insert(val);
         * bool param_2 = obj.Remove(val);
         * int param_3 = obj.GetRandom();
         */
    }
}
