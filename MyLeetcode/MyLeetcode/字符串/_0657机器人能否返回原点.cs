using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.字符串
{
    //https://leetcode-cn.com/problems/robot-return-to-origin/
    class _0657机器人能否返回原点
    {
        public bool JudgeCircle(string moves)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            dict.Add('R', 0);
            dict.Add('L', 0);
            dict.Add('U', 0);
            dict.Add('D', 0);

            for (int i = 0; i < moves.Length; i++)
            {
                char c = moves[i];
                dict[c] += 1;
            }
            //RL次数相同 UD次数相同 机器人才会返回原点
            return dict['R'] == dict['L'] && dict['U'] == dict['D'];
        }

        public bool JudgeCircle2(string moves)
        {
            int h = 0; //水平轴偏移

            int v = 0; //垂直轴偏移

            for (int i = 0; i < moves.Length; i++)
            {
                char c = moves[i];

                switch (c)
                {
                    case 'R':
                        h++;
                        break;
                    case 'L':
                        h--;
                        break;
                    case 'U':
                        v++;
                        break;
                    case 'D':
                        v--;
                        break;
                }
            }

            return h == 0 && v == 0;
        }
    }
}
