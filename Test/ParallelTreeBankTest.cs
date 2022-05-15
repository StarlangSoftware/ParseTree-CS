using NUnit.Framework;
using ParseTree;

namespace Test
{
    public class ParallelTreeBankTest
    {
        [Test]
        public void TestParallelTreeBank()
        {
            var parallelTreeBank = new ParallelTreeBank("../../../trees", "../../../trees2");
            Assert.AreEqual(3, parallelTreeBank.Size());
        }
    }
}