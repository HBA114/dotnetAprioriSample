List<String> order = new List<String>()
{
    "i1",
    "i2",
    "i3",
    "i4",
    "i5",
};

String data_path = "data_1.txt";

List<List<String>> transactions = LoadTransaction.LoadTransactions(data_path, order);

int itemset_size = 1;

Dictionary<int, List<List<String>>> C = new Dictionary<int, List<List<string>>>();
Dictionary<int, List<List<String>>> L = new Dictionary<int, List<List<string>>>();
Dictionary<int, List<List<String>>> Discarded = new Dictionary<int, List<List<string>>>();

List<List<String>> order_C = new List<List<string>>();
foreach (var item in order)
{
    order_C.Add(new List<String>() { item });
}

C = CustomDictionary.Add(C, itemset_size, order_C);

double min_support = ((double)2 / (double)9);
double min_confidence = 0.3;

Dictionary<int, List<int>> supp_count_L = new Dictionary<int, List<int>>();

List<List<String>> f = new List<List<String>>();
List<int> sup = new List<int>();

var frequent = Frequent.GetFrequent(C[itemset_size], transactions, min_support, Discarded);

f = frequent.Item1;
sup = frequent.Item2;
List<List<String>> new_discarded = frequent.Item3;

Discarded = CustomDictionary.Add(Discarded, itemset_size, new_discarded);
L = CustomDictionary.Add(L, itemset_size, f);
supp_count_L = CustomDictionary.Add(supp_count_L, itemset_size, sup);

void WriteTable(List<List<String>> T, List<int> supp_count)
{
    System.Console.WriteLine("Itemset      |      Frequency");
    for (int i = 0; i < T.Count; i++)
    {
        for (int j = 0; j < T[i].Count; j++)
        {
            Console.Write(" " + T[i][j] + " ");
        }
        System.Console.WriteLine(" : " + supp_count[i]);
    }
    System.Console.WriteLine();
}

WriteTable(L[1], supp_count_L[1]);

int k = itemset_size + 1;
bool convergence = false;

while (!convergence)
{
    C = CustomDictionary.Add(C, k, SetItems.JoinItemSets(L[k - 1], order));
    System.Console.WriteLine("Table C{0}", k);
    List<int> temp_sup_count = new List<int>();
    for (int i = 0; i < C[k].Count; i++)
    {
        temp_sup_count.Add(Count_Occurence.count_occurences(C[k][i], transactions));
    }
    WriteTable(C[k], temp_sup_count);

    frequent = Frequent.GetFrequent(C[k], transactions, min_support, Discarded);
    f = frequent.Item1;
    sup = frequent.Item2;
    new_discarded = frequent.Item3;

    Discarded = CustomDictionary.Add(Discarded, k, new_discarded);
    L = CustomDictionary.Add(L, k, f);
    supp_count_L = CustomDictionary.Add(supp_count_L, k, sup);
    if (L[k].Count == 0)
    {
        convergence = true;
    }
    else
    {
        System.Console.WriteLine("Table L{0}", k);
        WriteTable(L[k], supp_count_L[k]);
    }
    k++;
}

List<Tuple<String>> powerset(List<String> s)
{
    List<Tuple<String>> result = new List<Tuple<String>>();
    List<int> r = new List<int>();
    // for (int i = 1; i < s.Count + 1; i++)
    // {
    //     r.Add(i);
    // }
    // use Enumerable.Range
    r = Enumerable.Range(1,s.Count+1).ToList(); // ! ??
    // How to do all combinations with items in s count in r
}

String assoc_rules = "";

for (int i = 1; i < L.Count; i++)
{
    for (int j = 0; j < L[i].Count; j++)
    {
        List<Tuple<String>> s = powerset(L[i][j]);
    }
}