namespace ParseTree.NodeCondition
{
    public class IsLeaf : NodeCondition
    {
        /**
         * <summary> Implemented node condition for the leaf node. If a node has no children it is a leaf node.</summary>
         * <param name="parseNode">Checked node.</param>
         * <returns>True if the input node is a leaf node, false otherwise.</returns>
         */
        public bool Satisfies(ParseNode parseNode)
        {
            return parseNode.NumberOfChildren() == 0;
        }
    }
}