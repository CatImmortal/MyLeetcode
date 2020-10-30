using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.数组
{
    //https://leetcode-cn.com/problems/pascals-triangle/

    class _0118杨辉三角
    {
        public IList<IList<int>> Generate(int numRows)
        {


            List<IList<int>> ans = new List<IList<int>>(numRows);

            if (numRows == 0)
            {
                return ans;
            }

            ans.Add(new List<int> { 1 });

            for (int i = 2; i <= numRows; i++)
            {
                //上一行的列表索引
                int index = i - 2;

                //第i行，需要添加i个元素
                List<int> list = new List<int>(i);

                for (int j = 0; j < i; j++)
                {
                    if (j == 0 || j == i - 1)
                    {
                        //首尾元素固定为1
                        list.Add(1);
                    }
                    else
                    {
                        //中间元素 根据上一行的元素得到

                        int left = ans[index][j - 1];
                        int right = ans[index][j];

                        list.Add(left + right);
                        
                    }
                }

                ans.Add(list);
            }

            return ans;
        }
        
    }
}
