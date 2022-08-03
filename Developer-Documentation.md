# Matrix Class
Matrices in the program are stored as objects that have 2-dimensional arrays that hold values of the type double. Each matrix object has three further properties associated with them.
1) height: This is the number of rows. It is of type int.
2) width: This is the number of columns. It is of type int. 
3) square: This is a boolean property that is true if the matrix is a square i.e is its height is equal to its width.


# How to add a new matrix operation
Currently the program has scope for adding new binary, unary and nullary matrix operations by inheriting from interfaces. Nullary operations have a single function createMatrix(int r, int c) that accepts the number of rows and columns and returns a newly created matrix. 
Unary and binary operations have two functions in the interface. Add code in checkValidMatrix() to check if the input matrix meets certain requirements that are necessary for the operations. 
The code for the matrix operation should be placed under Matrixoperation(...). Both these functions accept 1 or 2 matrices as arguments depending on if it is of type IUnaryOperation or IBinaryOperation
