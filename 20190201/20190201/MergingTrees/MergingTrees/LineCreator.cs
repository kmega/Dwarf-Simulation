namespace MergingTrees
{
    partial class Program
    {
        private class LineCreator
        {
            internal Line CreateSingleLine(string line)
            {
                return new Line(line, StringParser.ParseSpaceCount(line), StringParser.ParsePath(line));
            }
        }
    }
}
