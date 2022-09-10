using System;
using System.Collections.Generic;
using System.Text;

namespace MyAlgorithm
{
    /// <summary>
    /// 547. 朋友圈
    /// https://leetcode-cn.com/problems/friend-circles
    /// </summary>
    public class B547_friend_circles
    {
        /// <summary>
        /// 并查集
        /// </summary>
        /// <param name="M"></param>
        /// <returns></returns>
        public int FindCircleNum(int[][] M)
        {
            int n = M.Length;

            UnionFind uf = new UnionFind(n);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (M[i][j] == 1)
                    {
                        uf.Union(i, j);
                    }
                }
            }

            return uf.Count;
        }

        public class UnionFind
        {
            // 连通分量个数
            public int Count { get; set; } = 0;
            // 存储一棵树
            private int[] Parent { get; set; }
            // 记录树的“重量”
            private int[] Size { get; set; }

            public UnionFind(int n)
            {
                Count = n;
                Parent = new int[n];
                Size = new int[n];
                for (int i = 0; i < n; i++)
                {
                    Parent[i] = i;
                    Size[i] = 1;
                }
            }

            /// <summary>
            /// 返回某个节点 x 的根节点  并压缩路径提高速度
            /// </summary>
            /// <param name="p"></param>
            /// <returns></returns>
            public int Find(int p)
            {
                while (p != Parent[p])
                {
                    //进行路径压缩
                    Parent[p] = Parent[Parent[p]];
                    p = Parent[p];
                }
                return p;
            }

            /// <summary>
            /// 一个节点的根节点接到另一个节点的根节点上 让2个节点连通
            /// </summary>
            /// <param name="p"></param>
            /// <param name="q"></param>
            public void Union(int p, int q)
            {
                int rootP = Find(p);
                int rootQ = Find(q);
                if (rootP == rootQ) return;
                // 小树接到大树下面，较平衡
                if (Size[rootP] > Size[rootQ])
                {
                    Parent[rootQ] = rootP;
                    Size[rootP] += Size[rootQ];
                }
                else
                {
                    Parent[rootP] = rootQ;
                    Size[rootQ] += Size[rootP];
                }
                Count--;
            }

            public bool Connected(int p, int q)
            {
                int rootP = Find(p);
                int rootQ = Find(q);
                return rootP == rootQ;
            }

        }



        /// <summary>
        /// 深度优先
        /// </summary>
        /// <param name="M"></param>
        /// <returns></returns>
        public int FindCircleNum2(int[][] M)
        {
            int[] visited = new int[M.Length];
            int count = 0;
            for (int i = 0; i < M.Length; i++)
            {
                if (visited[i] == 0)
                {
                    dfs(M, visited, i);
                    count++;
                }
            }
            return count;

            void dfs(int[][] M, int[] visited, int i)
            {
                for (int j = 0; j < M.Length; j++)
                {
                    if (M[i][j] == 1 && visited[j] == 0)
                    {
                        visited[j] = 1;
                        dfs(M, visited, j);
                    }
                }
            }
        }

    }




}
