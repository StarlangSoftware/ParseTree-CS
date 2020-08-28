namespace ParseTree
{
    public class ConstituentSpan
    {
        private Symbol constituent;
        private int start;
        private int end;

        public Symbol GetConstituent() {
            return constituent;
        }

        public int GetStart() {
            return start;
        }

        public int GetEnd() {
            return end;
        }

        public ConstituentSpan(Symbol constituent, int start, int end) {
            this.constituent = constituent;
            this.start = start;
            this.end = end;
        }
    }
}