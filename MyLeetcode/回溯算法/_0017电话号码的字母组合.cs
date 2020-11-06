using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.回溯算法
{
    //https://leetcode-cn.com/problems/letter-combinations-of-a-phone-number/

    class _0017电话号码的字母组合
    {
        private string[] letterMap = { " ", "*", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };

        List<string> ans = new List<string>();

        public IList<string> LetterCombinations(string digits)
        {
            if (string.IsNullOrEmpty(digits))
            {
                return ans;
            }

            IterStr(digits, new StringBuilder(), 0);

            return ans;
        }

        private void IterStr(string str, StringBuilder sb, int index)
        {
            if (index == str.Length)
            {
                //递归到头了
                ans.Add(sb.ToString());
                return;
            }

            //获取到数字字符对应的英文字符串
            int pos = str[index] - '0';
            string mapStr = letterMap[pos];

            //遍历这个英文字符串
            for (int i = 0; i < mapStr.Length; i++)
            {
                sb.Append(mapStr[i]);

                //对于这个英文字符串中的每个字符 递归到下一层
                IterStr(str, sb, index + 1);

                //递归完成后删掉sb的末尾字符 方便同一层的后续字符使用sb
                sb.Remove(sb.Length - 1, 1);
            }
        }

        public IList<string> LetterCombinations2(string digits)
        {
            //基于队列的解法
            if (string.IsNullOrEmpty(digits))
            {
                return ans;
            }

            Queue<string> queue = new Queue<string>();
            queue.Enqueue("");

            for (int i = 0; i < digits.Length; i++)
            {
                //获取当前数字字符对应的英文字符串
                string letters = letterMap[digits[i] - '0'];

                //计算出队列当前长度后，将队列中的每个元素挨个拿出来
                int size = queue.Count;
                for (int j = 0; j < size; j++)
                {
                    string temp = queue.Dequeue();

                    //然后跟当前数字字符对应的英文字符串的每一个字符拼接，并再次放到队列中
                    for (int k = 0; k < letters.Length; k++)
                    {
                        queue.Enqueue(temp + letters[k]);
                    }
                }
            }

            while (queue.Count > 0)
            {
                ans.Add(queue.Dequeue());
            }

            return ans;
        }
    }
}
