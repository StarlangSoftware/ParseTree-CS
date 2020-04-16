using System.Collections.Generic;
using DependencyParser;
using Dictionary.Dictionary;

namespace ParseTree
{
    public class ParseNode
    {
        protected List<ParseNode> children;
        protected ParseNode parent;
        protected Symbol data;

        private static readonly string[] ADJP =
        {
            "NNS", "QP", "NN", "$", "ADVP", "JJ", "VBN", "VBG", "ADJP", "JJR", "NP", "JJS", "DT", "FW", "RBR", "RBS",
            "SBAR", "RB"
        };

        private static readonly string[] ADVP =
            {"RB", "RBR", "RBS", "FW", "ADVP", "TO", "CD", "JJR", "JJ", "IN", "NP", "JJS", "NN"};

        private static readonly string[] CONJP = {"CC", "RB", "IN"};
        private static readonly string[] FRAG = { };
        private static readonly string[] INTJ = { };
        private static readonly string[] LST = {"LS", ":"};

        private static readonly string[] NAC =
        {
            "NN", "NNS", "NNP", "NNPS", "NP", "NAC", "EX", "$", "CD", "QP", "PRP", "VBG", "JJ", "JJS", "JJR", "ADJP",
            "FW"
        };

        private static readonly string[] PP = {"IN", "TO", "VBG", "VBN", "RP", "FW"};
        private static readonly string[] PRN = { };
        private static readonly string[] PRT = {"RP"};

        private static readonly string[] QP =
            {"$", "IN", "NNS", "NN", "JJ", "RB", "DT", "CD", "NCD", "QP", "JJR", "JJS"};

        private static readonly string[] RRC = {"VP", "NP", "ADVP", "ADJP", "PP"};
        private static readonly string[] S = {"TO", "IN", "VP", "S", "SBAR", "ADJP", "UCP", "NP"};

        private static readonly string[] SBAR =
            {"WHNP", "WHPP", "WHADVP", "WHADJP", "IN", "DT", "S", "SQ", "SINV", "SBAR", "FRAG"};

        private static readonly string[] SBARQ = {"SQ", "S", "SINV", "SBARQ", "FRAG"};
        private static readonly string[] SINV = {"VBZ", "VBD", "VBP", "VB", "MD", "VP", "S", "SINV", "ADJP", "NP"};
        private static readonly string[] SQ = {"VBZ", "VBD", "VBP", "VB", "MD", "VP", "SQ"};
        private static readonly string[] UCP = { };

        private static readonly string[] VP =
            {"TO", "VBD", "VBN", "MD", "VBZ", "VB", "VBG", "VBP", "VP", "ADJP", "NN", "NNS", "NP"};

        private static readonly string[] WHADJP = {"CC", "WRB", "JJ", "ADJP"};
        private static readonly string[] WHADVP = {"CC", "WRB"};
        private static readonly string[] WHNP = {"WDT", "WP", "WP$", "WHADJP", "WHPP", "WHNP"};
        private static readonly string[] WHPP = {"IN", "TO", "FW"};
        private static readonly string[] NP1 = {"NN", "NNP", "NNPS", "NNS", "NX", "POS", "JJR"};
        private static readonly string[] NP2 = {"NP"};
        private static readonly string[] NP3 = {"$", "ADJP", "PRN"};
        private static readonly string[] NP4 = {"CD"};
        private static readonly string[] NP5 = {"JJ", "JJS", "RB", "QP"};

        /**
         * <summary> Empty constructor for ParseNode class.</summary>
         */
        public ParseNode()
        {
        }

