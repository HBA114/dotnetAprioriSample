namespace dotnetAprioriSample.AlgorithmUtils;

public static class SetItems
{
    public static List<List<String>> JoinItemSets(List<List<String>> itemSets, List<String> order)
    {
        List<List<String>> C = new List<List<String>>();

        for (int i = 0; i < itemSets.Count; i++)
        {
            for (int j = i + 1; j < itemSets.Count; j++)
            {
                List<String> it_out = JoinTwoItemSets(itemSets[i], itemSets[j], order);
                if (it_out.Count > 0)
                {
                    C.Add(it_out);
                }
            }
        }

        return C;
    }

    public static List<String> JoinTwoItemSets(List<String> item1, List<String> item2, List<String> order)
    {
        item1.Sort();
        item2.Sort();
        List<String> result = new List<String>();

        for (int i = 0; i < item1.Count - 1; i++)
        {
            if (item1[i] != item2[i])
            {
                // empty result;
                return result;
            }
        }

        if (order.IndexOf(item1[item1.Count - 1]) < order.IndexOf(item2[item2.Count - 1]))
        {
            foreach (String item in item1)
            {
                result.Add(item);
            }
            result.Add(item2[item2.Count - 1]);
            return result;
        }
        // empty result;
        return result;
    }
}
