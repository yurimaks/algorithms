using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace LeetCode._51._60
{
    //BFS - distance to cell
    public class Task542_clean
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public Task542_clean(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }
        
        public static IEnumerable<object[]> TestData => new List<object[]>
        {
            new object[]
            {
                new int[][] {new[]{0,0,0}, new[]{0,1,0}, new[]{0,0,0}},
                new int[][] {new[]{0,0,0}, new[]{0,1,0}, new[]{0,0,0}}
                
            },
            new object[]
            {
                new int[][] {new[]{0,0,0}, new[]{0,1,0}, new[]{1,1,1}},
                new int[][] {new[]{0,0,0}, new[]{0,1,0}, new[]{1,2,1}}
            },
            new object[]
            {
                new int[][] {new[]{1,1,0}, new[]{1,1,1}, new[]{1,1,1}},
                new int[][] {new[]{2,1,0}, new[]{3,2,1}, new[]{4,3,2}}
            }
        };
        
        [Theory]
        [MemberData(nameof(TestData))]
        public void Run(int[][] matrix, int[][] expected)
        {
            var actual1 = UpdateMatrix_BSF(matrix);
            Assert.Equal(expected, actual1);
        }

        private static readonly (int, int)[] Directions = { 
            (0, 1), //right
            (0, -1), //left
            (1, 0), //bottom
            (-1, 0) //up
        };
        
        private static int _rowLength;
        private static int _colLength;
        
        public int[][] UpdateMatrix_BSF(int[][] matrix)
        {
            _rowLength = matrix.Length;
            _colLength = matrix[0].Length;

            var visited = new bool[matrix.Length, matrix[0].Length];
            
            var queue = new Queue<(int, int)>(); 
            for (var row = 0; row < matrix.Length; row++)
            {
                for (var col = 0; col < matrix[0].Length; col++)
                {
                    if (matrix[row][col] == 0)
                    {
                        queue.Enqueue((row, col));
                        visited[row,col] = true;
                    }
                }
            }
            
            while (queue.Count > 0)
            {
                var (row, col) = queue.Dequeue();
                foreach (var (r, c) in GetValidNbs(row, col, visited))
                {
                    matrix[r][c] = matrix[row][col] + 1;
                    visited[r, c] = true;
                    queue.Enqueue((r, c));
                }
            }
            
            return matrix;
        }

        private static IEnumerable<(int, int)> GetValidNbs(int row, int col, bool[,] visited)
        {
            foreach (var (r, c) in Directions)
            {
                var (nR, nC) = (r + row, c + col);

                if (nR >= 0 && nR < _rowLength &&
                    nC >= 0 && nC < _colLength &&
                    !visited[nR, nC])
                {
                    yield return (nR, nC);
                }
            }
        }
    }
}