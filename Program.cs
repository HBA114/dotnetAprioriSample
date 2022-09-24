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

double min_support = Math.Round(((double)2 / (double)9), 2);
double min_confidence = 0.3;

Dictionary<int, List<int>> supp_count_L = new Dictionary<int, List<int>>();

List<List<String>> f = new List<List<String>>();
List<int> sup = new List<int>();

var frequent = Frequent.GetFrequent(C[itemset_size], transactions, min_support, Discarded);

f = frequent.Item1;
sup = frequent.Item2;
List<List<String>> new_discarded = frequent.Item3;

