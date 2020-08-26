using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.二分查找
{
    class _0278第一个错误的版本
    {
        class VersionControl
        {
            protected bool IsBadVersion(int version)
            {
                return true;
            }
        }

        class Solution : VersionControl
        {
            public int FirstBadVersion(int n)
            {

                int left = 1;
                int right = n;

                while (left <= right)
                {
                    int mid = left + ((right - left) >> 1);

                    if (IsBadVersion(mid))
                    {
                        //是坏版本
                        if (mid == 0 || !IsBadVersion(mid - 1))
                        {
                            //是第一个版本 或者 上个版本是好版本 返回结果
                            return mid;
                        }
                        else
                        {
                            //不是第一个坏版本 修改右边界
                            right = mid - 1;
                        }
                    }
                    else
                    {
                        //是好版本

                        if (mid != n && IsBadVersion(mid + 1))
                        {
                            //不是最后一个版本 并且 下个版本是坏版本 返回结果
                            return mid + 1;
                        }
                        else
                        {
                            //不是最后一个好版本 修改左边界
                            left = mid + 1;
                        }
                    }
                }

                return -1;
            }

            public int FirstBadVersion2(int n)
            {
                //左右边界
                int left = 1;
                int right = n;

                while (left < right)
                {
                    int mid = left + ((right - left) >> 1);
                    if (IsBadVersion(mid))
                    {
                        //mid是坏版本
                        //mid+1 ... n 都不可能是第一个坏版本
                        //修改右边界
                        right = mid;
                    }
                    else
                    {
                        //mid是好版本
                        //1 ... mid 都不是坏版本
                        //修改左边界
                        left = mid + 1;
                    }
                }

                //left 和 right重合的结果就是第一个怀版本

                return left;


            }
        }
    }
}
