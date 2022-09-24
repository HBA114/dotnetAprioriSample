List<List<String>> LoadTransactions(String path)
{
    var data = File.ReadAllLines(path);
    List<List<String>> transactions = new List<List<string>>();

    foreach (var line in data)
    {
        var transaction = line.Split(',').ToList();
        transactions.Add(transaction);
    }

    return transactions;
}

int CountOccurences(List<String> itemset, List<List<String>> transactions)
{
    int count = 0;
    for (int i = 0; i < transactions.Count; i++)
    {
        // ! ???????????????????????????????????????????????
        if (transactions[i].Any(_t => itemset.Any(_i => _i == _t)))
        {
            count++;
        }
    }
    return count;
}

(List<List<String>>, List<int>, List<List<String>>) GetFrequent(List<List<String>> itemsets, List<List<String>> transactions, double min_support, Dictionary<int, List<List<String>>> prev_discarded)
{
    var L = new List<List<String>>();
    var supp_count = new List<int>();
    var new_discarded = new List<List<String>>();

    var k = prev_discarded.Keys.Count;

    for (int i = 0; i < itemsets.Count; i++)
    {
        var discarded_before = false;
        if (k > 0)
        {
            foreach (var it in prev_discarded[k])
            {
                if (itemsets[i].Any(_itemset => it.Any(_it => _it == _itemset)))
                {
                    discarded_before = true;
                    break;
                }
            }
        }

        if (!discarded_before)
        {
            int count = CountOccurences(itemsets[i], transactions);
            if (count / transactions.Count >= min_support)
            {
                L.Add(itemsets[i]);
                supp_count.Add(count);
            }
            else
            {
                new_discarded.Add(itemsets[i]);
            }
        }
    }

    return (L, supp_count, new_discarded);
}

List<String> JoinTwoItemSets(List<String> it1, List<String> it2, List<List<String>> order)
{
    // ! it1.sort(key=lambda x: order.index(x))
    // ! it2.sort(key=lambda x: order.index(x))

    return new List<String>();
}

List<List<String>> JoinSetItems(List<List<String>> set_of_its, List<List<String>> order)
{
    var C = new List<List<String>>();

    for (int i = 0; i < set_of_its.Count; i++)
    {
        for (int j = i + 1; j < set_of_its.Count; j++)
        {
            var it_out = JoinTwoItemSets(set_of_its[i], set_of_its[j], order);
            if (it_out.Count > 0)
            {
                C.Add(it_out);
            }
        }
    }

    return C;
}


var transactions = LoadTransactions("data_1.txt");

var order = new List<List<String>>() { new List<String>() { "i1", "i2", "i3", "i4", "i5" } };

var C = new Dictionary<int, List<List<String>>>();
var L = new Dictionary<int, List<List<String>>>();

var itemset_size = 1;
var Discarded = new Dictionary<int, List<List<String>>>();
C.Add(itemset_size, order);
// System.Console.WriteLine(C[itemset_size]);

var min_support = 2 / 9;
var min_confidence = 0.3;

var supp_count_L = new Dictionary<int, List<int>>();

var frequent_data = GetFrequent(C[itemset_size], transactions, min_support, Discarded);

var f = frequent_data.Item1;
var sup = frequent_data.Item2;
var new_discarded = frequent_data.Item3;

Discarded.Add(itemset_size, new_discarded);
L.Add(itemset_size, f);
supp_count_L.Add(itemset_size, sup);

void WriteTable(List<List<String>> T, List<int> supp_count)
{
    System.Console.WriteLine("Itemset  |  Frequancy");
    for (int i = 0; i < T.Count; i++)
    {
        System.Console.WriteLine("sup_count_size : " + supp_count.Count);
        // System.Console.WriteLine("[" + T[i] + "]    :    " + supp_count[i]);
        for (int j = 0; j < T[i].Count; j++)
        {
            System.Console.WriteLine(" '" + T[i][j] + "'    :    " + supp_count[i]);
        }
    }
}

WriteTable(L[1], supp_count_L[1]);

var k = itemset_size + 1;
var convergence = false;

// while (!convergence)
// {
//     // ! C.Add has a problem
//     try
//     {
//         C.Add(k, JoinSetItems(L[k - 1], order));
//     }
//     catch (System.ArgumentException e)
//     {
//         if (e.Message.Contains("same key"))
//         {
//             C[k] = JoinSetItems(L[k - 1], order);
//         }
//     }
//     System.Console.WriteLine("Table C" + k);
//     // ! print_table(C[k], [count_occurences(it, transactions) for it in C[k]])
//     // WriteTable(C[k], CountOccurences())
// }