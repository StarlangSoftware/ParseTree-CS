namespace ParseTree.NodeCondition
{
    public class IsEnglishLeaf : IsLeaf
    {
        /**
         * Implemented node condition for English leaf node.
         * @param parseNode Checked node.
         * @return If the node is a leaf node and is not a dummy node, returns true; false otherwise.
         */
        public new bool Satisfies(ParseNode parseNode)
        {
            if (base.Satisfies(parseNode))
            {
                var data = parseNode.GetData().GetName();
                var parentData = parseNode.GetParent().GetData().GetName();
                if (data.Contains("*") || (data.Equals("0") && parentData.Equals("-NONE-")))
                {
                    return false;
                }

                return true;
            }

            return false;
        }
    }
}