using NUnit.Framework;
using ParseTree;

namespace Test
{
    public class ParseTreeTest
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
        public void TestNodeCount()
        {
            Assert.AreEqual(34, parseTree1.NodeCount());
            Assert.AreEqual(39, parseTree2.NodeCount());
            Assert.AreEqual(32, parseTree3.NodeCount());
            Assert.AreEqual(28, parseTree4.NodeCount());
            Assert.AreEqual(9, parseTree5.NodeCount());
        }

        [Test]

        public void TestIsFullSentence()
        {
            Assert.True(parseTree1.IsFullSentence());
            Assert.True(parseTree2.IsFullSentence());
            Assert.True(parseTree3.IsFullSentence());
            Assert.True(parseTree4.IsFullSentence());
            Assert.False(parseTree5.IsFullSentence());
        }

        [Test]

        public void TestLeafCount()
        {
            Assert.AreEqual(13, parseTree1.LeafCount());
            Assert.AreEqual(15, parseTree2.LeafCount());
            Assert.AreEqual(10, parseTree3.LeafCount());
            Assert.AreEqual(10, parseTree4.LeafCount());
            Assert.AreEqual(4, parseTree5.LeafCount());
        }

        [Test]

        public void TestNodeCountWithMultipleChildren()
        {
            Assert.AreEqual(8, parseTree1.NodeCountWithMultipleChildren());
            Assert.AreEqual(9, parseTree2.NodeCountWithMultipleChildren());
            Assert.AreEqual(8, parseTree3.NodeCountWithMultipleChildren());
            Assert.AreEqual(6, parseTree4.NodeCountWithMultipleChildren());
            Assert.AreEqual(1, parseTree5.NodeCountWithMultipleChildren());
        }

        [Test]

        public void TestWordCount()
        {
            Assert.AreEqual(7, parseTree1.WordCount(true));
            Assert.AreEqual(8, parseTree2.WordCount(true));
            Assert.AreEqual(6, parseTree3.WordCount(true));
            Assert.AreEqual(7, parseTree4.WordCount(true));
            Assert.AreEqual(2, parseTree5.WordCount(true));
        }

        [Test]

        public void TestToSentence()
        {
            Assert.AreEqual(" The complicated language in the huge new law has muddied the fight .",
                parseTree1.ToSentence());
            Assert.AreEqual(" The Ways and Means Committee will hold a hearing on the bill next Tuesday .",
                parseTree2.ToSentence());
            Assert.AreEqual(" We 're about to see if advertising works .", parseTree3.ToSentence());
            Assert.AreEqual(" This time around , they 're moving even faster .", parseTree4.ToSentence());
            Assert.AreEqual(" Ad Notes ... .", parseTree5.ToSentence());
        }
        
        [Test]
        public void TestConstituentSpan(){
            var span = parseTree1.ConstituentSpanList()[6];
            Assert.AreEqual(new Symbol("PP-LOC"), span.GetConstituent());
            Assert.AreEqual(4, span.GetStart());
            Assert.AreEqual(9, span.GetEnd());
            span = parseTree2.ConstituentSpanList()[10];
            Assert.AreEqual(new Symbol("VB"), span.GetConstituent());
            Assert.AreEqual(7, span.GetStart());
            Assert.AreEqual(8, span.GetEnd());
            span = parseTree3.ConstituentSpanList()[0];
            Assert.AreEqual(new Symbol("S"), span.GetConstituent());
            Assert.AreEqual(1, span.GetStart());
            Assert.AreEqual(11, span.GetEnd());
            span = parseTree4.ConstituentSpanList()[5];
            Assert.AreEqual(new Symbol("ADVP"), span.GetConstituent());
            Assert.AreEqual(3, span.GetStart());
            Assert.AreEqual(4, span.GetEnd());
            span = parseTree5.ConstituentSpanList()[4];
            Assert.AreEqual(new Symbol("."), span.GetConstituent());
            Assert.AreEqual(4, span.GetStart());
            Assert.AreEqual(5, span.GetEnd());
        }

        
    }
}