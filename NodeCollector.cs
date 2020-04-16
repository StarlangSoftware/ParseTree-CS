using System.Collections.Generic;

namespace ParseTree
{
    public class NodeCollector
    {
        private readonly NodeCondition.NodeCondition _condition;
        private readonly ParseNode _rootNode;

        /**
         * Constructor for the NodeCollector class. NodeCollector's main aim is to collect a set of ParseNode's from a
         * subtree rooted at rootNode, where the ParseNode's satisfy a given NodeCondition, which is implemented by other
         * interface class.
         * @param rootNode Root node of the subtree
         * @param condition The condition interface for which all nodes in the subtree rooted at rootNode will be checked
         */
        public NodeCollector(ParseNode rootNode, NodeCondition.NodeCondition condition)
        {
            this._rootNode = rootNode;
            this._condition = condition;
        }

        /**
         * Private recursive method to check all descendants of the parseNode, if they ever satisfy the given node condition
         * @param parseNode Root node of the subtree
         * @param collected The {@link ArrayList} where the collected ParseNode's will be stored.
         */
        private void CollectNodes(ParseNode parseNode, List<ParseNode> collected)
        {
            if (_condition.Satisfies(parseNode))
            {
                collected.Add(parseNode);
            }
            else
            {
                for (var i = 0; i < parseNode.NumberOfChildren(); i++)
                {
                    CollectNodes(parseNode.GetChild(i), collected);
                }
            }
        }

        /**
         * Collects and returns all ParseNode's satisfying the node condition.
         * @return All ParseNode's satisfying the node condition.
         */
        public List<ParseNode> Collect()
        {
            var result = new List<ParseNode>();
            CollectNodes(_rootNode, result);
            return result;
        }
    }
}