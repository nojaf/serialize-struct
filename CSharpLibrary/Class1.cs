namespace CSharpLibrary
{

    public struct CRange
    {
        public int StartLine { get; }
        public int StartColumn { get; }
        public int EndLine { get; }
        public int EndColumn { get; }

        public CRange(int startLine, int startColumn, int endLine, int endColumn)
        {
            StartLine = startLine;
            StartColumn = startColumn;
            EndLine = endLine;
            EndColumn = endColumn;
        }
    }
}