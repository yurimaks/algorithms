using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace LeetCode._51._60
{
    //https://www.youtube.com/watch?v=luUo7hqLgw0
    public class Task542
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public Task542(ITestOutputHelper testOutputHelper)
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
            
            var actual2 = UpdateMatrix_BruteForce(matrix);
            Assert.Equal(expected, actual2);
        }

        #region BFS
        private readonly struct Coordinate
        {
            public Coordinate(int row, int col)
            {
                Row = row;
                Col = col;
            }
            
            public int Row { get; }
            public int Col { get; }
        }

        private static readonly Coordinate[] _directions = { 
            new Coordinate(0, 1), //right
            new Coordinate(0, -1), //left
            new Coordinate(1, 0), //bottom
            new Coordinate(-1, 0) //up
        };
        
        public int[][] UpdateMatrix_BSF(int[][] matrix)
        {
            //1.
            
            // //O (row * col * row * col)
            // //Do BFS O(row*col) for each 1
            // for (int row = 0; row < matrix.Length; row++)
            // {
            //     for (int col = 0; col < matrix[0].Length; col++)
            //     {
            //         if (matrix[row][col] == 1)
            //         {
            //             matrix[row][col] = Bfs(matrix, row, col);
            //         }
            //     }
            // }

            //2.

            // var queue = new Queue<Coordinate>(); 
            // for (int row = 0; row < matrix.Length; row++)
            // {
            //     for (int col = 0; col < matrix[0].Length; col++)
            //     {
            //         if (matrix[row][col] == 0)
            //         {
            //             queue.Enqueue(new Coordinate(row, col));
            //         }
            //         else
            //         {
            //             matrix[row][col] = int.MaxValue;
            //         }
            //     }
            // }
            
            // while (queue.Count > 0)
            // {
            //     var c = queue.Dequeue();
            //     foreach (var coordinate in GetValidNbs(c, matrix.Length, matrix[0].Length))
            //     {
            //         if (matrix[coordinate.Row][coordinate.Col] > matrix[c.Row][c.Col] + 1)
            //         {
            //             matrix[coordinate.Row][coordinate.Col] = matrix[c.Row][c.Col] + 1;
            //             queue.Enqueue(coordinate);
            //         }
            //     }
            // }
            
            //3.
            // bool[][] visited = new bool[matrix.Length][];
            // for (int i = 0; i < matrix.Length; i++)
            // {
            //     visited[i] = Enumerable.Repeat(false, matrix[0].Length).ToArray();
            // }

            _RowLength = matrix.Length;
            _ColLength = matrix[0].Length;

            var visited = new bool[matrix.Length, matrix[0].Length];
            
            var queue = new Queue<Coordinate>(); 
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[0].Length; col++)
                {
                    if (matrix[row][col] != 0) continue;
                    queue.Enqueue(new Coordinate(row, col));
                    visited[row,col] = true;
                }
            }
            
            while (queue.Count > 0)
            {
                var cord = queue.Dequeue();
                foreach (var coordinate in GetValidNbs(cord, visited))
                {
                    matrix[coordinate.Row][coordinate.Col] = matrix[cord.Row][cord.Col] + 1;
                    visited[coordinate.Row, coordinate.Col] = true;
                    queue.Enqueue(coordinate);
                }
            }
            
            return matrix;
        }

        private static int _RowLength;
        private static int _ColLength;

        //from 1 -> 0
        private static int Bfs(int[][] matrix, int row, int col)
        {
            int matrixRowLength = matrix.Length;
            int matrixColLength = matrix[0].Length;

            IDictionary<Coordinate, int> coordinateDistanceDict = new Dictionary<Coordinate, int>();
            
            var baseCoordinate = new Coordinate(row, col);
            coordinateDistanceDict[baseCoordinate] = 0;
                
            Queue<(Coordinate, int)> bfs = new Queue<(Coordinate, int)>();
            bfs.Enqueue((baseCoordinate, 0));

            while (bfs.Count > 0)
            {
                var coordinate = bfs.Dequeue();
                coordinateDistanceDict.Remove(coordinate.Item1);
                    
                if (matrix[coordinate.Item1.Row][coordinate.Item1.Col] == 0)
                {
                    return coordinate.Item2;
                }
                
                foreach ((Coordinate, int) nb in GetValidNbs(coordinate, matrixRowLength, matrixColLength))
                {
                    if (!coordinateDistanceDict.ContainsKey(nb.Item1))
                    {
                        coordinateDistanceDict[nb.Item1] = nb.Item2;
                        bfs.Enqueue(nb);
                    }
                    else
                    {
                        coordinateDistanceDict[nb.Item1] = Math.Min(coordinateDistanceDict[nb.Item1], nb.Item2);
                    }
                }
            }

            return matrix[row][col];
        }

        private static IEnumerable<Coordinate> GetValidNbs(Coordinate cord, bool[,] visited)
        {
            foreach (var direction in _directions)
            {
                var nb = new Coordinate(direction.Row + cord.Row, direction.Col + cord.Col);

                if (nb.Row >= 0 && nb.Row < _RowLength &&
                    nb.Col >= 0 && nb.Col < _ColLength &&
                    !visited[nb.Row, nb.Col])
                {
                    yield return nb;
                }
            }
        }
        
        private static IEnumerable<Coordinate> GetValidNbs(Coordinate cord, int matrixRowLength, int matrixColLength)
        {
            foreach (var direction in _directions)
            {
                var nb = new Coordinate(direction.Row + cord.Row, direction.Col + cord.Col);

                if (nb.Row >= 0 && nb.Row < matrixRowLength &&
                    nb.Col >= 0 && nb.Col < matrixColLength)
                {
                    yield return nb;
                }
            }
        }
        
        private static IEnumerable<(Coordinate, int)> GetValidNbs((Coordinate, int) baseCord, int matrixRowLength, int matrixColLength)
        {
            foreach (var direction in _directions)
            {
                var nb = (new Coordinate(direction.Row + baseCord.Item1.Row, direction.Col + baseCord.Item1.Col), baseCord.Item2 + 1);

                if (nb.Item1.Row >= 0 && nb.Item1.Row < matrixRowLength &&
                    nb.Item1.Col >= 0 && nb.Item1.Col < matrixColLength)
                {
                    yield return nb;
                }
            }
        }

        #endregion
        
        public int[][] UpdateMatrix_BruteForce(int[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[0].Length; col++)
                {
                    if (matrix[row][col] == 1)
                    {
                        matrix[row][col] = int.MaxValue;
                        for (int r = 0; r < matrix.Length; r++)
                        {
                            for (int c = 0; c < matrix[0].Length; c++)
                            {
                                if (matrix[r][c] == 0)
                                {
                                    int dist = Math.Abs(row - r) + Math.Abs(col - c);
                                    matrix[row][col] = Math.Min(matrix[row][col], dist);
                                }
                            }
                        }
                    }
                }
            }

            return matrix;
        }
    }
}