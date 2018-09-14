namespace ITI.RegularExpressions
{
    public class Node
    {
        readonly char _symbol;
        readonly Node _left;
        readonly Node _right;

        public Node( char symbol )
            : this( symbol, null )
        {
        }

        public Node( char symbol, Node left )
            : this( symbol, left, null )
        {
        }

        public Node( char symbol, Node left, Node right )
        {
            _symbol = symbol;
            _left = left;
            _right = right;
        }

        public char Symbol
        {
            get { return _symbol; }
        }

        public Node Left
        {
            get { return _left; }
        }

        public Node Right
        {
            get { return _right; }
        }

        public override string ToString()
        {
            if( char.IsLetterOrDigit( _symbol ) ) return _symbol.ToString();
            if( _symbol == '*' ) return string.Format( "(* {0})", _left );
            return string.Format( "({0} {1} {2})", _symbol, _left, _right );
        }
    }
}
