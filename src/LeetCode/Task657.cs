using Xunit;

namespace LeetCode
{
    public class Task657
    {
        [Fact]
        public void Run()
        {
            var basa = JudgeCircle("UDLRUDLRUDLR");
            Assert.True(basa);
        }
        
        private readonly static (int, int)[] _directions = 
        {
            (1,0),  //down
            (-1,0), //up
            (0,1),  //right
            (0,-1)  //left
        };
    
        public bool JudgeCircle(string moves)
        {
            (int, int)[] traectory = MapToTraectory(moves);
        
            (int row, int col) coordinate = (0, 0);
            for(int i = 0; i < traectory.Length; i++)
            {
                (int row, int col) m = traectory[i];
                coordinate.row = coordinate.row + m.row;
                coordinate.col = coordinate.col + m.col;
            }
        
            return coordinate.row == 0 && coordinate.col == 0;
        }
    
        private static (int, int)[] MapToTraectory(string moves)
        {
            (int, int)[] traectory = new (int, int)[moves.Length];
        
            for (int i = 0; i < moves.Length; i++)
            {
                switch(moves[i])
                {
                    case 'D':
                    {
                        traectory[i] = _directions[0];
                        break;
                    }
                    case 'U':
                    {
                        traectory[i] = _directions[1];
                        break;
                    }
                    case 'R':
                    {
                        traectory[i] = _directions[2];
                        break;
                    }
                    case 'L':
                    {
                        traectory[i] = _directions[3];
                        break;
                    }                   
                }
            }
        
            return traectory;
        }
    }
}