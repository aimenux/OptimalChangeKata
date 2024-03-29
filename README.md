[![.NET](https://github.com/aimenux/OptimalChangeKata/actions/workflows/ci.yml/badge.svg)](https://github.com/aimenux/OptimalChangeKata/actions/workflows/ci.yml)
[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=OptimalChangeKata-Key&metric=coverage)](https://sonarcloud.io/summary/new_code?id=OptimalChangeKata-Key)

# OptimalChangeKata
```
Kata about the optimal way to give back amount with the minimum number of coins
```
>
> One of the problems presented by cash transactions is how to return change.
> What is the optimal way to give back a certain amount with the minimum number of coins.
> It's an issue that each of us encounters on a daily basis and the problem is the same for automated checkout machines.
> In this exercise, you are asked to try and find an optimal solution for returning change in a very specific case : 
>
>> :zap: When the machine contains only €2 coins, €5 coins and €10 coins. 
>>
>> :zap: We imagine that all coins are available in unlimited quantities.
>
> Here are some examples of how change may be returned :
>
> :pushpin: Change For €1:
>>       Possible Solutions: Impossible
>>       Optimal Solution:   Impossible
>
> :pushpin: Change For €6:
>>       Possible Solutions: €2 + €2 + €2
>>       Optimal Solution:   €2 + €2 + €2
>
> :pushpin: Change For €10:
>>       Possible Solutions: €2 + €2 + €2 + €2 + €2 | €5 + €5 | €10
>>       Optimal Solution:   €10
>
> :pushpin: Change For €9223372036854775807:
>>       Possible Solutions: ...
>>       Optimal Solution:   (€10 * 922337203685477580)+ €5 + €2
>
> Implement the `ComputeOptimalCurrency(long money)` method which returns a `Currency` object.
> This object has properties `TwoCoins`, `FiveCoins` and `TenCoins` which represents coins for `€2`, `€5` and `€10`.
> The sum of coins indicated in the `Currency` object must be equal to `money`.
> If it is not possible to give back change, the method must return `null`.
> The solution (when possible) should have the minimal number of coins.
>
> **Constraints**
>
>> :zap: `money` is a `long`.
>>
>> :zap: 0 < `money` <= 9223372036854775807
>
>

**`Tools`** : vs22, net 7.0, nunit, fluentassertions, guardclauses
