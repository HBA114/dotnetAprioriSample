public static class Frequent
{
    public static (List<List<String>>, List<int>, List<List<String>>) GetFrequent(List<List<String>> itemsets, List<List<String>> transactions, double min_support, Dictionary<int, List<List<String>>> prev_discarded)
    {
        List<List<String>> L = new List<List<String>>();
        List<int> supp_count = new List<int>();
        List<List<String>> new_discarded = new List<List<String>>();

        int k = prev_discarded.Keys.Count;

        for (int s = 0; s < itemsets.Count; s++)
        {
            bool discarded_before = false;
            if (k > 0)
            {
                foreach (var it in prev_discarded[k])
                {
                    if (it.All(_it => itemsets[s].Any(_is => _it == _is)))
                    {
                        discarded_before = true;
                        break;
                    }
                }
            }

            if (!discarded_before)
            {
                int count = count_occurences(itemsets[s], transactions);
                // ! write count occurences and complete this function
            }
        }

        return (L, supp_count, new_discarded);
    }
}