        /**
         * <summary> Constructs a ParseNode from a single line. If the node is a leaf node, it only sets the data. Otherwise, splits
         * the line w.r.t. spaces and parenthesis and calls itself recursively to generate its child parseNodes.</summary>
         * <param name="parent">The parent node of this node.</param>
         * <param name="line">The input line to create this parseNode.</param>
         * <param name="isLeaf">True, if this node is a leaf node; false otherwise.</param>
         */
        public ParseNode(ParseNode parent, string line, bool isLeaf)
        {
            var parenthesisCount = 0;
            var childLine = "";
            this.parent = parent;
            children = new List<ParseNode>();
            if (isLeaf)
            {
                data = new Symbol(line);
            }
            else
            {
                data = new Symbol(line.Substring(1, line.IndexOf(" ") - 1));
                if (line.IndexOf(")") == line.LastIndexOf(")"))
                {
                    children.Add(new ParseNode(this, line.Substring(line.IndexOf(" ") + 1, line.IndexOf(")") - line.IndexOf(" ") - 1), true));
                }
                else
                {
                    for (int i = line.IndexOf(" ") + 1; i < line.Length; i++)
                    {
                        if (line[i] != ' ' || parenthesisCount > 0)
                        {
                            childLine += line[i];
                        }

                        if (line[i] == '(')
                        {
                            parenthesisCount++;
                        }
                        else
                        {
                            if (line[i] == ')')
                            {
                                parenthesisCount--;
                            }
                        }

                        if (parenthesisCount == 0 && childLine != "")
                        {
                            children.Add(new ParseNode(this, childLine.Trim(), false));
                            childLine = "";
                        }
                    }
                }
            }
        }

        /**
         * <summary> Another simple constructor for ParseNode. It takes inputs left and right children of this node, and the data.
         * Sets the corresponding attributes with these inputs.</summary>
         * <param name="left">Left child of this node.</param>
         * <param name="right">Right child of this node.</param>
         * <param name="data">Data for this node.</param>
         */
        public ParseNode(ParseNode left, ParseNode right, Symbol data)
        {
            children = new List<ParseNode> {left};
            left.parent = this;
            children.Add(right);
            right.parent = this;
            this.data = data;
        }

        /**
         * <summary> Another simple constructor for ParseNode. It takes inputs left child of this node and the data.
         * Sets the corresponding attributes with these inputs.</summary>
         * <param name="left">Left child of this node.</param>
         * <param name="data">Data for this node.</param>
         */
        public ParseNode(ParseNode left, Symbol data)
        {
            children = new List<ParseNode> {left};
            left.parent = this;
            this.data = data;
        }

        /**
         * <summary> Another simple constructor for ParseNode. It only take input the data, and sets it.</summary>
         * <param name="data">Data for this node.</param>
         */
        public ParseNode(Symbol data)
        {
            children = new List<ParseNode>();
            this.data = data;
        }

        /**
         * <summary> Extracts the head of the children of this current node.</summary>
         * <param name="priorityList">Depending on the pos of current node, the priorities among the children are given with this parameter</param>
         * <param name="direction">Depending on the pos of the current node, search direction is either from left to right, or from
         *                  right to left.</param>
         * <param name="defaultCase">If true, and no child appears in the priority list, returns first child on the left, or first
         *                    child on the right depending on the search direction.</param>
         * <returns>Head node of the children of the current node</returns>
         */
        private ParseNode SearchHeadChild(string[] priorityList, SearchDirectionType direction, bool defaultCase)
        {
            switch (direction)
            {
                case SearchDirectionType.LEFT:
                    foreach (var item in priorityList)
                    {
                        foreach (var child in children)
                        {
                            if (child.GetData().TrimSymbol().GetName().Equals(item))
                            {
                                return child;
                            }
                        }
                    }

                    if (defaultCase)
                    {
                        return FirstChild();
                    }

                    break;
                case SearchDirectionType.RIGHT:
                    foreach (var item in priorityList)
                    {
                        for (var j = children.Count - 1; j >= 0; j--)
                        {
                            var child = children[j];
                            if (child.GetData().TrimSymbol().GetName().Equals(item))
                            {
                                return child;
                            }
                        }
                    }

                    if (defaultCase)
                    {
                        return LastChild();
                    }

                    break;
            }

            return null;
        }

        /**
         * <summary> If current node is not a leaf, it has one or more children, this method determines recursively the head of
         * that (those) child(ren). Otherwise, it returns itself. In this way, this method returns the head of all leaf
         * successors.</summary>
         * <returns>Head node of the descendant leaves of this current node.</returns>
         */
        public ParseNode HeadLeaf()
        {
            if (children.Count > 0)
            {
                var head = HeadChild();
                if (head != null)
                {
                    return head.HeadLeaf();
                }

                return null;
            }

            return this;
        }

