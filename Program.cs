List<String> order = new List<String>()
{
    "i1",
    "i2",
    "i3",
    "i4",
    "i5",
};

String dataPath = "data_1.txt";

List<List<String>> transactions = LoadTransaction.LoadTransactions(dataPath, order);

int itemsetSize = 1;

Dictionary<int, List<List<String>>> C = new Dictionary<int, List<List<string>>>();
Dictionary<int, List<List<String>>> L = new Dictionary<int, List<List<string>>>();
Dictionary<int, List<List<String>>> Discarded = new Dictionary<int, List<List<string>>>();

List<List<String>> orderC = new List<List<string>>();
foreach (var item in order)
{
    orderC.Add(new List<String>() { item });
}

C = CustomDictionary.Add(C, itemsetSize, orderC);

double minSupport = (double)2 / (double)9;
double minConfidence = 0.3;

Dictionary<int, List<int>> suppCountL = new Dictionary<int, List<int>>();

List<List<String>> f = new List<List<String>>();
List<int> sup = new List<int>();

var frequent = Frequent.GetFrequent(C[itemsetSize], transactions, minSupport, Discarded);

f = frequent.Item1;
sup = frequent.Item2;
List<List<String>> new_discarded = frequent.Item3;

Discarded = CustomDictionary.Add(Discarded, itemsetSize, new_discarded);
L = CustomDictionary.Add(L, itemsetSize, f);
suppCountL = CustomDictionary.Add(suppCountL, itemsetSize, sup);

void WriteTable(List<List<String>> T, List<int> supp_count)
{
    System.Console.WriteLine("Itemset      |      Frequency");
    for (int i = 0; i < T.Count; i++)
    {
        for (int j = 0; j < T[i].Count; j++)
        {
            Console.Write(T[i][j] + " ");
        }
        var pos = Console.GetCursorPosition();
        try
        {
            Console.SetCursorPosition(Console.GetCursorPosition().Left + (12 - (T[i].Count * 3)), Console.GetCursorPosition().Top);
        }
        catch (ArgumentOutOfRangeException)
        {
            System.Console.WriteLine();
            Console.SetCursorPosition(Console.GetCursorPosition().Left + 1, Console.GetCursorPosition().Top - 1);
        }
        Console.WriteLine(" :          " + supp_count[i]);
    }
    System.Console.WriteLine();
}

WriteTable(L[1], suppCountL[1]);

int k = itemsetSize + 1;
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

    frequent = Frequent.GetFrequent(C[k], transactions, minSupport, Discarded);
    f = frequent.Item1;
    sup = frequent.Item2;
    new_discarded = frequent.Item3;

    Discarded = CustomDictionary.Add(Discarded, k, new_discarded);
    L = CustomDictionary.Add(L, k, f);
    suppCountL = CustomDictionary.Add(suppCountL, k, sup);
    if (L[k].Count == 0)
    {
        convergence = true;
    }
    else
    {
        System.Console.WriteLine("Table L{0}", k);
        WriteTable(L[k], suppCountL[k]);
    }
    k++;
}

String assoc_rules = "";

for (int i = 1; i < L.Count; i++)
{
    for (int j = 0; j < L[i].Count; j++)
    {
        List<List<String>> s = Combination.GetCombinations(L[i][j]);
        s.RemoveAt(s.Count - 1);
        // Works fine for now
        foreach (var item in s)
        {
            var S = new List<string>();
            foreach (var x in item)
            {
                S.Add(x);
            }
            var X = new List<string>();
            foreach (var x in L[i][j])
            {
                X.Add(x);
            }

            var X_S = X.Except(S).ToList();

            int sup_x = Count_Occurence.count_occurences(X, transactions);
            int sup_x_s = Count_Occurence.count_occurences(X_S, transactions);
            double conf = (double)sup_x / (double)Count_Occurence.count_occurences(S, transactions);
            double lift = conf / ((double)sup_x_s / (double)transactions.Count);

            if (conf >= minConfidence && sup_x >= minSupport)
            {
                assoc_rules += Rules.WriteRules(X, X_S, S, conf, sup_x, lift, transactions.Count);
            }
        }
    }
}

System.Console.WriteLine(assoc_rules);