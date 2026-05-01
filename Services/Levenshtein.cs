using System;
using System.Collections.Generic;
using System.Text;

namespace Playground.Services;

public static class SmartMatcher
{
    public static bool IsMatch(string source, string input)
    {
        source = TextNormalizer.Normalize(source);
        input = TextNormalizer.Normalize(input);

        // 1. Fast contains
        if (source.Contains(input))
            return true;

        // 2. Token similarity (companies)
        if (TokenSimilarity.IsMatch(source, input, 0.5))
            return true;

        // 3. FuzzySharp (main engine)
        if (Sift4.IsFuzzyMatch(source, input, 70))
            return true;

        // 4. Phonetic (names)
        if (Soundex.IsMatch(source, input))
            return true;

        // 5. Fallback
        if (Levenshtein.IsFuzzyMatch(source, input))
            return true;

        return false;
    }
}

public class Levenshtein
{
    /// <summary>
    /// Levenshtein distance calculation
    /// </summary>
    private static int ComputeDistance(string s, string t)
    {
        if (string.IsNullOrEmpty(s)) return t.Length;
        if (string.IsNullOrEmpty(t)) return s.Length;

        var d = new int[s.Length + 1, t.Length + 1];

        for (int i = 0; i <= s.Length; i++)
            d[i, 0] = i;

        for (int j = 0; j <= t.Length; j++)
            d[0, j] = j;

        for (int i = 1; i <= s.Length; i++)
        {
            for (int j = 1; j <= t.Length; j++)
            {
                int cost = (s[i - 1] == t[j - 1]) ? 0 : 1;

                d[i, j] = Math.Min(
                    Math.Min(d[i - 1, j] + 1,     // deletion
                             d[i, j - 1] + 1),    // insertion
                    d[i - 1, j - 1] + cost        // substitution
                );
            }
        }

        return d[s.Length, t.Length];
    }

    /// <summary>
    /// Check if strings are fuzzy match using Levenshtein
    /// </summary>
    public static bool IsFuzzyMatch(string source, string input)
    {
        source = source.ToLower();
        input = input.ToLower();

        // Fast path
        if (source.Contains(input) || source.StartsWith(input))
            return true;

        int inputLength = input.Length;

        // Check substrings of same length
        for (int i = 0; i <= source.Length - inputLength; i++)
        {
            var sub = source.Substring(i, inputLength);
            int distance = ComputeDistance(sub, input);

            int maxAllowedDistance = Math.Max(1, inputLength / 3);

            if (distance <= maxAllowedDistance)
                return true;
        }

        return false;
    }
}

public static class Sift4
{
    /// <summary>
    /// Sift4 distance calculation
    /// </summary>
    public static int ComputeDistance(string s1, string s2, int maxOffset = 5)
    {
        if (string.IsNullOrEmpty(s1)) return string.IsNullOrEmpty(s2) ? 0 : s2.Length;
        if (string.IsNullOrEmpty(s2)) return s1.Length;

        int l1 = s1.Length;
        int l2 = s2.Length;

        int c1 = 0; // cursor for s1
        int c2 = 0; // cursor for s2
        int lcss = 0; // largest common subsequence
        int localCs = 0;
        int trans = 0;
        int offset1 = 0, offset2 = 0;

        while (c1 < l1 && c2 < l2)
        {
            if (s1[c1] == s2[c2])
            {
                localCs++;
                bool isTrans = false;
                for (int i = 0; i < offset1; i++)
                    if ((c1 + i < l1) && (s1[c1 + i] == s2[c2]))
                        isTrans = true;

                if (isTrans)
                    trans++;

                c1++;
                c2++;
            }
            else
            {
                lcss += localCs;
                localCs = 0;

                if (c1 != c2)
                {
                    c1 = c2 = Math.Min(c1, c2);
                }

                // try to find match within maxOffset
                bool found = false;
                for (int i = 1; i <= maxOffset; i++)
                {
                    if ((c1 + i < l1) && s1[c1 + i] == s2[c2])
                    {
                        c1 += i;
                        found = true;
                        break;
                    }
                    if ((c2 + i < l2) && s1[c1] == s2[c2 + i])
                    {
                        c2 += i;
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    c1++;
                    c2++;
                }
            }
        }

        lcss += localCs;
        return Math.Max(l1, l2) - lcss + trans;
    }

    /// <summary>
    /// Check if two strings are fuzzy match using Sift4
    /// </summary>
    public static bool IsFuzzyMatch(string source, string input, int maxDistance = 2)
    {
        source = source.ToLower();
        input = input.ToLower();

        // exact contains fast path
        if (source.Contains(input))
            return true;

        int distance = ComputeDistance(source, input);
        return distance <= maxDistance;
    }
}

public static class Soundex
{
    public static string Compute(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return string.Empty;

        input = input.ToUpperInvariant();

        var map = new Dictionary<char, char>
        {
            ['B']='1',['F']='1',['P']='1',['V']='1',
            ['C']='2',['G']='2',['J']='2',['K']='2',['Q']='2',['S']='2',['X']='2',['Z']='2',
            ['D']='3',['T']='3',
            ['L']='4',
            ['M']='5',['N']='5',
            ['R']='6'
        };

        var result = new StringBuilder();
        result.Append(input[0]);

        char prevCode = map.ContainsKey(input[0]) ? map[input[0]] : '0';

        for (int i = 1; i < input.Length; i++)
        {
            char c = input[i];
            if (!map.ContainsKey(c)) continue;

            char code = map[c];
            if (code != prevCode)
            {
                result.Append(code);
                if (result.Length == 4) break;
            }

            prevCode = code;
        }

        return result.ToString().PadRight(4, '0');
    }

    public static bool IsMatch(string a, string b)
    {
        return Compute(a) == Compute(b);
    }
}

public static class TokenSimilarity
{
    public static double Compute(string a, string b)
    {
        var tokensA = Tokenize(a);
        var tokensB = Tokenize(b);

        var intersection = tokensA.Intersect(tokensB).Count();
        var union = tokensA.Union(tokensB).Count();

        if (union == 0) return 0;

        return (double)intersection / union;
    }

    public static bool IsMatch(string a, string b, double threshold = 0.5)
    {
        return Compute(a, b) >= threshold;
    }

    private static HashSet<string> Tokenize(string input)
    {
        return input
            .ToLowerInvariant()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(x => x.Trim())
            .ToHashSet();
    }
}

public static class TextNormalizer
{
    private static readonly string[] CompanySuffixes =
        { "bv", "b.v.", "nv", "n.v.", "ltd", "inc", "gmbh" };

    public static string Normalize(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return string.Empty;

        input = input.ToLowerInvariant();

        foreach (var suffix in CompanySuffixes)
        {
            input = input.Replace(suffix, "");
        }

        return input.Trim();
    }
}