        /**
         * <summary> Calls SearchHeadChild to determine the head node of all children of this current node. The search direction and
         * the search priority list is determined according to the symbol in this current parent node.</summary>
         * <returns>Head node among its children of this current node.</returns>
         */
        public ParseNode HeadChild()
        {
            switch (data.TrimSymbol().ToString())
            {
                case "ADJP":
                    return SearchHeadChild(ADJP, SearchDirectionType.LEFT, true);
                case "ADVP":
                    return SearchHeadChild(ADVP, SearchDirectionType.RIGHT, true);
                case "CONJP":
                    return SearchHeadChild(CONJP, SearchDirectionType.RIGHT, true);
                case "FRAG":
                    return SearchHeadChild(FRAG, SearchDirectionType.RIGHT, true);
                case "INTJ":
                    return SearchHeadChild(INTJ, SearchDirectionType.LEFT, true);
                case "LST":
                    return SearchHeadChild(LST, SearchDirectionType.RIGHT, true);
                case "NAC":
                    return SearchHeadChild(NAC, SearchDirectionType.LEFT, true);
                case "PP":
                    return SearchHeadChild(PP, SearchDirectionType.RIGHT, true);
                case "PRN":
                    return SearchHeadChild(PRN, SearchDirectionType.LEFT, true);
                case "PRT":
                    return SearchHeadChild(PRT, SearchDirectionType.RIGHT, true);
                case "QP":
                    return SearchHeadChild(QP, SearchDirectionType.LEFT, true);
                case "RRC":
                    return SearchHeadChild(RRC, SearchDirectionType.RIGHT, true);
                case "S":
                    return SearchHeadChild(S, SearchDirectionType.LEFT, true);
                case "SBAR":
                    return SearchHeadChild(SBAR, SearchDirectionType.LEFT, true);
                case "SBARQ":
                    return SearchHeadChild(SBARQ, SearchDirectionType.LEFT, true);
                case "SINV":
                    return SearchHeadChild(SINV, SearchDirectionType.LEFT, true);
                case "SQ":
                    return SearchHeadChild(SQ, SearchDirectionType.LEFT, true);
                case "UCP":
                    return SearchHeadChild(UCP, SearchDirectionType.RIGHT, true);
                case "VP":
                    return SearchHeadChild(VP, SearchDirectionType.LEFT, true);
                case "WHADJP":
                    return SearchHeadChild(WHADJP, SearchDirectionType.LEFT, true);
                case "WHADVP":
                    return SearchHeadChild(WHADVP, SearchDirectionType.RIGHT, true);
                case "WHNP":
                    return SearchHeadChild(WHNP, SearchDirectionType.LEFT, true);
                case "WHPP":
                    return SearchHeadChild(WHPP, SearchDirectionType.RIGHT, true);
                case "NP":
                    if (LastChild().GetData().GetName().Equals("POS"))
                    {
                        return LastChild();
                    }
                    else
                    {
                        var result = SearchHeadChild(NP1, SearchDirectionType.RIGHT, false);
                        if (result != null)
                        {
                            return result;
                        }

                        result = SearchHeadChild(NP2, SearchDirectionType.LEFT, false);
                        if (result != null)
                        {
                            return result;
                        }

                        result = SearchHeadChild(NP3, SearchDirectionType.RIGHT, false);
                        if (result != null)
                        {
                            return result;
                        }

                        result = SearchHeadChild(NP4, SearchDirectionType.RIGHT, false);
                        if (result != null)
                        {
                            return result;
                        }

                        result = SearchHeadChild(NP5, SearchDirectionType.RIGHT, false);
                        if (result != null)
                        {
                            return result;
                        }

                        return LastChild();
                    }
            }

            return null;
        }

        public void ConstructUniversalDependencies(Dictionary<ParseNode, UniversalDependencyRelation> dependencies)
        {
        }

        /**
         * <summary> Returns an iterator for the child nodes of this {@link ParseNode}.</summary>
         * <returns>Iterator for the children of this very node.</returns>
         */
        public List<ParseNode>.Enumerator GetChildIterator()
        {
            return children.GetEnumerator();
        }

        /**
         * <summary> Adds a child node at the end of the children node list.</summary>
         * <param name="child">Child node to be added.</param>
         */
        public void AddChild(ParseNode child)
        {
            children.Add(child);
            child.parent = this;
        }

        /**
         * <summary> Recursive method to restore the parents of all nodes below this node in the hierarchy.</summary>
         */
        public void CorrectParents()
        {
            foreach (var child in children)
            {
                child.parent = this;
                child.CorrectParents();
            }
        }

