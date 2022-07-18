namespace Matrix_Calculator
{

    interface IUnaryOperation
    {
        
        bool checkValidMatrix(Matrix a);

        Matrix operation(Matrix a);
    }

    interface IBinaryOperation
    {

        bool checkValidMatrices(Matrix a, Matrix b);


        Matrix operation(Matrix a, Matrix b);
    }

    interface IEmptyMatriX
    {
        Matrix createMatrix(int r, int c);
    }
}