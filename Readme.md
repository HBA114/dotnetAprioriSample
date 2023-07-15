# .NET Apriori Sample Project

- This project created for implementing and learning `Apriori Association Rules algorithm`. Calculates associations of 5 items from 9 transactions in [`data_1.txt`](https://github.com/HBA114/dotnetAprioriSample/blob/version_0.2/Data/data_1.txt).

## Requirements

- [.NET Core 7](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)

## How To Run

- Open terminal in project directory and run:
```bash
dotnet run
```

- Outputs from this data:
```bash
Itemset      |      Frequency
i1           :          6
i2           :          7
i3           :          6
i4           :          2
i5           :          2

Table C2
Itemset      |      Frequency
i1 i2        :          4
i1 i3        :          4
i1 i4        :          1
i1 i5        :          2
i2 i3        :          4
i2 i4        :          2
i2 i5        :          2
i3 i4        :          0
i3 i5        :          1
i4 i5        :          0

Table L2
Itemset      |      Frequency
i1 i2        :          4
i1 i3        :          4
i1 i5        :          2
i2 i3        :          4
i2 i4        :          2
i2 i5        :          2

Table C3
Itemset      |      Frequency
i1 i2 i3     :          2
i1 i2 i5     :          2
i1 i3 i5     :          1
i2 i3 i4     :          0
i2 i3 i5     :          1
i2 i4 i5     :          0

Table L3
Itemset      |      Frequency
i1 i2 i3     :          2
i1 i2 i5     :          2

Table C4
Itemset      |      Frequency
i1 i2 i3 i5  :          1

Freq. ItemSet :  i1  i2 
         Rule  i1 -> i2 
         Conf : 0.667    Supp : 0.444    Lift : 0.857

Freq. ItemSet :  i1  i2 
         Rule  i2 -> i1 
         Conf : 0.571    Supp : 0.444    Lift : 0.857

Freq. ItemSet :  i1  i3 
         Rule  i1 -> i3 
         Conf : 0.667    Supp : 0.444    Lift : 1

Freq. ItemSet :  i1  i3 
         Rule  i3 -> i1 
         Conf : 0.667    Supp : 0.444    Lift : 1

Freq. ItemSet :  i1  i5 
         Rule  i1 -> i5 
         Conf : 0.333    Supp : 0.222    Lift : 1.5

Freq. ItemSet :  i1  i5 
         Rule  i5 -> i1 
         Conf : 1        Supp : 0.222    Lift : 1.5

Freq. ItemSet :  i2  i3 
         Rule  i2 -> i3 
         Conf : 0.571    Supp : 0.444    Lift : 0.857

Freq. ItemSet :  i2  i3 
         Rule  i3 -> i2 
         Conf : 0.667    Supp : 0.444    Lift : 0.857

Freq. ItemSet :  i2  i4 
         Rule  i4 -> i2 
         Conf : 1        Supp : 0.222    Lift : 1.286

Freq. ItemSet :  i2  i5 
         Rule  i5 -> i2 
         Conf : 1        Supp : 0.222    Lift : 1.286

Freq. ItemSet :  i1  i2  i3 
         Rule  i1 -> i2  i3 
         Conf : 0.333    Supp : 0.222    Lift : 0.75

Freq. ItemSet :  i1  i2  i3 
         Rule  i3 -> i1  i2 
         Conf : 0.333    Supp : 0.222    Lift : 0.75

Freq. ItemSet :  i1  i2  i3 
         Rule  i1  i2 -> i3 
         Conf : 0.5      Supp : 0.222    Lift : 0.75

Freq. ItemSet :  i1  i2  i3 
         Rule  i1  i3 -> i2 
         Conf : 0.5      Supp : 0.222    Lift : 0.643

Freq. ItemSet :  i1  i2  i3 
         Rule  i2  i3 -> i1 
         Conf : 0.5      Supp : 0.222    Lift : 0.75

Freq. ItemSet :  i1  i2  i5 
         Rule  i1 -> i2  i5 
         Conf : 0.333    Supp : 0.222    Lift : 1.5

Freq. ItemSet :  i1  i2  i5 
         Rule  i5 -> i1  i2 
         Conf : 1        Supp : 0.222    Lift : 2.25

Freq. ItemSet :  i1  i2  i5 
         Rule  i1  i2 -> i5 
         Conf : 0.5      Supp : 0.222    Lift : 2.25

Freq. ItemSet :  i1  i2  i5 
         Rule  i1  i5 -> i2 
         Conf : 1        Supp : 0.222    Lift : 1.286

Freq. ItemSet :  i1  i2  i5 
         Rule  i2  i5 -> i1 
         Conf : 1        Supp : 0.222    Lift : 1.5
```
