using System;
using static System.Console;

namespace Matrix_Calculator 
{

    class Program 
    {

        public static void welcomeMsg()
        {
            WriteLine();
            WriteLine("Welcome to the Matrix Calculator!");
            WriteLine("---------------------------------");
            WriteLine();
        }

        public static void wrongInputFormat()
        {
            WriteLine();
            WriteLine("Wrong input format. Dimensions need to be an integer.");
            exitMsg();
        }

        public static void exitMsg()
        {
            WriteLine("Exiting the program. Please try again.");
            WriteLine();
        }


        public static void printAns(Matrix ans)
        {
            WriteLine("Answer:");
            WriteLine("_______");
            ans.print();
        }

        public static Matrix getMatrix()
        {

            WriteLine("Enter height of matrix:");
            int h = int.Parse(ReadLine());
            WriteLine();

            WriteLine("Enter width of matrix:");
            int w = int.Parse(ReadLine());
            WriteLine();

            Matrix a = new Matrix(h,w);

            bool matrixRead = false;
            while (!matrixRead)
            {
                WriteLine("Enter matrix:");
                matrixRead = a.read();
            }

            WriteLine();
            return a;
        }

        public static void Main()
        {
            welcomeMsg();
            WriteLine("The possible operations are +, -, *, determinant, inverse, transpose, zero, identity and random");
            WriteLine("Please enter the operation you would like: ");
            string op = ReadLine();
            WriteLine();
            Matrix a;
            Matrix b;
            Matrix ans;

            if (op == "+" || op == "-" || op == "*"){
                try
                {
                    WriteLine("1st Matrix");
                    WriteLine("----------");
                    a = getMatrix();

                    WriteLine("2nd Matrix");
                    WriteLine("----------");
                    b = getMatrix();
                }
                catch
                {
                    wrongInputFormat();
                    return;
                }

                switch (op)
                {
                    case "+":
                    Addition add = new Addition();

                    if (add.checkValidMatrices(a,b))
                    {
                        ans = add.operation(a,b);
                        printAns(ans);
                    }
                    else{

                        WriteLine("Addition requires both matrices to have same dimensions.");
                        exitMsg();
                    }
                    break;

                    case "-":
                        Subtraction sub = new Subtraction();
                        
                        if (sub.checkValidMatrices(a,b))
                        {
                            ans = sub.operation(a,b);
                            printAns(ans);
                        }
                        else 
                        {
                            WriteLine("Subtraction requires both matrices to have same dimensions.");
                            exitMsg();
                        }
                        break;

                    case "*":
                        Multiplication mul = new Multiplication();

                        if (mul.checkValidMatrices(a,b))
                        {
                            ans = mul.operation(a,b);
                            printAns(ans);
                        }
                        else
                        {
                            WriteLine("Subtraction requires matrices to have dimensions lxm and mxn");
                            exitMsg();
                        }
                        break;

                }
            }

            else if (op.ToLower() == "transpose" || op.ToLower() == "determinant" || op.ToLower() == "inverse")
            {
                try
                {
                    WriteLine("Matrix");
                    WriteLine("----------");
                    a = getMatrix();
                }
                catch
                {
                    wrongInputFormat();
                    return;
                }

                switch (op.ToLower())
                {
                    case "transpose":
                        Transpose transpose = new Transpose();
                        
                        ans = transpose.operation(a);
                        printAns(ans);
                        break;

                    case "determinant":
                        Determinant det = new Determinant();

                        if (det.checkValidMatrix(a))
                        {
                            WriteLine("Determinant = " + det.operation(a));
                        }
                        else
                        {
                            WriteLine("Determinant requires a square matrix");
                            exitMsg();
                        }
                        break;

                    case "inverse":
                        Inverse inv = new Inverse();

                        if (inv.checkValidMatrix(a))
                        {
                            if (inv.isSingular(a))
                            {
                                WriteLine("Matrix is singular. No inverse exists");
                                exitMsg();
                            }
                            else
                            {
                                ans = inv.operation(a);
                                printAns(ans);
                            }
                        }
                        else
                        {
                            WriteLine("Inverse requires a square matrix");
                            exitMsg();
                        }
                        break;
                }
            }
            else if (op.ToLower() == "zero" || op.ToLower() == "identity" || op.ToLower() == "random")
            {
                switch (op.ToLower())
                {
                    case "zero":
                        try
                        {
                            WriteLine("Enter height of required matrix:");
                            int h = int.Parse(ReadLine());
                            WriteLine();

                            WriteLine("Enter width of required matrix:");
                            int w = int.Parse(ReadLine());
                            WriteLine();

                            ZeroMatrix zero = new ZeroMatrix();
                            ans = zero.createMatrix(h,w);
                            printAns(ans);
                        }
                        catch
                        {
                            wrongInputFormat();
                        }
                        break;

                    case "identity":
                        try
                        {
                            WriteLine("Enter height of required matrix:");
                            int h = int.Parse(ReadLine());
                            WriteLine();

                            IdentityMatrix id = new IdentityMatrix();
                            ans = id.createMatrix(h,h);
                            printAns(ans);
                        }
                        catch
                        {
                            wrongInputFormat();
                        }
                        break;
                    
                    case "random":
                        try
                        {
                            WriteLine("Enter height of required matrix:");
                            int h = int.Parse(ReadLine());
                            WriteLine();

                            WriteLine("Enter width of required matrix:");
                            int w = int.Parse(ReadLine());
                            WriteLine();

                            RandomMatrix r = new RandomMatrix();
                            ans = r.createMatrix(h,w);
                            printAns(ans);
                        }
                        catch
                        {
                            wrongInputFormat();
                        }
                        break;
                }
            }
            else{
                WriteLine("No such operation exists.");
                exitMsg();
            }
        }

    }
}
