namespace dotnetAprioriSample.AlgorithmUtils;

public static class CountOccurrence
{
    public static int CountOccurrences(List<String> itemSet, List<List<String>> transactions)
    {
        int count = 0;
        for (int i = 0; i < transactions.Count; i++)
        {
            if (itemSet.All(_it => transactions[i].Any(_t => _it == _t)))
            {
                count++;
            }
        }
        return count;
    }
}
