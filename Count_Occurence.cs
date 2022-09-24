public static class Count_Occurence
{
    public static int count_occurences(List<String> itemset, List<List<String>> transactions)
    {
        int count = 0;
        for (int i = 0; i < transactions.Count; i++)
        {
            if (itemset.All(_it => transactions[i].Any(_t => _it == _t)))
            {
                count++;
            }
        }
        return count;
    }
}