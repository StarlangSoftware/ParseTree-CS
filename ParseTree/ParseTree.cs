using System.Collections.Generic;
using System.IO;
using DependencyParser.Universal;
using ParseTree.NodeCondition;

namespace ParseTree
{
    public class ParseTree
    {
        private static readonly List<string> SentenceLabels =
            new List<string>(new[] {"SINV", "SBARQ", "SBAR", "SQ", "S"});
        protected string _name;

        protected ParseNode root;

        /**
         * <summary> Empty constructor for ParseTree. Initializes the root node to null.</summary>
         */
        public ParseTree()
        {
            root = null;
        }

        /**
         * <summary> Basic constructor for a ParseTree. Initializes the root node with the input.</summary>
         * <param name="root">Root node of the tree</param>
         */
        public ParseTree(ParseNode root)
        {
            this.root = root;
        }

        /**
         * <summary> Another constructor of the ParseTree. The method takes the file containing a single line as input and constructs
         * the whole tree by calling the ParseNode constructor recursively.</summary>
         * <param name="fileName">File containing a single line for a ParseTree</param>
         */
        public ParseTree(string fileName)
        {
            var streamReader = new StreamReader(fileName);
            var line = streamReader.ReadLine();
            if (line.Contains("(") && line.Contains(")"))
            {
                line = line.Substring(line.IndexOf("(") + 1, line.LastIndexOf(")")).Trim();
                root = new ParseNode(null, line, false);
                streamReader.Close();
            }
            else
            {
                root = null;
            }
        }
        
        /// <summary>
        /// Mutator for the name attribute.
        /// </summary>
        /// <param name="name">Name of the parse tree.</param>
        public void SetName(string name)
        {
            this._name = name;
        }

        /// <summary>
        /// Accessor for the name attribute.
        /// </summary>
        /// <returns>Name of the parse tree.</returns>
        public string GetName()
        {
            return _name;
        }
        
        /**
         * <summary> Gets the next leaf node after the given leaf node in the ParseTree.</summary>
         * <param name="parseNode">ParseNode for which next node is calculated.</param>
         * <returns>Next leaf node after the given leaf node.</returns>
         */
        public ParseNode NextLeafNode(ParseNode parseNode)
        {
            NodeCollector nodeCollector = new NodeCollector(root, new IsEnglishLeaf());
            List<ParseNode> leafList = nodeCollector.Collect();
            for (var i = 0; i < leafList.Count - 1; i++)
            {
                if (leafList[i].Equals(parseNode))
                {
                    return leafList[i + 1];
                }
            }

            return null;
        }

        /**
         * <summary> Gets the previous leaf node before the given leaf node in the ParseTree.</summary>
         * <param name="parseNode">ParseNode for which previous node is calculated.</param>
         * <returns>Previous leaf node before the given leaf node.</returns>
         */
        public ParseNode PreviousLeafNode(ParseNode parseNode)
        {
            NodeCollector nodeCollector = new NodeCollector(root, new IsEnglishLeaf());
            List<ParseNode> leafList = nodeCollector.Collect();
            for (var i = 1; i < leafList.Count; i++)
            {
                if (leafList[i].Equals(parseNode))
                {
                    return leafList[i - 1];
                }
            }

            return null;
        }

        /**
         * <summary> Calls recursive method to calculate the number of all nodes, which have more than one children.</summary>
         * <returns>Number of all nodes, which have more than one children.</returns>
         */
        public int NodeCountWithMultipleChildren()
        {
            return root.NodeCountWithMultipleChildren();
        }

        /**
         * <summary> Calls recursive method to calculate the number of all nodes tree.</summary>
         * <returns>Number of all nodes in the tree.</returns>
         */
        public int NodeCount()
        {
            return root.NodeCount();
        }

        /**
         * <summary> Calls recursive method to calculate the number of all leaf nodes in the tree.</summary>
         * <returns>Number of all leaf nodes in the tree.</returns>
         */
        public int LeafCount()
        {
            return root.LeafCount();
        }

        /// <summary>
        /// Checks if the sentence is a full sentence or not. A sentence is a full sentence is its root tag is S, SINV, etc.
        /// </summary>
        /// <returns>True if the sentence is a full sentence, false otherwise.</returns>
        public bool IsFullSentence()
        {
            if (root != null && SentenceLabels.Contains(root.GetData().GetName()))
            {
                return true;
            }

            return false;
        }

        /**
         * <summary> Saves the tree into the file with the given file name. The output file only contains one line representing tree.</summary>
         * <param name="fileName">Output file name</param>
         */
        public void Save(string fileName)
        {
            var streamWriter = new StreamWriter(fileName);
            streamWriter.WriteLine("( " + ToString() + " )");
            streamWriter.Close();
        }

        /**
         * <summary> Calls recursive method to restore the parents of all nodes in the tree.</summary>
         */
        public void CorrectParents()
        {
            root.CorrectParents();
        }

        /**
         * <summary> Calls recursive method to remove all nodes starting with the symbol X. If the node is removed, its children are
         * connected to the next sibling of the deleted node.</summary>
         */
        public void RemoveXNodes()
        {
            root.RemoveXNodes();
        }

        /**
         * <summary> Calls recursive method to remove all punctuation nodes from the tree.</summary>
         */
        public void StripPunctuation()
        {
            root.StripPunctuation();
        }

        /**
         * <summary> Accessor method for the root node.</summary>
         * <returns>Root node</returns>
         */
        public ParseNode GetRoot()
        {
            return root;
        }


        /**
         * <summary> Calls recursive function to convert the tree to a string.</summary>
         * <returns>A string which contains all words in the tree.</returns>
         */
        public override string ToString()
        {
            return root.ToString();
        }

        /**
         * <summary> Calls recursive function to convert the tree to a sentence.</summary>
         * <returns>A sentence which contains all words in the tree.</returns>
         */
        public string ToSentence()
        {
            return root.ToSentence();
        }

        /**
         * <summary> Calls recursive function to count the number of words in the tree.</summary>
         * <param name="excludeStopWords">If true, stop words are not counted.</param>
         * <returns>Number of words in the tree.</returns>
         */
        public int WordCount(bool excludeStopWords)
        {
            return root.WordCount(excludeStopWords);
        }
        
        /**
         * <summary>Generates a list of constituents in the parse tree and their spans.</summary>
         * <returns> A list of constituents in the parse tree and their spans.</returns>
         */
        public List<ConstituentSpan> ConstituentSpanList(){
            var result = new List<ConstituentSpan>();
            if (root != null){
                root.ConstituentSpanList(1, result);
            }
            return result;
        }

    }
}