        /**
         * <summary> Recursive method to remove all nodes starting with the symbol X. If the node is removed, its children are
         * connected to the next sibling of the deleted node.</summary>
         */
        public void RemoveXNodes()
        {
            int i = 0;
            while (i < children.Count)
            {
                if (children[i].GetData().GetName().StartsWith("X"))
                {
                    children.InsertRange(i + 1, children[i].children);
                    children.RemoveAt(i);
                }
                else
                {
                    i++;
                }
            }

            foreach (var child in children)
            {
                child.RemoveXNodes();
            }
        }

        /**
         * <summary> Adds a child node at the given specific index in the children node list.</summary>
         * <param name="index">Index where the new child node will be added.</param>
         * <param name="child">Child node to be added.</param>
         */
        public void AddChild(int index, ParseNode child)
        {
            children.Insert(index, child);
            child.parent = this;
        }

        /**
         * <summary> Replaces a child node at the given specific with a new child node.</summary>
         * <param name="index">Index where the new child node replaces the old one.</param>
         * <param name="child">Child node to be replaced.</param>
         */
        public void SetChild(int index, ParseNode child)
        {
            children[index] = child;
        }

        /**
         * <summary> Removes a given child from children node list.</summary>
         * <param name="child">Child node to be deleted.</param>
         */
        public void RemoveChild(ParseNode child)
        {
            for (var i = 0; i < children.Count; i++)
            {
                if (children[i] == child)
                {
                    children.RemoveAt(i);
                    break;
                }
            }
        }

        /**
         * <summary> Recursive method to calculate the number of all leaf nodes in the subtree rooted with this current node.</summary>
         * <returns>Number of all leaf nodes in the current subtree.</returns>
         */
        public int LeafCount()
        {
            if (children.Count == 0)
            {
                return 1;
            }

            var sum = 0;
            foreach (var child in children)
            {
                sum += child.LeafCount();
            }

            return sum;
        }

        /**
         * <summary> Recursive method to calculate the number of all nodes in the subtree rooted with this current node.</summary>
         * <returns>Number of all nodes in the current subtree.</returns>
         */
        public int NodeCount()
        {
            if (children.Count > 0)
            {
                var sum = 1;
                foreach (var child in children)
                {
                    sum += child.NodeCount();
                }

                return sum;
            }

            return 1;
        }

        /**
         * <summary> Recursive method to calculate the number of all nodes, which have more than one children, in the subtree rooted
         * with this current node.</summary>
         * <returns>Number of all nodes, which have more than one children, in the current subtree.</returns>
         */
        public int NodeCountWithMultipleChildren()
        {
            if (children.Count > 1)
            {
                var sum = 1;
                foreach (var child in children)
                {
                    sum += child.NodeCountWithMultipleChildren();
                }

                return sum;
            }

            return 0;
        }

        /**
         * <summary> Recursive method to remove all punctuation nodes from the current subtree.</summary>
         */
        public void StripPunctuation()
        {
            children.RemoveAll(x => Word.IsPunctuation(x.GetData().GetName()));
            foreach (var node in children)
            {
                node.StripPunctuation();
            }
        }

        /**
         * <summary> Returns number of children of this node.</summary>
         * <returns>Number of children of this node.</returns>
         */
        public int NumberOfChildren()
        {
            return children.Count;
        }

        /**
         * <summary> Returns the i'th child of this node.</summary>
         * <param name="i">Index of the retrieved node.</param>
         * <returns>i'th child of this node.</returns>
         */
        public ParseNode GetChild(int i)
        {
            return children[i];
        }

        /**
         * <summary> Returns the first child of this node.</summary>
         * <returns>First child of this node.</returns>
         */
        public ParseNode FirstChild()
        {
            return children[0];
        }

        /**
         * <summary> Returns the last child of this node.</summary>
         * <returns>Last child of this node.</returns>
         */
        public ParseNode LastChild()
        {
            return children[children.Count - 1];
        }

        /**
         * <summary> Checks if the given node is the last child of this node.</summary>
         * <param name="child">To be checked node.</param>
         * <returns>True, if child is the last child of this node, false otherwise.</returns>
         */
        public bool IsLastChild(ParseNode child)
        {
            return LastChild() == child;
        }

