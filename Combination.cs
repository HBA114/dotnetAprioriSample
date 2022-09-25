public static class Combination
{
    public static List<List<string>> GetCombinations(List<string> items)
    {
        List<List<string>> all_res = new List<List<string>>();
        for (int i = 0; i < items.Count; i++)
        {
            List<List<string>> result = new List<List<string>>();
            result = GetCombi(items, i, 0, result);
            foreach (var item in result)
            {
                all_res.Add(item);
            }
        }
        return all_res;
    }
    private static List<List<string>> GetCombi(List<string> items, int count, int i, List<List<string>> result)
    {
        int number = CalculateCombinationCount(items.Count)[count];

        while (result.Count < number)
        {
            List<string> array = new List<string>();
            while (array.Count < count + 1)
            {
                if (array.Any(a => a == items[i]))
                {
                    i = (i + 1) % items.Count;
                }
                else
                {
                    List<string> temp = new List<string>();
                    foreach (var item in array)
                    {
                        temp.Add(item);
                    }
                    temp.Add(items[i]);
                    temp.Sort();
                    if (array.Count > 0 && result.Any(res => res == temp))
                    {
                        i = (i + 1) % items.Count;
                        continue;
                    }
                    array.Add(items[i]);
                }

                if (array.Count == count + 1)
                {
                    array.Sort();
                    result.Add(array);
                }
            }
            if (result.Count < number)
            {
                return GetCombi(items, count, i + 1, result);
            }
        }
        return result;
    }

    static List<int> CalculateCombinationCount(int count)
    {
        var r_list = Enumerable.Range(1, count);
        List<int> result = new List<int>();
        foreach (int r in r_list)
        {
            result.Add(CalculateFactorial(count) / (CalculateFactorial(r) * CalculateFactorial(count - r)));
        }

        return result;
    }

    static int CalculateFactorial(int number)
    {
        int result = 1;
        for (int i = 1; i <= number; i++)
        {
            result *= i;
        }
        return result;
    }
}