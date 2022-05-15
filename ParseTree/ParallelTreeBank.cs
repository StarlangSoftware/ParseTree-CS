using System;

namespace ParseTree
{
    public class ParallelTreeBank
    {
        protected readonly TreeBank _fromTreeBank;
        protected readonly TreeBank _toTreeBank;

        private void RemoveDifferentTrees()
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

        public ParallelTreeBank(string folder1, string folder2)
        {
            _fromTreeBank = new TreeBank(folder1);
            _toTreeBank = new TreeBank(folder2);
            RemoveDifferentTrees();
        }

        public ParallelTreeBank(string folder1, string folder2, string pattern)
        {
            _fromTreeBank = new TreeBank(folder1, pattern);
            _toTreeBank = new TreeBank(folder2, pattern);
            RemoveDifferentTrees();
        }

        public int Size()
        {
            return _fromTreeBank.Size();
        }

        public ParseTree FromTree(int index)
        {
            return _fromTreeBank.Get(index);
        }

        public ParseTree ToTree(int index)
        {
            return _toTreeBank.Get(index);
        }

        public TreeBank FromTreeBank()
        {
            return _fromTreeBank;
        }

        public TreeBank ToTreeBank()
        {
            return _toTreeBank;
        }
    }
}