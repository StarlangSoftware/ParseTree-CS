namespace ParseTree
{
    public class ConstituentSpan
    {
        private Symbol constituent;
        private int start;
        private int end;

        /// <summary>
        /// Constructor for the ConstituentSpan class. ConstituentSpan is a structure for storing constituents or phrases in
        /// a sentence with a specific label. Sets the attributes.
        /// </summary>
        /// <param name="constituent">Label of the span.</param>
        /// <param name="start">Start index of the span.</param>
        /// <param name="end">End index of the span.</param>
        public ConstituentSpan(Symbol constituent, int start, int end) {
            this.constituent = constituent;
            this.start = start;
            this.end = end;
        }
        
        /// <summary>
        /// Accessor for the constituent attribute
        /// </summary>
        /// <returns>Current constituent</returns>
        public Symbol GetConstituent() {
            return constituent;
        }

        /// <summary>
        /// Accessor for the start attribute
        /// </summary>
        /// <returns>Current start</returns>
        public int GetStart() {
            return start;
        }

        /// <summary>
        /// Accessor for the end attribute
        /// </summary>
        /// <returns>Current end</returns>
        public int GetEnd() {
            return end;
        }
    }
}