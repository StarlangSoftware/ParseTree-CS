namespace ParseTree.NodeCondition
{
    public class IsEnglishLeaf : IsLeaf, NodeCondition
    {
        /**
         * <summary> Implemented node condition for English leaf node.</summary>
         * <param name="parseNode">Checked node.</param>
         * <returns>If the node is a leaf node and is not a dummy node, returns true; false otherwise.</returns>
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