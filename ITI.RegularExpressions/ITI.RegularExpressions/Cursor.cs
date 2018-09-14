namespace ITI.RegularExpressions
{
    public class Cursor
    {
        readonly string _s;
        int _pos;

        public Cursor( string s )
        {
            _s = s ?? string.Empty;
        }

        public char Current
        {
            get { return Lookahead( 0 ); }
        }

        public void Next()
        {
            _pos++;
        }

        public char Lookahead( int n )
        {
            if( _pos + n >= _s.Length ) return ( char )0;
            return _s[ _pos + n ];
        }
    }
}
