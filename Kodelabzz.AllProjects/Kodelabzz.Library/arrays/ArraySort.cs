using System.Collections.Generic;

namespace Kodelabzz.Library
{
    public class ArraySort
    {
        /// <summary>
        /// Method to sort array by grouping them based on masterid
        /// </summary>
        public static void Sort()
        {
            WorkSet parent = new WorkSet { MasterID = "123", MasterName = "master", CurrentId = "123" };
            WorkSet child = new WorkSet { MasterID = "123", MasterName = "master", CurrentId = "xyz" };
            WorkSet granchild = new WorkSet { MasterID = "123", MasterName = "master", CurrentId = "abc" };
            WorkSet workset1 = new WorkSet { MasterID = "1234", MasterName = "schdule1", CurrentId = "ghgh" };
            WorkSet workset2 = new WorkSet { MasterID = "12345", MasterName = "schdule2", CurrentId = "gh" };
            WorkSet workset3 = new WorkSet { MasterID = "12345", MasterName = "schdule45", CurrentId = "ko" };
            WorkSet workset4 = new WorkSet { MasterID = "x12345", MasterName = "schhghule45", CurrentId = "klo" };
            WorkSet[] workSets = new WorkSet[] { workset1, workset4, workset3, workset2, granchild, child, parent };
            //WorkSet[] workSets = new WorkSet[] { workset3, workset2, granchild, child, parent };

            IGrouping<string,WorkSet>[] wortsetsWithCommonMasterID=workSets.GroupBy(item => item.MasterID).Where(g => g.Count()>1).ToArray();
            if (wortsetsWithCommonMasterID.Length > 0)
            {
                List<WorkSet> relatedWorksets = new List<WorkSet>();
                foreach (var item in wortsetsWithCommonMasterID)
                {
                    relatedWorksets.AddRange(item.ToArray());
                }

                IEnumerable<WorkSet> unrelatedWorksets = workSets.Except(relatedWorksets.ToArray());
                if (unrelatedWorksets != null && unrelatedWorksets.Any())
                {
                    workSets = unrelatedWorksets.ToArray();
                }
               
            }
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