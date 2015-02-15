using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HierarchicalClusteringProject.Matrics
{
    public interface IDistanceMetric
    {
        float GetDistance(object[] set1, object[] set2);
    }
}
