namespace Kodelabzz.Library
{
    public class ArraySort
    {
        public static void Sort()
        {
            WorkSet parent = new WorkSet { MasterID = "123", MasterName = "master", CurrentId = "123" };
            WorkSet child = new WorkSet { MasterID = "123", MasterName = "master", CurrentId = "xyz" };
            WorkSet granchild = new WorkSet { MasterID = "123", MasterName = "master", CurrentId = "abc" };
            WorkSet workset1 = new WorkSet { MasterID = "1234", MasterName = "schdule1", CurrentId = "ghgh" };
            WorkSet workset2 = new WorkSet { MasterID = "12345", MasterName = "schdule2", CurrentId = "gh" };
            WorkSet[] workSets = new WorkSet[] { workset1, parent, child, granchild,workset2 };
            int[] arr = { 12, 10, 9, 45, 2, 10, 10, 45 };
            int n = arr.Length;
            Dictionary<int,int> map = new Dictionary<int,int>();
            for (int i = 0; i < n; i++)
            {
                if (map.ContainsKey(arr[i]))
                {
                    var val = map[arr[i]];
                    map.Remove(arr[i]);
                    map.Add(arr[i], val + 1);
                }
                else
                {
                    map.Add(arr[i], 1);
                }
            }

            Dictionary<string,WorkSet> uniqueWorkSets = new Dictionary<string, WorkSet>();
            foreach (var item in workSets)
            {
                if(!uniqueWorkSets.ContainsKey(item.MasterID))
                {
                    uniqueWorkSets.Add(item.MasterID, item);
                }
                else
                {
                    uniqueWorkSets.Remove(item.MasterID);
                }
            }
           
            WorkSet[] sortedList = workSets.OrderBy(si => si.MasterID).ToArray();
            WorkSet[] distinctWorkSets = workSets.GroupBy(p => p.MasterID).Select(g => g.First()).ToArray();

            WorkSet[] noParentChildWorksets= workSets.Except(distinctWorkSets).ToArray();
           

            var duplicates = arr.GroupBy(x => x)
                  .Where(g => g.Count() > 1)
                  .Select(y => y.Key)
                  .ToList();
        }
    }

    internal class WorkSet
    {
        public string MasterID { get; set; }
        public string MasterName { get; set; }
        public string CurrentId { get; set; }

        public override string ToString()
        {
            return MasterID;
        }


    }
}