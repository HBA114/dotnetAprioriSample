public static class CustomDictionary
{
    public static Dictionary<int, List<List<String>>> Add(Dictionary<int, List<List<String>>> dict, int i, List<List<String>> list)
    {
        if (!dict.Keys.Contains(i))
        {
            dict.Add(i, list);
        }
        else
        {
            dict[i] = list;
        }
        return dict;
    }
}