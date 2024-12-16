using System;
using System.Collections.Generic;

namespace AdventOfCode
{
    /// <summary>
    /// https://adventofcode.com/2024/day/5
    /// </summary>
    public class Day05
    {
        public class PrintingQueue
        {
            private readonly Dictionary<int, PageRules> rules = [];
            private readonly List<SafetyManual> safetyManuals = [];

            public PrintingQueue(string input)
            {
                var parts = input.Split($"{Environment.NewLine}{Environment.NewLine}");

                foreach (var rule in parts[0].Split(Environment.NewLine))
                    AddPageRule(rule);

                foreach (var sequence in parts[1].Split(Environment.NewLine))
                    safetyManuals.Add(new SafetyManual(sequence));
            }

            public int FindSumOfMiddlePageForValidManuals()
            {
                var sum = 0;

                foreach (var manual in safetyManuals)
                    if (manual.IsValidPageOrder(rules))
                        sum += manual.GetMiddlePage();

                return sum;
            }

            public int FindSumOfMiddlePageForFixedInvalidManuals()
            {
                var sum = 0;

                foreach (var manual in safetyManuals)
                    if (!manual.IsValidPageOrder(rules))
                        sum += manual.ReorderAndGetMiddlePage(rules);

                return sum;
            }

            private void AddPageRule(string ordering)
            {
                var parts = ordering.Split('|');
                var page1 = int.Parse(parts[0]);
                var page2 = int.Parse(parts[1]);

                var rule = GetPageRules(page1);
                rule.AddPageAfterRule(page2);

                // Call with the other page number as well to make sure a rule is created for every page.
                GetPageRules(page2);
            }

            private PageRules GetPageRules(int pageNum)
            {
                if(!rules.TryGetValue(pageNum, out PageRules rule))
                {
                    rule = new PageRules(pageNum);
                    rules.Add(pageNum, rule);
                }

                return rule;
            }

            public class PageRules(int pageNumber)
            {
                public int PageNumber = pageNumber;

                public HashSet<int> AllowedPagesAfter = [];

                public void AddPageAfterRule(int pageNumber)
                {
                    AllowedPagesAfter.Add(pageNumber);
                }

                public bool IsValid(List<int> pagesBefore)
                {
                    foreach (var page in pagesBefore)
                        if (AllowedPagesAfter.Contains(page))
                            return false;

                    return true;
                }
            }

            public class SafetyManual
            {
                public List<int> PageNumbers = [];

                public SafetyManual(string rawInput)
                {
                    foreach (var num in rawInput.Split(','))
                        PageNumbers.Add(int.Parse(num));
                }

                public bool IsValidPageOrder(Dictionary<int, PageRules> rules)
                {
                    return IndexOfMisplacedPage(rules) == -1;
                }

                public int GetMiddlePage()
                {
                    return PageNumbers[PageNumbers.Count / 2];
                }

                public int ReorderAndGetMiddlePage(Dictionary<int, PageRules> rules)
                {
                    while (FixMisplacedPage(rules)) {}
                    return GetMiddlePage();
                }

                private bool FixMisplacedPage(Dictionary<int, PageRules> rules)
                {
                    var index = IndexOfMisplacedPage(rules);
                    if (index == -1)
                        return false; // No fix was needed

                    var number = PageNumbers[index];
                    var newIndex = index;
                    foreach (var after in rules[number].AllowedPagesAfter)
                    {
                        var otherIndex = PageNumbers.IndexOf(after);
                        if (otherIndex != -1 && otherIndex < newIndex)
                            newIndex = otherIndex;
                    }

                    PageNumbers.RemoveAt(index);
                    PageNumbers.Insert(newIndex, number);

                    return true; // A page was moved
                }

                private int IndexOfMisplacedPage(Dictionary<int, PageRules> rules)
                {
                    for (int i = 1; i < PageNumbers.Count; i++)
                        if (!rules[PageNumbers[i]].IsValid(PageNumbers[0..(i)]))
                            return i;

                    return -1;
                }
            }
        }

        // == == == == == Puzzle 1 == == == == ==
        public static string Puzzle1(string input)
        {
            var pq = new PrintingQueue(input);
            return pq.FindSumOfMiddlePageForValidManuals().ToString();
        }

        // == == == == == Puzzle 2 == == == == ==
        public static string Puzzle2(string input)
        {
            var pq = new PrintingQueue(input);
            return pq.FindSumOfMiddlePageForFixedInvalidManuals().ToString();
        }
    }
}
