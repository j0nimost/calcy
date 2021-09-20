using System;
using System.Collections.Generic;
using System.Text;

namespace calcy
{
    public enum Token
    {
        NUMBER=0,


        ADD, // +
        MINUS, // -
        MULTIPLY, // *
        DIVISION, // /

        RBRACE, // (
        LBRACE, // )

        EOF // END OF FILE
    }
    public class Tokens
    {
        public readonly Token _tokenType;
        public readonly object _value;

        public Tokens(Token tokenType, object value)
        {
            this._tokenType = tokenType;
            this._value = value;
        }


        public override string ToString()
        {
            return " " + this._tokenType + ":" + this._value;
        }
    }
}
