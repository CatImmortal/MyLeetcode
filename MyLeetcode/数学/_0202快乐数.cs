using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.数学
{
    class _0202快乐数
    {
        //https://leetcode-cn.com/problems/happy-number/

        

        public bool IsHappy(int n)
        {

            HashSet<int> set = new HashSet<int>();

            int num = n;
            int sum = 0;

            while (true)
            {
                int pop = num % 10;  //取num最后一位
                num /= 10;  //抹掉num最后一位

                sum += pop * pop;  //累加该位的平方

                if (num == 0)
                {
                    if (sum == 1)
                    {
                        //num的各位的平方和为1 是快乐数
                        return true;
                    }
                    else
                    {
                        if (set.Contains(sum))
                        {
                            //会无限循环 但始终不到1
                            return false;
                        }
                        else
                        {
                            set.Add(sum);

                            //替换为各位的平方和
                            num = sum;
                            sum = 0;
                        }
                    }
                }

                
            }
        }

        public bool IsHappy2(int n)
        {
            //快慢指针判断环的解法

            int p1 = n;
            int p2 = n;

            do
            {
                //慢指针走1步
                p1 = BitSquareSum(p1);

                //快指针走2步
                p2 = BitSquareSum(p2);
                p2 = BitSquareSum(p2);

            } while (p1 != p2);

            return p1 == 1;
        }

        private int BitSquareSum(int n)
        {
            int sum = 0;
            while (n > 0)
            {
                int bit = n % 10;
                sum += bit * bit;
                n = n / 10;
            }
            return sum;
        }
    }
}
