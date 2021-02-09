using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace Althorithms
{
    //BFS - find shape
    public class FindRectangleTask
    {
        private readonly ITestOutputHelper _testOutput;

        public FindRectangleTask(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
        }
        
        private readonly int[][] image1 = new int[][]
        {
            new int[] {1, 1, 1, 1, 1, 1, 1},
            new int[] {1, 1, 1, 1, 1, 1, 1},
            new int[] {1, 1, 1, 0, 0, 0, 1},
            new int[] {1, 1, 1, 0, 0, 0, 1},
            new int[] {1, 1, 1, 1, 1, 1, 1}
        };

        private readonly int[][] image2 = new int[][]
        {
            new int[] {1, 1, 1, 1, 1, 1, 1},
            new int[] {1, 1, 1, 1, 1, 1, 1},
            new int[] {1, 1, 1, 1, 1, 1, 1},
            new int[] {1, 1, 1, 1, 1, 1, 1},
            new int[] {1, 1, 1, 1, 1, 1, 0}
        };
        private readonly int[][] image3 = new int[][]
        {
            new int[] {0, 1, 1, 1, 1, 1, 1},
            new int[] {1, 1, 1, 1, 1, 1, 1},
            new int[] {1, 1, 1, 0, 0, 0, 1},
            new int[] {1, 1, 1, 0, 0, 0, 1},
            new int[] {1, 1, 1, 1, 1, 1, 1}
        };
        private readonly int[][] image4 = new int[][]
        {
            new int[] {0},
        };

        private readonly int[][] image_multi1 = new int[][]
        {
            new int[] {0, 1, 1, 1, 1, 1, 1},
            new int[] {1, 1, 1, 1, 1, 1, 1},
            new int[] {1, 1, 1, 0, 0, 0, 1},
            new int[] {1, 0, 1, 0, 0, 0, 1},
            new int[] {1, 0, 1, 1, 1, 1, 1},
            new int[] {1, 0, 1, 0, 0, 1, 1},
            new int[] {1, 1, 1, 0, 0, 1, 1},
            new int[] {1, 1, 1, 1, 1, 1, 0}
        };
        
        
        private readonly int[][] image_differentShapes = new int[][]
        {
            new int[] {1, 0, 1, 1, 1, 1, 1},
            new int[] {1, 0, 0, 1, 0, 1, 1},
            new int[] {1, 1, 1, 0, 0, 0, 1},
            new int[] {1, 0, 1, 1, 0, 1, 1},
            new int[] {1, 0, 1, 1, 1, 1, 1},
            new int[] {1, 0, 0, 0, 0, 1, 1},
            new int[] {1, 1, 1, 0, 0, 1, 1},
            new int[] {1, 1, 1, 1, 1, 1, 0}
        };
        
        // private readonly int[][] image_differentShapes = new int[][]
        // {
        //     new int[] {1, 0, 1, },
        //     new int[] {1, 0, 0, },
        //     new int[] {1, 1, 1, },
        // };
        
        [Fact]
        public void Run()
        {
            // var rectangle1 = GetRectangles(image1).Single();
            // var rectangle2 = GetRectangles(image2).Single();
            // var rectangle3 = GetRectangles(image3).Single();
            // var rectangle4 = GetRectangles(image4).Single();
            //
            // var rectangle5 = GetRectangles(image_multi1);
            var rectangle6 = GetShapes(image_differentShapes);
            
            // PrintOut(rectangle1);
            // PrintOut(rectangle2);
            // PrintOut(rectangle3);
            // PrintOut(rectangle5);
             PrintOut(rectangle6);
           
        }

        private void PrintOut(Rectangle rectangle)
        {
            _testOutput.WriteLine($"# Row: {rectangle.Row}, Col: {rectangle.Col}, Width: {rectangle.Width}, Height: {rectangle.Height}");
        }
        
        private void PrintOut(IList<Rectangle> rectangles)
        {
            foreach (var rectangle in rectangles)
            {
                _testOutput.WriteLine($"# Row: {rectangle.Row}, Col: {rectangle.Col}, Width: {rectangle.Width}, Height: {rectangle.Height}");
            }
        }
        
        private void PrintOut(List<List<Coordinate>> shapes)
        {
            string[,] fields = new string[image_differentShapes.Length,image_differentShapes[0].Length];

            for (int i = 0; i < shapes.Count; i++)
            {
                for (int j = 0; j < shapes[i].Count; j++)
                {
                    fields[shapes[i][j].Row, shapes[i][j].Col] = "*";
                }
            }
            
            for (int i = 0; i < fields.GetLength(0); i++)
            {
                var sb = new StringBuilder();
                for (int j = 0; j < image_differentShapes[0].Length; j++)
                {
                    sb.Append(fields[i,j] ?? "-");
                }

                _testOutput.WriteLine(sb.ToString());
            }
        }
        
        private static int _rowLength;
        private static int _colLength;
        
        private List<List<Coordinate>> GetShapes(int[][]image)
        {
            _rowLength = image.Length;
            _colLength = image[0].Length;

            var queue = new Queue<Coordinate>();
            var visited = new bool[image.Length, image[0].Length];
            
            for (int row = 0; row < image.Length; row++)
            {
                for (int col = 0; col < image[0].Length; col++)
                {
                    if (image[row][col] == 1)
                    {
                        queue.Enqueue(new Coordinate(row, col));
                        visited[row, col] = true;
                    }
                }
            }

            var a = GetShapes(queue, visited);
            return a;
        }

        private List<List<Coordinate>> GetShapes(Queue<Coordinate> queue, bool[,] visited)
        {
            List<List<Coordinate>> shapes = new List<List<Coordinate>>();
            while (queue.Count > 0)
            {
                var coordinate = queue.Dequeue();
                var validNbs = GetValidNbs(coordinate.Row, coordinate.Col, visited).ToList();
                if (validNbs.Any())
                {
                    shapes.Add(GetShape(validNbs, visited));
                }
                visited[coordinate.Row, coordinate.Col] = true;
            }
            return shapes;
        }

        private List<Coordinate> GetShape(List<Coordinate> coordinates, bool[,] visited)
        {
            var share = new List<Coordinate>();
            if (!coordinates.Any()) return share;
            Queue<Coordinate> queue = new Queue<Coordinate>();
            coordinates.ForEach(queue.Enqueue);

            while (queue.Count > 0)
            {
                var coordinate = queue.Dequeue();
                
                share.Add(coordinate);
                visited[coordinate.Row, coordinate.Col] = true;
                
                var validNbs = GetValidNbs(coordinate.Row, coordinate.Col, visited).ToList();
                if (validNbs.Count > 0)
                {
                    validNbs.ForEach(queue.Enqueue);
                }
            }
            return share;
        }
        
        
        private static readonly (int, int)[] Directions = { 
            (0, 1), //right
            (0, -1), //left
            (1, 0), //bottom
            (-1, 0) //up
        };
        
        private static IEnumerable<Coordinate> GetValidNbs(int row, int col, bool[,] visited)
        {
            foreach (var (r, c) in Directions)
            {
                var (nR, nC) = (r + row, c + col);

                if (nR >= 0 && nR < _rowLength &&
                    nC >= 0 && nC < _colLength &&
                    !visited[nR, nC])
                {
                    yield return new Coordinate(nR, nC);
                }
            }
        }

        private static IList<Rectangle> GetRectangles(int[][] image)
        {
            var rectangles = new List<Rectangle>();
            for (int row = 0; row < image.Length; row++)
            {
                for (int col = 0; col < image[0].Length; col++)
                {
                    if (IsTopLeftCorner(image, row, col))
                    {
                        var rectangle = FindRectangle(image, row, col);
                        rectangles.Add(rectangle);
                    }
                }
            }

            return rectangles;
        }

        private static bool IsTopLeftCorner(int[][] image, int row, int col)
        {
            return image[row][col] == 0 && ((row == 0 || image[row - 1][col] == 1) && (col == 0 || image[row][col - 1] == 1));
        }
        
        private static Rectangle FindRectangle(int[][] image, int row, int col)
        {
            var rectangle = new Rectangle();

            rectangle.Row = row+1;
            rectangle.Col = col+1;
                    
            for (int rowY = row; rowY < image.Length && image[rowY][col] == 0; rowY++)
            {
                for (int colX = col; colX < image[0].Length && image[rowY][colX] == 0; colX++)
                {
                    rectangle.Width = colX-col+1;
                    rectangle.Height = rowY-row+1;
                }
            }

            return rectangle;
        }

        private class Coordinate
        {
            public Coordinate(int row, int col)
            {
                Row = row;
                Col = col;
            }
            
            public int Row { get; set; }
            public int Col { get; set; }
        }
        
        private class Rectangle
        {
            public int Row { get; set; }
            public int Col { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }
        }
        
    }
}