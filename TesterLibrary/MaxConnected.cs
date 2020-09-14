using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace TesterLibrary
{
    public class MaxConnected
    {

        //public int GetMaxConnected(int[][] grid)
        //{
        //    int maxCount = 0;
        //    bool[,] visited = new bool[grid.Length, grid[0].Length];

        //    for(var x = 0; x <= grid.Length; x++)
        //    {
        //        for(var y = 0; y <= grid[0].Length; y++)
        //        {

        //        }
        //    }
        //}

 



        private List<(int x, int y)> GetNeighbors(int[][] grid, int x, int y)
        {
            var coordinates = new List<(int x, int y)>();

            (int x, int y)[] neighbors =
            {
                (-1,  0),
                ( 0, -1),
                ( 1,  0),
                ( 0,  1)
            };

            foreach(var n in neighbors)
            {
                var newX = x + n.x;
                var newY = x + n.y;

                if (newX < 0 || newY < 0
                    || newX >= grid.Length
                    || newY >= grid[0].Length)
                    continue;

                coordinates.Add((newX, newY));
            }

            return coordinates;
        }


    }
}
