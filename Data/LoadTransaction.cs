namespace dotnetAprioriSample.Data;

public static class LoadTransaction
{
    public static List<List<String>> LoadTransactions(String data_path, List<String> order)
    {
        List<List<String>> transactions = new List<List<String>>();

        List<String> lines = File.ReadAllLines(data_path).ToList();

        foreach (String line in lines)
        {
            List<String> transaction = line.Split(",").ToList();
            transaction.Sort();
            transactions.Add(transaction);
        }

        return transactions;
    }
}
