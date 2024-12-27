namespace LeetCode._006ZigzagConversion
{    
    public class Solution
    {
        #region Methods
        public string Convert(string s, int numRows)
        {
            var l = s.Length;
            var numCols = l / numRows + (l % numRows == 0 ? 0 : 1);

            short xPos = 1;
            short yPos = 1;
            var isGoingDown = true;

            var charIndexCoordinateList = new List<CharIndexCoordinate>(l);
            var resultCharArray = new char[l];

            for (var i = 0; i < l; i++)
            {
                charIndexCoordinateList.Add(new CharIndexCoordinate
                {
                    Char = s[i],
                    X = xPos,
                    Y = yPos
                });

                if (isGoingDown)
                {
                    if (yPos + 1 > numRows)
                    {
                        isGoingDown = false;
                        xPos++;
                        if (yPos - 1 > 0)
                        {
                            yPos--;
                        }
                    }
                    else
                    { 
                        yPos++;
                    }
                }
                else
                {
                    if (yPos - 1 < 1)
                    {
                        isGoingDown = true;
                        xPos++;
                        if (yPos + 1 <= numRows)
                        {
                            yPos++;
                        }
                    }
                    else
                    {
                        yPos--;
                    }
                }                
            }

            short resultIndex = -1;
            for (var i = 1; i < l + 1; i++)
            {
                foreach(var charIndexCoordinate in charIndexCoordinateList)
                {
                    if(charIndexCoordinate.Y == i)
                    {
                        resultCharArray[++resultIndex] = charIndexCoordinate.Char;
                    }
                }
            }

            return new string(resultCharArray);
        }
        #endregion

        #region Nested Classes
        public class CharIndexCoordinate
        {
            #region Properties
            public char Char { get; set; }
            public short X { get; set; }
            public short Y { get; set; }
            #endregion

            public override string ToString()
            {
                return $"{Char} - {X},{Y}";
            }
        }
        #endregion
    }
}
