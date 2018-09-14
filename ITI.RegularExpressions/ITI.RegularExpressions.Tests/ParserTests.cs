using NUnit.Framework;

namespace ITI.RegularExpressions.Tests
{
    [TestFixture]
    public class ParserTests
    {
        [TestCase( "a", "a" )]
        [TestCase( "ab", "(+ a b)" )]
        [TestCase( "ab|c", "(| (+ a b) c)" )]
        [TestCase( "ab|c*", "(| (+ a b) (* c))" )]
        [TestCase( "a(b|c)*", "(+ a (* (| b c)))" )]
        [TestCase( "(ab|xc)*", "(* (| (+ a b) (+ x c)))" )]
        [TestCase( "((abc|a*)de*)*fg", "(+ (+ (* (+ (+ (| (+ (+ a b) c) (* a)) d) (* e))) f) g)" )]
        [TestCase( "((abc|a*)de*)*fg(ab)*", "(+ (+ (+ (* (+ (+ (| (+ (+ a b) c) (* a)) d) (* e))) f) g) (* (+ a b)))" )]
        public void parsing( string regex, string expected )
        {
            Parser p = new Parser( regex );
            Node ast = p.Parse();
            Assert.That( ast.ToString(), Is.EqualTo( expected ) );
        }
    }
}
