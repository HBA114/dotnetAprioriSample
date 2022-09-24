public static class SetItems
{
    public static List<List<String>> JoinItemSets(List<List<String>> set_of_its, List<String> order)
    {
        List<List<String>> C = new List<List<String>>();

        for (int i = 0; i < set_of_its.Count; i++)
        {
            for (int j = i + 1; j < set_of_its.Count; j++)
            {
                List<String> it_out = JoinTwoItemSets(set_of_its[i], set_of_its[j], order);
                if (it_out.Count > 0)
                {
                    C.Add(it_out);
                }
            }
        }

        return C;
    }

    public static List<String> JoinTwoItemSets(List<String> it1, List<String> it2, List<String> order)
    {
        it1.Sort();
        it2.Sort();
        List<String> result = new List<String>();

        for (int i = 0; i < it1.Count - 1; i++)
        {
            if (it1[i] != it2[i])
            {
                // empty result;
                return result;
            }
        }

        if (order.IndexOf(it1[it1.Count - 1]) < order.IndexOf(it2[it2.Count - 1]))
        {
            // result.Add(it1);
            foreach (String item in it1)
            {
                result.Add(item);
            }
            result.Add(it2[it2.Count - 1]);
            return result;
        }
        // empty result;
        return result;
    }
}