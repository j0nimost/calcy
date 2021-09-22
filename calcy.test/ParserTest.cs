using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace calcy.test
{
    public class ParserTest
    {
        [Fact]
        public void TestASTString()
        {
            string expected = "((56 - (64 / 8)) + 4)";
            Lexer lexer = new Lexer("56    - 64/8 +4");
            List<Tokens> tokens = lexer.Get_Tokens();
            Assert.NotEmpty(tokens);
            Parser parser = new Parser(tokens);
            AST astObj = parser.ParseExp();
            Assert.NotNull(astObj);
            string actual = astObj.ToString();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestASTTermOperations()
        {
            decimal expected = 45;
            Lexer lexer = new Lexer("25+25 -5");
            List<Tokens> tokens = lexer.Get_Tokens();
            Assert.NotEmpty(tokens);
            Parser parser = new Parser(tokens);
            AST astObj = parser.ParseExp();
            Assert.NotNull(astObj);
            decimal actual = astObj.Eval();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestASTFactorOperations()
        {
            decimal expected = 5.5m;
            Lexer lexer = new Lexer("121/11*0.5");
            List<Tokens> tokens = lexer.Get_Tokens();
            Assert.NotEmpty(tokens);
            Parser parser = new Parser(tokens);
            AST astObj = parser.ParseExp();
            Assert.NotNull(astObj);
            decimal actual = astObj.Eval();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestASTBraces()
        {
            decimal expected = 0;
            Lexer lexer = new Lexer("10-5*(25/5)+15");
            List<Tokens> tokens = lexer.Get_Tokens();
            Assert.NotEmpty(tokens);
            Parser parser = new Parser(tokens);
            AST astObj = parser.ParseExp();
            Assert.NotNull(astObj);
            decimal actual = astObj.Eval();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestASTBraceMissing()
        {
            Lexer lexer = new Lexer("(25/5");
            List<Tokens> tokens = lexer.Get_Tokens();
            Assert.NotEmpty(tokens);
            Parser parser = new Parser(tokens);
            Assert.Throws<FormatException>(() => parser.ParseExp());
        }
    }
}
