using System;
using System.Collections.Generic;
using Xunit;

namespace calcy.test
{
    public class LexerTest
    {

        [Fact]
        public void TestAllTokens()
        {
            string expected = " LBRACE: RBRACE: NUMBER:4646 ADD: MINUS: MULTIPLY: DIVISION: NUMBER:565.788 EOF:";
            Lexer lexer = new Lexer("( ) 4646 + - * / 565.788");
            List<Tokens> tokens = lexer.Get_Tokens();
            string actual = lexer.ToString();

            Assert.NotEmpty(tokens);
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void TestInvalidCharacters()
        {
            Lexer lexer = new Lexer("Wabebe");
            Assert.Throws<InvalidOperationException>(() => lexer.Get_Tokens());
        }

        [Fact]
        public void TestInvalidDecimalNumber()
        {
            Lexer lexer = new Lexer("35.4533.4546");
            Assert.Throws<FormatException>(() => lexer.Get_Tokens());
        }
    }
}
