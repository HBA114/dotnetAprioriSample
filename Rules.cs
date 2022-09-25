public static class Rules
{
    public static string WriteRules(List<string> X, List<string> X_S, List<string> S, double conf, double supp, double lift, int num_trans)
    {
        string out_rules = "";
        out_rules += "Freq. Itemset : ";
        foreach (var item in X)
        {
            out_rules += " " + item + " ";
        }
        out_rules += "\n";

        ////////////////////
        out_rules += "\t Rule ";
        foreach (var item in S)
        {
            out_rules += " " + item + " ";
        }
        out_rules += "->";
        foreach (var item in X_S)
        {
            out_rules += " " + item + " ";
        }
        out_rules += "\n";

        //////////////////////
        out_rules += string.Format("\t Conf : {0}", Math.Round(conf, 3));
        //////////////////////
        out_rules += string.Format("\t Supp : {0}", Math.Round(((double)supp / (double)num_trans), 3));
        //////////////////////
        out_rules += string.Format("\t Lift : {0}\n\n", Math.Round(lift, 3));
        return out_rules;
    }
}