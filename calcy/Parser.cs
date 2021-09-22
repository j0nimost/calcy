using System;
using System.Collections.Generic;
using System.Text;

namespace calcy
{
    public class Parser
    {
        private List<Token> TermItems = new List<Token>() { Token.ADD, Token.MINUS };
        private List<Token> FactorItems = new List<Token>() { Token.MULTIPLY, Token.DIVISION };
        private readonly List<Tokens> _tokens;
        private int pos = 0;
        private Tokens curr_token = null;


        public Parser(List<Tokens> tokens)
        {
            this._tokens = tokens;
            // set the current token
            Get_Next();
        }

        private void Get_Next()
        {
            if(pos < this._tokens.Count)
            {
                curr_token = this._tokens[pos];
                pos++;
            }
        }

        public AST ParseExp()
        {
            AST result = Factor();
            while(curr_token._tokenType != Token.EOF && result != null && TermItems.Contains(curr_token._tokenType))
            {
                if(curr_token._tokenType == Token.ADD)
                {
                    Get_Next();
                    AST rigthNode = Factor();
                    result = new ASTPlus(result, rigthNode);
                }
                else if(curr_token._tokenType == Token.MINUS)
                {
                    Get_Next();
                    AST rigthNode = Factor();
                    result = new ASTMinus(result, rigthNode);
                }
            }

            return result;
        }

        public AST Factor()
        {
            AST factor = Term();
            while (curr_token._tokenType != Token.EOF && factor != null && FactorItems.Contains(curr_token._tokenType))
            {
                if (curr_token._tokenType == Token.MULTIPLY)
                {
                    Get_Next();
                    AST rigthNode = Term();
                    factor = new ASTMultiply(factor, rigthNode);
                }
                else if (curr_token._tokenType == Token.DIVISION)
                {
                    Get_Next();
                    AST rigthNode = Term();
                    factor = new ASTDivide(factor, rigthNode);
                }
            }
            return factor;
        }

        public AST Term()
        {
            AST term = null;

            if(curr_token._tokenType == Token.LBRACE)
            {
                Get_Next();
                term = ParseExp();
                if(curr_token._tokenType != Token.RBRACE)
                {
                    throw new FormatException("Missing )");
                }
            }
            else if(curr_token._tokenType == Token.NUMBER)
            {
                term = new ASTLeaf((decimal)curr_token._value);
            }    

            Get_Next();
            return term;
        }

    }
}
