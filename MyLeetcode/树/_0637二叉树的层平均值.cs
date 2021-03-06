﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/average-of-levels-in-binary-tree/

    class _0637二叉树的层平均值
    {

        public IList<double> AverageOfLevels(TreeNode root)
        {
            IList<IList<int>> result = LevelOrder(root);
            List<double> averages = new List<double>(result.Count);

            for (int i = 0; i < result.Count; i++)
            {
                double average = GetAverage(result[i]);
                averages.Add(average);
            }

            return averages;
        }

        private IList<IList<int>> LevelOrder(TreeNode root)
        {
            List<IList<int>> result = new List<IList<int>>();
            if (root == null)
            {
                return result;
            }
            Queue<TreeNode> queue1 = new Queue<TreeNode>();
            Queue<TreeNode> queue2 = new Queue<TreeNode>();

            queue1.Enqueue(root);

            while (queue1.Count > 0)
            {
                List<int> list = new List<int>();
                result.Add(list);

                //把queue1里的所有node都出队，并把它们的子节点都暂时放进queue2里
                while (queue1.Count > 0)
                {
                    TreeNode node = queue1.Dequeue();
                    list.Add(node.val);
                    if (node.left != null)
                    {
                        queue2.Enqueue(node.left);
                    }
                    if (node.right != null)
                    {
                        queue2.Enqueue(node.right);
                    }
                }


                //把queue2里的所有node都放进queue1中
                while (queue2.Count > 0)
                {
                    queue1.Enqueue(queue2.Dequeue());
                }
            }

            return result;

        }

        /// <summary>
        /// 求平均值
        /// </summary>
        private double GetAverage(IList<int> source)
        {
            double sum = 0;
            for (int i = 0; i < source.Count; i++)
            {
                sum += source[i];
            }

            sum /= source.Count;

            return sum;
        }
    }
}
