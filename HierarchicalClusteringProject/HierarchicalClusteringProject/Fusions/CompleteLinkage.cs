using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HierarchicalClusteringProject.Fusions
{
    public class CompleteLinkage : Fusion
    {
        private const float INITIAL_LARGEST_DISTANCE = float.MaxValue;

        public override float CalculateDistance(Cluster cluster1, Cluster cluster2)
        {
            float largestDistance = INITIAL_LARGEST_DISTANCE;
            foreach (Elements elementCluster1 in cluster1)
            {
                foreach (Elements elementCluster2 in cluster2)
                {
                    float distance = metric.GetDistance(elementCluster1.GetDataPoints(), elementCluster2.GetDataPoints());
                    if (distance > largestDistance)
                        largestDistance = distance;
                }
            }

            return largestDistance;
        }
    }
}
