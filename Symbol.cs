using System.Collections.Generic;
using Dictionary.Dictionary;

namespace ParseTree
{
    public class Symbol : Word
    {
        private readonly List<string> _nonTerminalList = new List<string>(new[]
        {
            "ADJP", "ADVP", "CC", "CD", "CONJP",
            "DT", "EX", "FRAG", "FW", "IN", "INTJ", "JJ", "JJR", "JJS", "LS",
            "LST", "MD", "NAC", "NN", "NNP", "NNPS", "NNS", "NP", "NX", "PDT", "POS", "PP", "PRN", "PRP", "PRP$", "PRT",
            "PRT|ADVP", "QP", "RB", "RBR", "RP", "RRC", "S", "SBAR", "SBARQ", "SINV", "SQ", "SYM", "TO", "UCP", "UH",
            "VB", "VBD", "VBG", "VBN",
            "VBP", "VBZ", "VP", "WDT", "WHADJP", "WHADVP", "WHNP", "WP", "WP$", "WRB", "X", "-NONE-"
        });

        private readonly List<string> _phraseLabels = new List<string>(new[]
            {"NP", "PP", "ADVP", "ADJP", "CC", "VG"});

        private readonly List<string> _sentenceLabels = new List<string>(new[]
            {"SINV", "SBARQ", "SBAR", "SQ", "S"});

        private readonly List<string> _verbLabels = new List<string>(new[]
            {"VB", "VBD", "VBG", "VBN", "VBP", "VBZ", "VERB"});

        private readonly string _vpLabel = "VP";

        /**
         * <summary> Constructor for Symbol class. Sets the name attribute.</summary>
         * <param name="name">Name attribute</param>
         */
        public Symbol(string name) : base(name)
        {
        }

        /**
         * <summary> Checks if this symbol is a verb type.</summary>
         * <returns>True if the symbol is a verb, false otherwise.</returns>
         */
        public bool IsVerb()
        {
            return _verbLabels.Contains(name);
        }

        /**
         * <summary> Checks if the symbol is VP or not.</summary>
         * <returns>True if the symbol is VB, false otherwise.</returns>
         */
        public bool IsVp()
        {
            return name == _vpLabel;
        }

        /**
         * <summary> Checks if this symbol is a terminal symbol or not. A symbol is terminal if it is a punctuation symbol, or
         * if it starts with a lowercase symbol.</summary>
         * <returns>True if this symbol is a terminal symbol, false otherwise.</returns>
         */
        public bool IsTerminal()
        {
            int i;
            if (name.Equals(",") || name.Equals(".") || name.Equals("!") || name.Equals("?") || name.Equals(":")
                || name.Equals(";") || name.Equals("\"") || name.Equals("''") || name.Equals("'") || name.Equals("`")
                || name.Equals("``") || name.Equals("...") || name.Equals("-") || name.Equals("--"))
                return true;
            if (_nonTerminalList.Contains(name))
                return false;
            if (name.Equals("I") || name.Equals("A"))
                return true;
            for (i = 0; i < name.Length; i++)
            {
                if (name[i] >= 'a' && name[i] <= 'z')
                {
                    return true;
                }
            }

            return false;
        }

        /**
         * <summary> Checks if this symbol can be a chunk label or not.</summary>
         * <returns>True if this symbol can be a chunk label, false otherwise.</returns>
         */
        public bool IsChunkLabel()
        {
            if (Word.IsPunctuation(name) || _sentenceLabels.Contains(name.Replace("-.*", "")) ||
                _phraseLabels.Contains(name.Replace("-.*", "")))
                return true;
            return false;
        }

        /**
         * <summary> If the symbol's data contains '-' or '=', this method trims all characters after those characters and returns
         * the resulting string.</summary>
         * <returns>Trimmed symbol.</returns>
         */
        public Symbol TrimSymbol()
        {
            if (name.StartsWith("-") || (!name.Contains("-") && !name.Contains("=")))
            {
                return this;
            }

            var minusIndex = name.IndexOf('-');
            var equalIndex = name.IndexOf('=');
            if (minusIndex != -1 || equalIndex != -1)
            {
                if (minusIndex != -1 && equalIndex != -1)
                {
                    if (minusIndex < equalIndex)
                    {
                        return new Symbol(name.Substring(0, minusIndex));
                    }

                    return new Symbol(name.Substring(0, equalIndex));
                }

                if (minusIndex != -1)
                {
                    return new Symbol(name.Substring(0, minusIndex));
                }

                return new Symbol(name.Substring(0, equalIndex));
            }

            return this;
        }

        public override bool Equals(object aThat)
        {
            if (this == aThat)
            {
                return true;
            }

            if (!(aThat is Symbol))
            {
                return false;
            }
            var that = (Symbol) aThat;
            return that.name.Equals(name);
        }
    }
}