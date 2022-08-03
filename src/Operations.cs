using static System.Console;
using System;

namespace Matrix_Calculator
{
    /**
     * <summary>Represents addition operation for matrices.</summary>
     */
    public class Addition : IBinaryOperation
    {
        /**
         * <summary>True if both matrices have the same dimensions.</summary>
         * <param name="a">Instance of <c>Matrix</c> the first matrix.</param>
         * <param name="b">Instance of <c>Matrix</c> the second matrix.</param>
         */
        public bool checkValidMatrices(Matrix a, Matrix b)
        {    
            if (a.height == b.height && a.width == b.width)
            {
                return true;
            }

            WriteLine("Addition requires both matrices to have same dimensions.");
            return false;
        }

        /**
         * <summary>Adds two matrices.</summary>
         * <param name="a">Instance of <c>Matrix</c> the first matrix.</param>
         * <param name="b">Instance of <c>Matrix</c> the second matrix.</param>
         * <returns>Instance of <c>Matrix</c> representing the sum of two matrices.</returns>
         */
        public Matrix operation(Matrix a, Matrix b)
        {
            // ans = a + b
            Matrix ans = new Matrix(a.height, a.width); 

            for (int i = 0 ; i < a.height ; i++)
            {
                for (int j = 0; j < a.width ; j++)
                {
                    ans.arr[i,j] = a.arr[i,j] + b.arr[i,j];
                }
            }
            return ans;
        }
    }

    /**
     * <summary>Represents subtraction operation for matrices.</summary>
     */
    public class Subtraction : IBinaryOperation
    {

        /**
         * <summary>True if both matrices have the same dimensions.</summary>
         * <param name="a">Instance of <c>Matrix</c> the first matrix.</param>
         * <param name="b">Instance of <c>Matrix</c> the second matrix.</param>
         */
        public bool checkValidMatrices(Matrix a, Matrix b)
        {    
            if (a.height == b.height && a.width == b.width)
            {
                return true;
            }

            WriteLine("Subtraction requires both matrices to have same dimensions.");
            return false;
        }

         /**
          * <summary>Subtracts two matrices.</summary>
          * <param name="a">Instance of <c>Matrix</c> the first matrix.</param>
          * <param name="b">Instance of <c>Matrix</c> the second matrix.</param>
          * <returns>Instance of <c>Matrix</c> representing the difference of two matrices.</returns>
          */
        public Matrix operation(Matrix a, Matrix b)
        {
            // ans = a - b
            Matrix ans = new Matrix(a.height, a.width); 

            for (int i = 0 ; i < a.height ; i++)
            {
                for (int j = 0; j < a.width ; j++)
                {
                    ans.arr[i,j] = a.arr[i,j] - b.arr[i,j];
                }
            }
            return ans;
        }
    }

    /**
     * <summary>Represents multiplication operation for matrices.</summary>
     */
    public class Multiplication : IBinaryOperation
    {
        /**
         * <summary>True if the width of the first matrix is equal to the height of the second matrix.</summary>
         * <param name="a">Instance of <c>Matrix</c> the first matrix.</param>
         * <param name="b">Instance of <c>Matrix</c> the second matrix.</param>
         */
        public bool checkValidMatrices(Matrix a, Matrix b)
        {
            if (a.width == b.height)
            {
                return true;
            }

            WriteLine("Multiplication requires matrices to have dimensions lxm and mxn");
            return false;
        }

         /**
          * <summary>Multiplies two matrices.</summary>
          * <param name="a">Instance of <c>Matrix</c> the first matrix.</param>
          * <param name="b">Instance of <c>Matrix</c> the second matrix.</param>
          * <returns>Instance of <c>Matrix</c> representing the product of two matrices.</returns>
          */
        public Matrix operation(Matrix a, Matrix b)
        {
            // ans = a * b
            Matrix ans = new Matrix(a.height, b.width);

            for (int i = 0 ; i < a.height ; i++)
            {
                for (int j = 0; j < b.width; j++) 
                {
                    for (int k = 0; k < a.width; k++)
                    {
                        ans.arr[i, j] += a.arr[i,k] * b.arr[k,j];
                    }
                }
            }

            return ans;
        }

    }

