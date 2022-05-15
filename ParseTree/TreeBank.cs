using System;
using System.Collections.Generic;
using System.IO;

namespace ParseTree
{
    public class TreeBank
    {
        protected List<ParseTree> parseTrees;

        /**
         * <summary> Empty constructor for TreeBank.</summary>
         */
        public TreeBank()
        {
        }

        /**
         * <summary> A constructor of {@link TreeBank} class which reads all {@link ParseTree} files inside the given folder. For each
         * file inside that folder, the constructor creates a ParseTree and puts in inside the list parseTrees.</summary>
         */
        public TreeBank(string folder)
        {
            parseTrees = new List<ParseTree>();
            var listOfFiles = Directory.GetFiles(folder);
            Array.Sort(listOfFiles);
            foreach (var file in listOfFiles){
                var parseTree = new ParseTree(file);
                if (parseTree.GetRoot() != null)
                {
                    parseTree.SetName(RemovePath(file));
                    parseTrees.Add(parseTree);
                }
                else
                {
                    Console.WriteLine("Parse Tree " + file + " can not be read");
                }
            }
        }

        /**
         * <summary> A constructor of {@link TreeBank} class which reads all {@link ParseTree} files with the file name satisfying the
         * given pattern inside the given folder. For each file inside that folder, the constructor creates a ParseTree
         * and puts in inside the list parseTrees.</summary>
         * <param name="folder">Folder where all parseTrees reside.</param>
         * <param name="pattern">File pattern such as "." ".train" ".test".</param>
         */
        public TreeBank(string folder, string pattern)
        {
            parseTrees = new List<ParseTree>();
            var listOfFiles = Directory.GetFiles(folder);
            Array.Sort(listOfFiles);
            foreach (var file in listOfFiles){
                if (!file.Contains(pattern))
                    continue;
                var parseTree = new ParseTree(file);
                if (parseTree.GetRoot() != null)
                {
                    parseTree.SetName(RemovePath(file));
                    parseTrees.Add(parseTree);
                }
                else
                {
                    Console.WriteLine("Parse Tree " + file + " can not be read");
                }
            }
        }

        /**
         * <summary> A constructor of {@link TreeBank} class which reads the files numbered from from to to with the file name
         * satisfying the given pattern inside the given folder. For each file inside that folder, the constructor
         * creates a ParseTree and puts in inside the list parseTrees.</summary>
         * <param name="folder">Folder where all parseTrees reside.</param>
         * <param name="pattern">File pattern such as "." ".train" ".test".</param>
         * <param name="from">Starting index for the ParseTrees read.</param>
         * <param name="to">Ending index for the ParseTrees read.</param>
         */
        public TreeBank(string folder, string pattern, int from, int to)
        {
            parseTrees = new List<ParseTree>();
            for (var i = from; i <= to; i++)
            {
                var parseTree = new ParseTree(folder + "/" + string.Format("{0:D4}", i) + pattern);
                parseTree.SetName(string.Format("{0:D4}", i) + pattern);
                parseTrees.Add(parseTree);
            }
        }

        protected string RemovePath(string fileName)
        {
            if (fileName.Contains("/"))
            {
                return fileName.Substring(fileName.LastIndexOf("/", StringComparison.Ordinal) + 1);
            }

            if (fileName.Contains("\\"))
            {
                return fileName.Substring(fileName.LastIndexOf("\\", StringComparison.Ordinal) + 1);
            }

            return fileName;
        }
        
        /**
         * <summary> Strips punctuation symbols from all parseTrees in this TreeBank.</summary>
         */
        public void StripPunctuation()
        {
            foreach (var tree in parseTrees)
            {
                tree.StripPunctuation();
            }
        }

        /**
         * <summary> Returns number of trees in the TreeBank.</summary>
         * <returns>Number of trees in the TreeBank.</returns>
         */
        public int Size()
        {
            return parseTrees.Count;
        }

        /**
         * <summary> Returns number of words in the parseTrees in the TreeBank. If excludeStopWords is true, stop words are not
         * counted.</summary>
         * <param name="excludeStopWords">If true, stop words are not included in the count process.</param>
         * <returns>Number of all words in all parseTrees in the TreeBank.</returns>
         */
        public int WordCount(bool excludeStopWords)
        {
            var count = 0;
            foreach (var tree in parseTrees)
            {
                count += tree.WordCount(excludeStopWords);
            }

            return count;
        }

        /**
         * <summary> Accessor for a single ParseTree.</summary>
         * <param name="index">Index of the parseTree.</param>
         * <returns>The ParseTree at the given index.</returns>
         */
        public ParseTree Get(int index)
        {
            return parseTrees[index];
        }
        
        public void RemoveTree(int index){
            parseTrees.RemoveAt(index);
        }
    }
}