        /**
         * <summary> Returns the index of the given child of this node.</summary>
         * <returns>Index of the child of this node.</returns>
         */
        public int GetChildIndex(ParseNode child)
        {
            return children.IndexOf(child);
        }

        /**
         * <summary> Returns true if the given node is a descendant of this node.</summary>
         * <returns>True if the given node is descendant of this node.</returns>
         */
        public bool IsDescendant(ParseNode node)
        {
            foreach (var aChild in children)
            {
                if (aChild.Equals(node))
                {
                    return true;
                }
                else
                {
                    if (aChild.IsDescendant(node))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /**
         * <summary> Returns the previous sibling (sister) of this node.</summary>
         * <returns>If this is the first child of its parent, returns null. Otherwise, returns the previous sibling of this
         * node.</returns>
         */
        public ParseNode PreviousSibling()
        {
            for (var i = 1; i < parent.children.Count; i++)
            {
                if (parent.children[i] == this)
                {
                    return parent.children[i - 1];
                }
            }

            return null;
        }

        /**
         * <summary> Returns the next sibling (sister) of this node.</summary>
         * <returns>If this is the last child of its parent, returns null. Otherwise, returns the next sibling of this
         * node.</returns>
         */
        public ParseNode NextSibling()
        {
            for (var i = 0; i < parent.children.Count - 1; i++)
            {
                if (parent.children[i] == this)
                {
                    return parent.children[i + 1];
                }
            }

            return null;
        }

        /**
         * <summary> Accessor for the parent attribute.</summary>
         * <returns>Parent of this node.</returns>
         */
        public ParseNode GetParent()
        {
            return parent;
        }

        /**
         * <summary> Accessor for the data attribute.</summary>
         * <returns>Data of this node.</returns>
         */
        public Symbol GetData()
        {
            return data;
        }

        /**
         * <summary> Mutator of the data attribute.</summary>
         * <param name="data">Data to be set.</param>
         */
        public void SetData(Symbol data)
        {
            this.data = data;
        }

        /**
         * <summary> Recursive function to count the number of words in the subtree rooted at this node.</summary>
         * <param name="excludeStopWords">If true, stop words are not counted.</param>
         * <returns>Number of words in the subtree rooted at this node.</returns>
         */
        public int WordCount(bool excludeStopWords)
        {
            int sum;
            if (children.Count == 0)
            {
                if (!excludeStopWords)
                {
                    sum = 1;
                }
                else
                {
                    if (data.GetName().Equals(",") || data.GetName().Equals(".") ||
                        data.GetName().Equals(";")
                        || data.GetName().Contains("*") || data.GetName().Equals("at") ||
                        data.GetName().Equals("the")
                        || data.GetName().Equals("to") || data.GetName().Equals("a") ||
                        data.GetName().Equals("an")
                        || data.GetName().Equals("not") || data.GetName().Equals("is") ||
                        data.GetName().Equals("was")
                        || data.GetName().Equals("were") || data.GetName().Equals("have") ||
                        data.GetName().Equals("had")
                        || data.GetName().Equals("has") || data.GetName().Equals("!") ||
                        data.GetName().Equals("?")
                        || data.GetName().Equals("by") || data.GetName().Equals("at") ||
                        data.GetName().Equals("on")
                        || data.GetName().Equals("off") || data.GetName().Equals("'s") ||
                        data.GetName().Equals("n't")
                        || data.GetName().Equals("can") || data.GetName().Equals("could") ||
                        data.GetName().Equals("may")
                        || data.GetName().Equals("might") || data.GetName().Equals("will") ||
                        data.GetName().Equals("would")
                        || data.GetName().Equals("''") || data.GetName().Equals("'") ||
                        data.GetName().Equals("\"")
                        || data.GetName().Equals("\"\"") || data.GetName().Equals("as") ||
                        data.GetName().Equals("with")
                        || data.GetName().Equals("for") || data.GetName().Equals("will") ||
                        data.GetName().Equals("would")
                        || data.GetName().Equals("than") || data.GetName().Equals("``") ||
                        data.GetName().Equals("$")
                        || data.GetName().Equals("and") || data.GetName().Equals("or") ||
                        data.GetName().Equals("of")
                        || data.GetName().Equals("are") || data.GetName().Equals("be") ||
                        data.GetName().Equals("been")
                        || data.GetName().Equals("do") || data.GetName().Equals("few") ||
                        data.GetName().Equals("there")
                        || data.GetName().Equals("up") || data.GetName().Equals("down"))
                    {
                        sum = 0;
                    }
                    else
                    {
                        sum = 1;
                    }
                }
            }
            else
            {
                sum = 0;
            }

            foreach (var aChild in children)
            {
                sum += aChild.WordCount(excludeStopWords);
            }

            return sum;
        }

        /**
         * <summary> Returns true if this node is leaf, false otherwise.</summary>
         * <returns>true if this node is leaf, false otherwise.</returns>
         */
        public bool IsLeaf()
        {
            return children.Count == 0;
        }

        /**
         * <summary> Returns true if this node does not contain a meaningful data, false otherwise.</summary>
         * <returns>true if this node does not contain a meaningful data, false otherwise.</returns>
         */
        public bool IsDummyNode()
        {
            return GetData().GetName().Contains("*") ||
                   (GetData().GetName().Equals("0") && parent.GetData().GetName().Equals("-NONE-"));
        }

        /**
         * <summary> Recursive function to convert the subtree rooted at this node to a sentence.</summary>
         * <returns>A sentence which contains all words in the subtree rooted at this node.</returns>
         */
        public string ToSentence()
        {
            if (children.Count == 0)
            {
                if (GetData() != null && !IsDummyNode())
                {
                    return " " + GetData().GetName().Replace("-LRB-", "(").Replace("-RRB-", ")")
                        .Replace("-LSB-", "[").Replace("-RSB-", "]").Replace("-LCB-", "{")
                        .Replace("-RCB-", "}").Replace("-lrb-", "(").Replace("-rrb-", ")")
                        .Replace("-lsb-", "[").Replace("-rsb-", "]").Replace("-lcb-", "{")
                        .Replace("-rcb-", "}");
                }

                return " ";
            }

            var st = "";
            foreach (var aChild in children)
            {
                st += aChild.ToSentence();
            }

            return st;
        }

        /**
         * <summary> Recursive function to convert the subtree rooted at this node to a string.</summary>
         * <returns>A string which contains all words in the subtree rooted at this node.</returns>
         */
        public override string ToString()
        {
            if (children.Count < 2)
            {
                if (children.Count < 1)
                {
                    return GetData().GetName();
                }

                return "(" + data.GetName() + " " + FirstChild() + ")";
            }

            var st = "(" + data.GetName();
            foreach (var aChild in children)
            {
                st = st + " " + aChild;
            }

            return st + ") ";
        }

        /**
         * <summary> Swaps the given child node of this node with the previous sibling of that given node. If the given node is the
         * leftmost child, it swaps with the last node.</summary>
         * <param name="node">Node to be swapped.</param>
         */
        public void MoveLeft(ParseNode node)
        {
            int i;
            for (i = 0; i < children.Count; i++)
            {
                if (children[i] == node)
                {
                    if (i == 0)
                    {
                        var tmp = children[0];
                        children[0] = children[children.Count - 1];
                        children[children.Count - 1] = tmp;
                    }
                    else
                    {
                        var tmp = children[i];
                        children[i] = children[(i - 1) % children.Count];
                        children[(i - 1) % children.Count] = tmp;
                    }

                    return;
                }
            }

            foreach (var aChild in children)
            {
                aChild.MoveLeft(node);
            }
        }

        /**
         * <summary> Recursive function to concatenate the data of the all ascendant nodes of this node to a string.</summary>
         * <returns>A string which contains all data of all the ascendant nodes of this node.</returns>
         */
        public string AncestorString()
        {
            if (parent == null)
            {
                return data.GetName();
            }

            return parent.AncestorString() + data.GetName();
        }

        /**
         * <summary> Swaps the given child node of this node with the next sibling of that given node. If the given node is the
         * rightmost child, it swaps with the first node.</summary>
         * <param name="node">Node to be swapped.</param>
         */
        public void MoveRight(ParseNode node)
        {
            int i;
            for (i = 0; i < children.Count; i++)
            {
                if (children[i] == node)
                {
                    var tmp = children[i];
                    children[i] = children[(i + 1) % children.Count];
                    children[(i + 1) % children.Count] = tmp;
                    return;
                }
            }

            foreach (var aChild in children)
            {
                aChild.MoveRight(node);
            }
        }
    }
}