    /**
     * <summary>Represents transpose operation for matrices.</summary>
     */
    public class Transpose : IUnaryOperation
    {
        /**
         * <summary>Always true because tranpose can be found for all matrices.</summary>
         * <param name="a">Instance of <c>Matrix</c> the matrix to be transposed.</param>
         */
        public bool checkValidMatrix(Matrix a)
        {
            return true;
        }

        /**
         * <summary>Finds tranpose of a matrix.</summary>
         * <param name="a">Instance of <c>Matrix</c> the matrix to be transposed.</param>
         * <returns>Instance of <c>Matrix</c> representing the tranpose of the matrix.</returns>
         */
        public Matrix operation(Matrix a)
        {
            // transpose of 2x3 matrix is a 3x2 matrix
            Matrix ans = new Matrix(a.width, a.height);
            
            for (int i = 0 ; i < a.height ; i++)
            {
                for (int j = 0; j < a.width ; j++)
                {
                    ans.arr[j,i] = a.arr[i,j];
                }
            }
            return ans;
        }
    }   

    /**
     * <summary>Represents determinant operation for matrices.</summary>
     */
    public class Determinant : IUnaryOperation
    {
        /**
         * <summary>True if matrix is square.</summary>
         * <param name="a">Instance of <c>Matrix</c></param>
         */
        public bool checkValidMatrix(Matrix a)
        {
            if (a.square)
            {
                return true;
            }

            WriteLine("Determinant requires a square matrix");
            return false;
        }

        /**
         * <summary>Finds submatrix of a matrix by removing specified row and column.</summary>
         * <param name="a">Instance of <c>Matrix</c> of order n.</param>
         * <param name="row">Row to omit.</param>
         * <param name="col">Column to omit.</param>
         * <returns>Instance of <c>Matrix</c> representing the submatrix (of order n-1) of the matrix.</returns>
         */
        public Matrix subMatrix(Matrix a, int row, int col)
        {
            Matrix sub = new Matrix(a.height-1, a.width-1);

            int x = 0;
            int y = 0;

            for (int p = 0; p < a.height; p++)
            {
                if (p != row)
                {
                    y = 0;
                    for (int q = 0; q < a.width; q++)
                    {
                        if (q != col)
                        {
                            sub.arr[x,y] = a.arr[p,q];
                            y++;
                        }
                    }
                    x++;
                }
            }
            return sub;
        }

        /**
         * <summary>Finds the sign of the element at given position.</summary>
         * <param name="row">Row number of element.</param>
         * <param name="col">Column number of element.</param>
         * <returns>1 or -1 representing positive or negative.</returns>
         */
        public int sign(int row, int col)
        {
            if((row + col) % 2 == 0)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

        /**
         * <summary>Recursive function to find the determinant of a matrix.</summary>
         * <param name="a">Instance of <c>Matrix</c></param>
         * <returns>An integer representing the determinant of the matrix.</returns>
         */
        public Matrix operation(Matrix a)
        {
            Matrix ans = new Matrix(1,1);

            if (a.height > 2)
            {
                double det = 0;
                for (int col = 0; col < a.width; col++)
                {
                    Matrix sub = subMatrix(a, 0, col);
                    det += (a.arr[0,col] * sign(0,col) * operation(sub).arr[0,0]);
                }

                ans.arr[0,0] = det;
                return ans;
            }
            else if (a.height == 2)
            {
                // [ w x
                //   y z ]
                double w = a.arr[0,0];
                double x = a.arr[0,1];
                double y = a.arr[1,0];
                double z = a.arr[1,1];

                ans.arr[0,0] = (w*z - x*y);
                return ans;
            }
            else 
            {
                // matrix is of size 1 so determinant is equal to its only element
                return a;
            }   
        }
    }

    /**
     * <summary>Represents inverse operation for matrices.</summary>
     */
    public class Inverse : IUnaryOperation
    {
        /**
         * <summary>True if matrix is square.</summary>
         * <param name="a">Instance of <c>Matrix</c></param>
         */
        public bool checkValidMatrix(Matrix a)
        {
            if (a.square)
            {
                if (isSingular(a))
                {
                    return false;
                }
                return true;
            }
            else{
                WriteLine("Inverse requires a square matrix");
            }
            
            return false;
        }

        /**
        * <summary>Returns true if matrix is singular (does not have an inverse) i.e its determinant is 0.</summary>
        * <param name="a">Instance of <c>Matrix</c></param>
        */
        public bool isSingular(Matrix a){
            Determinant det = new Determinant();

            if (det.operation(a).arr[0,0] == 0)
            {
                WriteLine("Matrix is singular. No inverse exists");
                return true;
            }

            return false;
        }

