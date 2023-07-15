namespace dotnetAprioriSample.Utils;

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

    public static Dictionary<int, List<int>> Add(Dictionary<int, List<int>> dict, int i, List<int> list)
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
