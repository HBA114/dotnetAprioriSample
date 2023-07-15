namespace dotnetAprioriSample.AlgorithmUtils;

public static class Rules
{
    public static string WriteRules(List<string> X, List<string> X_S, List<string> S, double conf, double supp, double lift, int numTrans)
    {
        string outRules = "";
        outRules += "Freq. ItemSet : ";
        foreach (var item in X)
        {
            outRules += " " + item + " ";
        }
        outRules += "\n";

        outRules += "\t Rule ";
        foreach (var item in S)
        {
            outRules += " " + item + " ";
        }
        outRules += "->";
        foreach (var item in X_S)
        {
            outRules += " " + item + " ";
        }
        outRules += "\n";

        outRules += string.Format("\t Conf : {0}", Math.Round(conf, 3));

        outRules += string.Format("\t Supp : {0}", Math.Round(((double)supp / (double)numTrans), 3));

        outRules += string.Format("\t Lift : {0}\n\n", Math.Round(lift, 3));

        return outRules;
    }
}