        /**
        * <summary>Performs Gauss-Jordan elimination to find the inverse of a matrix.</summary>
        * <param name="a">Instance of <c>Matrix</c></param>
        * <returns>Instance of <c>Matrix</c> that is the inverse of a.</returns>
        */
        public Matrix operation(Matrix a)
        {
            //matrix gauss-jordan elimination
            Matrix gj = new Matrix(a.height, 2*a.width);

            //add elements of original matrix to left side of new matrix
            for (int i = 0; i < a.height; i++)
            {
                for (int j = 0; j < a.width; j++)
                {
                    gj.arr[i,j] = a.arr[i,j];
                }
            }

            //right side of matrix gj is the identity matrix
            for (int i = 0; i < gj.height; i++)
            {
                for (int j = a.width; j < gj.width; j++)
                {
                    if (j-i == a.height)
                    {
                        gj.arr[i,j] = 1;
                    }
                    else
                    {
                        gj.arr[i,j] = 0;
                    }
                }
            }

            //perform gauss-jordan elimination
            for (int i = 0; i < gj.height; i++)
            {
                if (gj.arr[i,i] != 1) // if diagonal element is not 1 then divide rest of the row by the element
                {
                    double val = gj.arr[i,i];
                    for (int j = i+1; j < gj.width; j++)
                    {
                        gj.arr[i,j] /= val;
                    }
                }
                for (int t = 0; t < gj.height; t++){
                    if (t != i) // if not current row 
                    {
                        double val = gj.arr[t,i]; // element in same column as current column
                        for (int j = 0; j < gj.width; j++)
                        {
                            gj.arr[t,j] -= val * gj.arr[i,j];
                        }
                    }
                }
            }

            Matrix ans = new Matrix(a.height, a.width);

            //get only the right hand side of matrix i.e the inverse
            for (int i = 0; i < a.height; i++)
            {
                for (int j = a.width; j < gj.width; j++)
                {
                    ans.arr[i, j-a.width] = gj.arr[i,j];
                }
            }

            return ans;
        }
    }

    /**
     * <summary>Represents zero matrix builder.</summary>
     */
    public class ZeroMatrix : INullaryOperation
    {
        /**
          * <summary>Creates matrix filled with zeroes.</summary>
          * <param name="r">Number of rows.</param>
          * <param name="c">Number of columns.</param>
          * <returns>Instance of <c>Matrix</c>, with r rows and c columns, filled with zeroes</returns>
          */
        public Matrix createMatrix(int r, int c)
        {
            Matrix ans = new Matrix(r,c);

            return ans;
        }
    }

    /**
     * <summary>Represents identity matrix builder.</summary>
     */
    public class IdentityMatrix : INullaryOperation
    {
        /**
          * <summary>Creates matrix with 1s in its diagonals and remaining 0s.</summary>
          * <param name="r">Number of rows.</param>
          * <param name="c">Number of columns.</param>
          * <returns>Instance of <c>Matrix</c>, with r rows and c columns,with 1s in its diagonals and remaining 0s.</returns>
          */
        public Matrix createMatrix(int r, int c)
        {
            Matrix ans = new Matrix(r,c);
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    if (i == j)
                    {
                        ans.arr[i,j] = 1;
                    }
                    else
                    {
                        ans.arr[i,j] = 0;
                    }
                }
            }

            return ans;
        }
    }

    /**
     * <summary>Represents random matrix builder.</summary>
     */
    public class RandomMatrix : INullaryOperation
    {
         /**
          * <summary>Creates matrix filled with random numbers between a given range</summary>
          * <param name="r">Number of rows.</param>
          * <param name="c">Number of columns.</param>
          * <returns>Instance of <c>Matrix</c>, with r rows and c columns, filled with random numbers.</returns>
          */
        public Matrix createMatrix(int r, int c)
        {
            WriteLine("Enter minimum value for an element in the matrix");
            int mini = int.Parse(ReadLine());

            WriteLine("Enter maximum value for an element in the matrix");
            int maxi = int.Parse(ReadLine());
            
            Matrix ans = new Matrix(r,c);
            
            var rand = new System.Random();

            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    ans.arr[i,j] = rand.Next(mini, maxi+1);
                }
            }

            return ans;
        }
    }
}