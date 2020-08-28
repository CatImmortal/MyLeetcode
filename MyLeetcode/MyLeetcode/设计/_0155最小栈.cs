using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.设计
{
    //https://leetcode-cn.com/problems/min-stack/

    class _0155最小栈
    {
        public class MinStack
        {
            private Stack<int> stack = new Stack<int>();
            private Stack<int> minStack = new Stack<int>();

            /** initialize your data structure here. */
            public MinStack()
            {

            }

            public void Push(int x)
            {
                stack.Push(x);

                //入栈时同时和辅助栈的栈顶元素比对
                if (minStack.Count == 0 || x <= minStack.Peek())
                {
                    minStack.Push(x);
                }
            }

            public void Pop()
            {
                int pop = stack.Pop();

                //要出栈的元素和辅助栈元素一样 出栈
                if (pop == minStack.Peek())
                {
                    minStack.Pop();
                }
            }

            public int Top()
            {
                return stack.Peek();
            }

            public int GetMin()
            {
                return minStack.Peek();
            }
        }
    }
}
