using NUnit.Framework;
using ParseTree;

namespace Test
{
    public class TreeBankTest
    {
        [Test]
        public void TestTreeBank(){
            var treeBank1 = new TreeBank("../../../trees");
            Assert.AreEqual(5, treeBank1.Size());
            Assert.AreEqual(30, treeBank1.WordCount(true));
            var treeBank2 = new TreeBank("../../../trees", ".dev");
            Assert.AreEqual(5, treeBank2.Size());
            Assert.AreEqual(30, treeBank2.WordCount(true));
            var treeBank3 = new TreeBank("../../../trees", ".dev", 0, 3);
            Assert.AreEqual(4, treeBank3.Size());
            Assert.AreEqual(28, treeBank3.WordCount(true));
        }
    }
}