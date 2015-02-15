using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HierarchicalClusteringProject;
using HierarchicalClusteringProject.Fusions;
using HierarchicalClusteringProject.Matrics;

namespace HierarchicalClusteringProject.Algorithms
{
    /// <summary>
    /// Abstract class to implement the generic part of the algorithm. Subclkasses will implement the stopping condition of the algorithm.
    /// </summary>
    internal abstract class AbstractCriterionAlgorithm
    {
        /// <summary>
        ///  Starts the clustering process
        /// </summary>
        /// <param name="elements"></param>
        /// <param name="fusion"></param>
        /// <param name="metric"></param>
        /// <returns></returns>
        internal protected Cluster[] Cluster(List<Elements> elements, Fusion fusion, IDistanceMetric metric)
        {
            HashSet<Cluster> clusters = new HashSet<Cluster>();
            ClusterPairs pairs = new ClusterPairs();
        
            //Step 1. Initialise each element as a cluster
            foreach (Elements e in elements)
            {
                Cluster cl = new Cluster(fusion);
                cl.AddElement(e);
                clusters.Add(cl);
            }
            
            //Step 2. a) Calculate the distance of all clusters to all other clusters
            foreach (Cluster cl1 in clusters)
            {
                foreach (Cluster cl2 in clusters)
                {
                    if (cl1 == cl2)
                        continue;
                    ClusterPair pair = new ClusterPair(cl1, cl2, cl1.CalculateDistance(cl2));
                    pairs.AddPair(pair);
                }
            }

            //Step 2. b)Initialse the pair with the lowest distance to each other
            ClusterPair lowestDistancePair = pairs.LowestDistancePair;
        
           //Step 3. Merge clusters to new clusters and recalculate distances in a loop until there are only countCluster clusters
            while(!isFinished(clusters, lowestDistancePair))
            {
                // a) Merge: Create a new cluster and add the elements oth the two old clusters
                lowestDistancePair = pairs.LowestDistancePair;
                Cluster newCluster = new Cluster(fusion);
                newCluster.AddElements(lowestDistancePair.Cluster1.GetElements());
                newCluster.AddElements(lowestDistancePair.Cluster2.GetElements());

                // b) Remove the two old clusters from the clusters
                clusters.Remove(lowestDistancePair.Cluster1);
                clusters.Remove(lowestDistancePair.Cluster2);

                // c) Remove the two old clusters from pairs
                pairs.RemovePairFromOldClusters(lowestDistancePair.Cluster1, lowestDistancePair.Cluster2);

                // d) Calculate the distance of the new cluster to all other clusters and save each as pair
                foreach (Cluster cluster in clusters)
                {
                    ClusterPair pair = new ClusterPair(cluster, newCluster, cluster.CalculateDistance(newCluster));
                    pairs.AddPair(pair);
                }

                // e) Add the new cluuster to clusters
                clusters.Add(newCluster);
            }

            return clusters.ToArray<Cluster>();
        }

        /// <summary>
        /// Checks is the algorithm has to stop
        /// </summary>
        /// <param name="currentClusters"></param>
        /// <param name="lowestDistancePair"></param>
        /// <returns></returns>
        protected abstract bool isFinished(ICollection<Cluster> currentClusters, ClusterPair lowestDistancePair); 
    }
}
