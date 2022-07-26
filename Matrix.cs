using static System.Console;
using System;
using System.Collections.Generic;

namespace Matrix_Calculator
{
    /**
     * <summary>Represents a Matrix.</summary>
     */
    public class Matrix
    {
        public int height;
        public int width;
        public double [,] arr;

        public Matrix(int h, int w)
        {
            height = h;
            width = w;
            arr = new double [h,w];
        }

        /**
         * <summary>True if Matrix is a square i.e if its height equals its width.</summary>
         */
        public bool isSquare()
        {
            return height == width;
        }

        /**
         * <summary>Reads lines from input and stores as Matrix rows.</summary>
         * <returns>Boolean value true if line read successfully or false if wrong size.</returns>
         */
        public bool read()
        {
            for (int i = 0 ; i < height ; i++)
            {
                string[] words = ReadLine().Trim().Split(null);
                if (words.Length != width)
                {
                    WriteLine();
                    WriteLine("Wrong matrix size");
                    return false;
                }
                for (int j = 0 ; j < width ; j++)
                {
                    arr[i, j] = double.Parse(words[j]);
                }
            }
            return true;
        }

        /**
         * <summary>Finds the longest element of the matrix.</summary>
         * <returns>Integer representing length of the element.</returns>
         */
        public int longestElem(){
            int l = 0;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (arr[i,j].ToString().Length > l)
                    {
                        l = arr[i,j].ToString().Length;
                    }
                }
            }
            return l;
        }

        /**
         * <summary>Prints the formatted matrix.</summary>
         */
        public void print()
        {
            int l = longestElem();

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    string elemStr = "";
                    if (arr[i,j] < 0){
                        elemStr = arr[i,j].ToString();
                    }
                    else
                    {
                        elemStr = " " + arr[i,j].ToString();
                    }
                    Write(elemStr.PadRight(l+1));
                }
                WriteLine();
            }
        }
    }
}