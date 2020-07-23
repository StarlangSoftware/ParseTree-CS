namespace ParseTree.NodeCondition
{
    public interface NodeCondition
    {
        bool Satisfies(ParseNode parseNode);
    }
}