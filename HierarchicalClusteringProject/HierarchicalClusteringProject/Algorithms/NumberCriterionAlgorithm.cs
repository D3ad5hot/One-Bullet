﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HierarchicalClusteringProject.Algorithms
{
    /// <summary>
    /// Implements the cluster algorithm by stopping it as soon as a specified count of clusters is reached 
    /// </summary>
    internal class NumberCriterionAlgorithm: AbstractCriterionAlgorithm
    {
        int desiredClusterCount;

        /// <summary>
        /// Creates a new instance of the NumberCriterionAlgorithm
        /// </summary>
        /// <param name="desiredClusterCount">clusters ammount</param>
        internal NumberCriterionAlgorithm(int desiredClusterCount)
        {
            this.desiredClusterCount = desiredClusterCount;
        }


        protected override bool isFinished(ICollection<Cluster> currentClusters, ClusterPair lowestDistancePair)
        {
            return desiredClusterCount < 1 || desiredClusterCount >= currentClusters.Count; 
        }
    }
}
