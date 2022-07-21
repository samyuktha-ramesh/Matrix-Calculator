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
            int h = 0;
            int w = 0;

            while (h <= 0)
            {
                WriteLine("Enter height of matrix:");
                h = int.Parse(ReadLine());
                if (h <= 0)
                {
                    WriteLine("Height needs to be greater than zero. Please try again.");
                }
            }
            WriteLine();

            while (w <= 0)
            {
                WriteLine("Enter width of matrix:");
                w = int.Parse(ReadLine());
                if (w <= 0)
                {
                    WriteLine("Width needs to be greater than zero. Please try again.");
                }
            }
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

        public static IBinaryOperation parseBinaryOperation(string op)
        {
            if (op == "+")
            {
                return new Addition();
            }
            else if (op == "-")
            {
                return new Subtraction();
            }
            else if (op == "*")
            {
                return new Multiplication();
            }
            else
            {
                return null;
            }
        }

        public static IUnaryOperation parseUnaryOperation(string op)
        {
            if (op == "determinant")
            {
                return new Determinant();
            }
            else if (op == "inverse")
            {
                return new Inverse();
            }
            else if (op == "transpose")
            {
                return new Transpose();
            }
            else
            {
                return null;
            }
        }

        public static INullaryOperation parseNullOperation(string op)
        {
            if (op == "zero")
            {
                return new ZeroMatrix();
            }
            else if (op == "identity")
            {
                return new IdentityMatrix();
            }
            else if (op == "random")
            {
                return new RandomMatrix();
            }
            else
            {
                return null;
            }
        }

        public static void Main()
        {
            welcomeMsg();
            WriteLine("The possible operations are +, -, *, determinant, inverse, transpose, zero, identity and random");
            WriteLine("Please enter the operation you would like: ");
            string op = ReadLine().Trim().ToLower();
            WriteLine();
            Matrix a;
            Matrix b;
            Matrix ans;
            IBinaryOperation binOp;
            IUnaryOperation unaryOp;
            INullaryOperation nullOp;

            if ((binOp = parseBinaryOperation(op)) != null)
            {
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

                if (binOp.checkValidMatrices(a,b))
                {
                    ans = binOp.operation(a,b);
                    printAns(ans);
                }
                else{
                    exitMsg();
                }
            }
            else if ((unaryOp = parseUnaryOperation(op)) != null)
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

                if (unaryOp.checkValidMatrix(a))
                {
                    ans = unaryOp.operation(a);
                    printAns(ans);
                }
                else
                {
                    exitMsg();
                }
            }
            else if ((nullOp = parseNullOperation(op)) != null)
            {
                int h = 0;
                int w = 0;
                
                try
                {
                    while (h <= 0)
                    {
                        WriteLine("Enter height of required matrix:");
                        h = int.Parse(ReadLine());
                        if (h <= 0)
                        {
                            WriteLine("Height needs to be greater than zero. Please try again.");
                        }
                    }
                    WriteLine();

                    if (op == "identity")
                    {
                        w = h;
                    }
                    else
                    {
                        while (w <= 0)
                        {
                            WriteLine("Enter width of required matrix:");
                            w = int.Parse(ReadLine());
                            if (w <= 0)
                            {
                                WriteLine("Width needs to be greater than zero. Please try again.");
                            }
                        }
                        WriteLine();
                    }

                    ans = nullOp.createMatrix(h,w);
                    printAns(ans);
                }
                catch
                {
                    wrongInputFormat();
                }
            }
            else{
                WriteLine("No such operation exists.");
                exitMsg();
            }
        }

    }
}
