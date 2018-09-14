using NUnit.Framework;

namespace ITI.RegularExpressions.Tests
{
    [TestFixture]
    public class ParserTests
    {
        [TestCase( "ab|c", "(| (+ a b) c)" )]
        [TestCase( "ab|c*", "(| (+ a b) (* c))" )]
        [TestCase( "a(b|c)*", "(+ a (* (| b c)))" )]
        [TestCase( "(ab|xc)*", "(* (| (+ a b) (+ x c)))" )]
        public void parsing( string regex, string expected )
        {
            Parser p = new Parser( regex );
            Node ast = p.Parse();
            Assert.That( ast.ToString(), Is.EqualTo( expected ) );
        }
    }
}
