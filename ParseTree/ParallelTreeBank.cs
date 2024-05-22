using System;

namespace ParseTree
{
    public class ParallelTreeBank
    {
        protected TreeBank _fromTreeBank;
        protected TreeBank _toTreeBank;

        /// <summary>
        /// Empty constructor for the parallel treebank.
        /// </summary>
        public ParallelTreeBank()
        {
            
        }

        /// <summary>
        /// Constructor for the ParallelTreeBank class. A ParallelTreeBank consists of two treebanks, where each sentence
        /// appears in both treebanks with possibly different tree structures. Each treebank is stored in a separate folder.
        /// Both treebanks are read and distinct sentences are removed from the treebanks.
        /// </summary>
        /// <param name="folder1">Folder containing the files for trees in the first treebank.</param>
        /// <param name="folder2">Folder containing the files for trees in the second treebank.</param>
        public ParallelTreeBank(string folder1, string folder2)
        {
            _fromTreeBank = new TreeBank(folder1);
            _toTreeBank = new TreeBank(folder2);
            RemoveDifferentTrees();
        }

        /// <summary>
        /// Another constructor for the ParallelTreeBank class. A ParallelTreeBank consists of two treebanks, where each
        /// sentence appears in both treebanks with possibly different tree structures. Each treebank is stored in a separate
        /// folder. Both treebanks are read and distinct sentences are removed from the treebanks. In thid constructor, only
        /// files matching the pattern are read. Pattern is used for matching the extensions such as .train, .test, .dev.
        /// </summary>
        /// <param name="folder1">Folder containing the files for trees in the first treebank.</param>
        /// <param name="folder2">Folder containing the files for trees in the second treebank.</param>
        /// <param name="pattern">File pattern used for matching. Patterns are usually used for setting the extensions such as
        ///                .train, .test, .dev.</param>
        public ParallelTreeBank(string folder1, string folder2, string pattern)
        {
            _fromTreeBank = new TreeBank(folder1, pattern);
            _toTreeBank = new TreeBank(folder2, pattern);
            RemoveDifferentTrees();
        }

        /// <summary>
        /// Given two treebanks read, the method removes the trees which do not exist in one of the treebanks. At the end,
        /// we will only have the tree files that exist in both treebanks.
        /// </summary>
        protected void RemoveDifferentTrees()
        {
            int i, j;
            i = 0;
            j = 0;
            while (i < _fromTreeBank.Size() && j < _toTreeBank.Size())
            {
                if (string.Compare(_fromTreeBank.Get(i).GetName(), _toTreeBank.Get(j).GetName(), StringComparison.Ordinal) < 0)
                {
                    _fromTreeBank.RemoveTree(i);
                }
                else
                {
                    if (string.Compare(_toTreeBank.Get(j).GetName(), _fromTreeBank.Get(i).GetName(), StringComparison.Ordinal) < 0)
                    {
                        _toTreeBank.RemoveTree(j);
                    }
                    else
                    {
                        i++;
                        j++;
                    }
                }
            }

            while (i < _fromTreeBank.Size())
            {
                _fromTreeBank.RemoveTree(i);
            }

            while (j < _toTreeBank.Size())
            {
                _toTreeBank.RemoveTree(j);
            }
        }
        
        /// <summary>
        /// Returns number of sentences in ParallelTreeBank.
        /// </summary>
        /// <returns>Number of sentences.</returns>
        public int Size()
        {
            return _fromTreeBank.Size();
        }

        /// <summary>
        /// Returns the tree at position index in the first treebank.
        /// </summary>
        /// <param name="index">Position of the tree in the first treebank.</param>
        /// <returns>The tree at position index in the first treebank.</returns>
        public ParseTree FromTree(int index)
        {
            return _fromTreeBank.Get(index);
        }

        /// <summary>
        /// Returns the tree at position index in the second treebank.
        /// </summary>
        /// <param name="index">Position of the tree in the second treebank.</param>
        /// <returns>The tree at position index in the second treebank.</returns>
        public ParseTree ToTree(int index)
        {
            return _toTreeBank.Get(index);
        }

        /// <summary>
        /// Returns the first treebank.
        /// </summary>
        /// <returns>First treebank.</returns>
        public TreeBank FromTreeBank()
        {
            return _fromTreeBank;
        }

        /// <summary>
        /// Returns the second treebank.
        /// </summary>
        /// <returns>Second treebank.</returns>
        public TreeBank ToTreeBank()
        {
            return _toTreeBank;
        }
    }
}