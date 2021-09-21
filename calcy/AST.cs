using System;
using System.Collections.Generic;
using System.Text;

namespace calcy
{
    public abstract class AST
    {
        public abstract decimal Eval();
    }

    public class ASTLeaf : AST
    {
        public readonly decimal _num;
        public ASTLeaf(decimal num)
        {
            this._num = num;
        }
        public override decimal Eval()
        {
            return this._num;
        }

        public override string ToString()
        {
            return this._num.ToString();
        }
    }

    public class ASTPlus : AST
    {
        public readonly AST _leftNode;
        public readonly AST _rightNode;

        public ASTPlus(AST leftNode, AST rightNode)
        {
            this._leftNode = leftNode;
            this._rightNode = rightNode;
        }
        public override decimal Eval()
        {
            // Perform the evaluation
            return this._leftNode.Eval() + this._rightNode.Eval();
        }

        public override string ToString()
        {
            return String.Format("({0} + {1})", this._leftNode.ToString(), this._rightNode.ToString());
        }
    }

    public class ASTMinus : AST
    {
        public readonly AST _leftNode;
        public readonly AST _rightNode;

        public ASTMinus(AST leftNode, AST rightNode)
        {
            this._leftNode = leftNode;
            this._rightNode = rightNode;
        }
        public override decimal Eval()
        {
            return this._leftNode.Eval() - this._rightNode.Eval();
        }
        public override string ToString()
        {
            return String.Format("({0} - {1})", this._leftNode.ToString(), this._rightNode.ToString());
        }
    }

    public class ASTMultiply : AST
    {
        public readonly AST _leftNode;
        public readonly AST _rightNode;

        public ASTMultiply(AST leftNode, AST rightNode)
        {
            this._leftNode = leftNode;
            this._rightNode = rightNode;
        }
        public override decimal Eval()
        {
            return this._leftNode.Eval() * this._rightNode.Eval();
        }

        public override string ToString()
        {
            return String.Format("({0} * {1})", this._leftNode.ToString(), this._rightNode.ToString());
        }
    }
    public class ASTDivide : AST
    {
        public readonly AST _leftNode;
        public readonly AST _rightNode;

        public ASTDivide(AST leftNode, AST rightNode)
        {
            this._leftNode = leftNode;
            this._rightNode = rightNode;
        }
        public override decimal Eval()
        {
            return this._leftNode.Eval() / this._rightNode.Eval();
        }

        public override string ToString()
        {
            return String.Format("({0} / {1})", this._leftNode.ToString(), this._rightNode.ToString());
        }
    }
}
