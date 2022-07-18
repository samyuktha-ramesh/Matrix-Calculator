using System;
using static System.Console;
using System.Collections.Generic;

namespace Matrix_Calculator
{

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

        // print out matrix
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