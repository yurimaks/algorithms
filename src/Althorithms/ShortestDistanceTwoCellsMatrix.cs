using System.Collections.Generic;
using Xunit;

namespace Althorithms
{
    //BFS - shortest distance
    public class ShortestDistanceTwoCellsMatrix
    {
        public static IEnumerable<object[]> TestData => new List<object[]>
        {
            new object[]
            {
                new char[][] {
                    new[]{'s','0','d'}
                },
                -1
            },
            new object[]
            {
                new char[][] {
                    new[]{'s','*','d'}
                },
                2
            },
            new object[]
            {
                new char[][] {
                    new[]{'s','*','*','*','*','*'}, 
                    new[]{'0','0','0','0','0','*'}, 
                    new[]{'*','*','*','*','*','*'},
                    new[]{'*','0','0','0','0','0'},
                    new[]{'*','*','*','*','*','*'},
                    new[]{'0','0','0','0','0','*'},
                    new[]{'*','*','*','*','*','*'},
                    new[]{'*','0','0','0','0','0'},
                    new[]{'*','*','*','*','*','d'}
                },
                33
            },
            new object[]
            {
                new char[][] {
                    new[]{'0','s','*','*'}, 
                    new[]{'0','0','0','*'}, 
                    new[]{'0','0','0','*'},
                    new[]{'d','*','*','*'}
                },
                8
            },
            new object[]
            {
                new char[][] {
                    new[]{'0','*','0','s'}, 
                    new[]{'*','0','*','*'}, 
                    new[]{'0','*','*','*'},
                    new[]{'d','*','*','*'}
                },
                6
            },
            new object[]
            {
                new char[][] {
                    new[]{'0','*','0','s'}, 
                    new[]{'*','0','*','*'}, 
                    new[]{'0','*','*','*'},
                    new[]{'d','0','0','0'}
                },
                -1
            }
        };
        
        private static readonly (int, int)[] _directions = new (int, int)[]
        {
            (0, 1),  //right
            (0, -1), //left
            (1, 0),  //down
            (-1, 0), //up
        };

        private static int _matrixHeight;
        private static int _matrixWidth;
        
        [Theory]
        [MemberData(nameof(TestData))]
        public void Run(char[][] matrix, int expected)
        {
            var shortedPath = GetShortestDistance(matrix);

            Assert.Equal(expected, shortedPath);
        }


        private static int GetShortestDistance(char[][] matrix)
        {
            _matrixHeight = matrix.Length;
            _matrixWidth = matrix[0].Length;
            
            (int row, int col, int distance) movingPoint = (0,0,0);
            
            bool[,] visited = new bool[matrix.Length, matrix[0].Length];
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[0].Length; col++)
                {
                    if (matrix[row][col] == '0')
                    {
                        visited[row, col] = true;
                    }
                    else
                    {
                        visited[row, col] = false;
                    }

                    if (matrix[row][col] == 's')
                    {
                        movingPoint.row = row;
                        movingPoint.col = col;
                    }
                    
                }
            }

            Queue<(int row, int col, int distance)> queue = new Queue<(int, int, int)>();
            queue.Enqueue(movingPoint);

            visited[movingPoint.row, movingPoint.col] = true;

            while (queue.Count > 0)
            {
                (int row, int col, int distance) point = queue.Dequeue();

                if (matrix[point.row][point.col] == 'd')
                {
                    return point.distance;
                }

                foreach ((int row, int col, int distance) neighbor in ClosestNeighbors(point, visited))
                {
                    queue.Enqueue((neighbor.row, neighbor.col, neighbor.distance + 1));
                    visited[neighbor.row, neighbor.col] = true;
                }
            }

            return -1;
        }

        private static IEnumerable<(int, int, int)> ClosestNeighbors((int row, int col, int distance) point, bool[,] visited)
        {
            foreach ((int dRow, int dCol) direction in _directions)
            {
                int newRow = direction.dRow + point.row;
                int newCol = direction.dCol + point.col;
                
                if (newRow >= 0 && newRow < _matrixHeight &&
                    newCol >=0 && newCol < _matrixWidth &&
                    visited[newRow, newCol] == false)
                {
                    yield return (newRow, newCol, point.distance);
                }
            }
        }
    }
}