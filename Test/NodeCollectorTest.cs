using NUnit.Framework;
using ParseTree;
using ParseTree.NodeCondition;

namespace Test
{
    public class NodeCollectorTest
    {
        ParseTree.ParseTree parseTree1;
        ParseTree.ParseTree parseTree2;
        ParseTree.ParseTree parseTree3;
        ParseTree.ParseTree parseTree4;
        ParseTree.ParseTree parseTree5;

        [SetUp]
        public void Setup()
        {
            parseTree1 = new ParseTree.ParseTree("../../../trees/0000.dev");
            parseTree2 = new ParseTree.ParseTree("../../../trees/0001.dev");
            parseTree3 = new ParseTree.ParseTree("../../../trees/0002.dev");
            parseTree4 = new ParseTree.ParseTree("../../../trees/0003.dev");
            parseTree5 = new ParseTree.ParseTree("../../../trees/0014.dev");
        }

        [Test]
        public void TestCollectLeaf()
        {
            NodeCollector nodeCollector1 = new NodeCollector(parseTree1.GetRoot(), new IsLeaf());
            Assert.AreEqual(13, nodeCollector1.Collect().Count);
            nodeCollector1 = new NodeCollector(parseTree2.GetRoot(), new IsLeaf());
            Assert.AreEqual(15, nodeCollector1.Collect().Count);
            nodeCollector1 = new NodeCollector(parseTree3.GetRoot(), new IsLeaf());
            Assert.AreEqual(10, nodeCollector1.Collect().Count);
            nodeCollector1 = new NodeCollector(parseTree4.GetRoot(), new IsLeaf());
            Assert.AreEqual(10, nodeCollector1.Collect().Count);
            nodeCollector1 = new NodeCollector(parseTree5.GetRoot(), new IsLeaf());
            Assert.AreEqual(4, nodeCollector1.Collect().Count);
        }

        [Test]
        public void TestCollectEnglish()
        {
            var nodeCollector1 = new NodeCollector(parseTree1.GetRoot(), new IsEnglishLeaf());
            Assert.AreEqual(13, nodeCollector1.Collect().Count);
            nodeCollector1 = new NodeCollector(parseTree2.GetRoot(), new IsEnglishLeaf());
            Assert.AreEqual(15, nodeCollector1.Collect().Count);
            nodeCollector1 = new NodeCollector(parseTree3.GetRoot(), new IsEnglishLeaf());
            Assert.AreEqual(9, nodeCollector1.Collect().Count);
            nodeCollector1 = new NodeCollector(parseTree4.GetRoot(), new IsEnglishLeaf());
            Assert.AreEqual(10, nodeCollector1.Collect().Count);
            nodeCollector1 = new NodeCollector(parseTree5.GetRoot(), new IsEnglishLeaf());
            Assert.AreEqual(4, nodeCollector1.Collect().Count);
        }
    }
}