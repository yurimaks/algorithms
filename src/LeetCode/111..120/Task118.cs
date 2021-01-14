using System.Collections.Generic;
using Xunit;

namespace LeetCode._81._90
{
    public class Task118
    {
        public static IEnumerable<object[]> TestData => new List<object[]>
        {
            new object[] { -2, new int[][] {new int[] { 1 }}},
            new object[] { 1, new int[][] {new int[] { 1 }}},
            new object[] { 2, new int[][]
                {
                    new int[] { 1 },
                    new int[] { 1, 1 }
                }},
            new object[] { 3, new int[][]
            {
                new int[] { 1 },
                new int[] { 1, 1 },
                new int[] { 1, 2, 1 }
            }},
            new object[] { 4, new int[][]
            {
                new int[] { 1 },
                new int[] { 1, 1 },
                new int[] { 1, 2, 1 },
                new int[] { 1, 3, 3, 1 }
            }}
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Run(int numRows, IList<IList<int>> expected)
        {
            var actual = Generate(numRows);
            Assert.Equal(actual, expected);
        }

        public IList<IList<int>> Generate(int numRows)
        {
            IList<IList<int>> triangle = new List<IList<int>>();

            if (numRows == 0) return triangle;
        
            IList<int> initRow = new List<int>();
            initRow.Add(1);
            triangle.Add(initRow);
        
            for (int i = 1; i < numRows; i++)
            {            
                IList<int> row = new List<int>();
                IList<int> lastRow = triangle[i - 1];
                for (int j = 0; j <= i - 1; j++)
                {
                    int lastRow_prelast_cell = (j - 1 < 0) ? 0 : lastRow[j - 1];
                    int lastRow_last_cell =    (j < 0) ? 0 : lastRow[j];
                    row.Add(lastRow_prelast_cell + lastRow_last_cell);
                }
                row.Add(1);
                triangle.Add(row);
            }

            return triangle;
        }
    }
}