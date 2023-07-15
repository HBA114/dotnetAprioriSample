namespace dotnetAprioriSample.AlgorithmUtils;
public static class Frequent
{
    public static (List<List<String>>, List<int>, List<List<String>>) GetFrequent(List<List<String>> itemSets, List<List<String>> transactions, double minSupport, Dictionary<int, List<List<String>>> prevDiscarded)
    {
        List<List<String>> L = new List<List<String>>();
        List<int> suppCount = new List<int>();
        List<List<String>> newDiscarded = new List<List<String>>();

        int k = prevDiscarded.Keys.Count;

        for (int s = 0; s < itemSets.Count; s++)
        {
            bool discarded_before = false;
            if (k > 0)
            {
                foreach (var it in prevDiscarded[k])
                {
                    if (it.All(_it => itemSets[s].Any(_is => _it == _is)))
                    {
                        discarded_before = true;
                        break;
                    }
                }
            }

            if (!discarded_before)
            {
                int count = CountOccurrence.CountOccurrences(itemSets[s], transactions);
                if ((double)count / (double)transactions.Count >= minSupport)
                {
                    L.Add(itemSets[s]);
                    suppCount.Add(count);
                }
                else
                {
                    newDiscarded.Add(itemSets[s]);
                }
            }
        }

        return (L, suppCount, newDiscarded);
    }
}
