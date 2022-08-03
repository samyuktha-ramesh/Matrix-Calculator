namespace Matrix_Calculator
{
    /**
     * <summary>Represents a unary operation for matrices.</summary>
     */
    interface IUnaryOperation
    {
        
        bool checkValidMatrix(Matrix a);

        Matrix operation(Matrix a);
    }

    /**
     * <summary>Represents a binary operation for matrices.</summary>
     */
    interface IBinaryOperation
    {

        bool checkValidMatrices(Matrix a, Matrix b);

        Matrix operation(Matrix a, Matrix b);
    }

    /**
     * <summary>Represents a nullary operation for matrices.</summary>
     */
    interface INullaryOperation
    {
        Matrix createMatrix(int r, int c);
    }
}