using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HierarchicalClusteringProject.Fusions
{
    public class SingleLinkage:Fusion
    {
        private const float INITIATL_LEAST_DISTANE = float.MaxValue;

        public override float CalculateDistance(Cluster cluster1, Cluster cluster2)
        {
            float leastDistance = INITIATL_LEAST_DISTANE;

            foreach (Elements elementCluster1 in cluster1)
            {
                foreach (Elements elementCluster2 in cluster2)
                {
                    float distance = metric.GetDistance(elementCluster1.GetDataPoints(), elementCluster2.GetDataPoints());
                    if (distance < leastDistance)
                        leastDistance = distance;
                }
            }

            return leastDistance;
        }
    }
}
