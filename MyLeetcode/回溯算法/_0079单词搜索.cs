using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.回溯算法
{
    //https://leetcode-cn.com/problems/word-search/

    class _0079单词搜索
    {

        public bool Exist(char[][] board, string word)
        {
            if (string.IsNullOrEmpty(word))
            {
                return true;
            }

            if (board == null || board.Length == 0)
            {
                return false;
            }

            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    if (board[i][j] == word[0])
                    {
                        //从 i j位置开始检查
 

                        if (Dfs(board,word,0,i,j))
                        {
                            return true;
                        }
                    }
                }
            }

            //不存在word
            return false;

        }

        private bool Dfs(char[][] board, string word,int wordIndex,int i,int j)
        {
            
            if (wordIndex >= word.Length)
            {
                //到头了
                return true;    
            }

            if (i < 0 || j < 0 || i >= board.Length || j >= board[i].Length)
            {
                //越界判断
                return false;
            }

            if (word[wordIndex] != board[i][j])
            {
                //i j位置上的 不是对应字符
                return false;
            }

            char cachedChar = board[i][j];
            board[i][j] = '0';

            if (Dfs(board, word, wordIndex + 1, i + 1, j)
             || Dfs(board, word, wordIndex + 1, i - 1, j)
             || Dfs(board, word, wordIndex + 1, i, j - 1)
             || Dfs(board, word, wordIndex + 1, i, j + 1)
             )
            {
                //回溯
                board[i][j] = cachedChar;
                return true;
            }

            //回溯
            board[i][j] = cachedChar;
            return false;
        }
    }
}
