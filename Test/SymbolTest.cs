using NUnit.Framework;
using ParseTree;

namespace Test
{
    public class SymbolTest
    {
        [Test]
        public void TrimSymbol() {
            Assert.AreEqual("NP", new Symbol("NP-SBJ").TrimSymbol().GetName());
            Assert.AreEqual("VP", new Symbol("VP-SBJ-2").TrimSymbol().GetName());
            Assert.AreEqual("NNP", new Symbol("NNP-SBJ-OBJ-TN").TrimSymbol().GetName());
            Assert.AreEqual("S", new Symbol("S-SBJ=OBJ").TrimSymbol().GetName());
        }

    }
}