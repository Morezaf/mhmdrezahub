static (int, int) FindTargetMatch(List<int> nums, int target)
{
    Dictionary<int,int> ListMap = new Dictionary<int,int>();
    int temp = 0;
    for (int i = 0; i < nums.Count; i++)
    {
        temp = target - nums[i];
        if (ListMap.ContainsKey(temp))
        {
            ListMap.TryGetValue(temp, out int j);
            return (j, i);
        } 
        ListMap[nums[i]] = i;
    }
    return (-1, -1);
}

Console.WriteLine(FindTargetMatch(new List<int>() { 1, 2, -8, 6, 32, 1, -25 }, 24));