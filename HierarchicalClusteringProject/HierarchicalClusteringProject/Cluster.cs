using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HierarchicalClusteringProject.Fusions;

namespace HierarchicalClusteringProject
{
    public class Cluster:IEnumerable
    {
        HashSet<Elements> elements = new HashSet<Elements>();
        Fusion fusion;

        public Cluster(Fusion fusion)
        {
            this.fusion = fusion;
        }

        internal void  AddElement(Elements element)
        {
            this.elements.Add(element);
        }

        internal void AddElements(Elements[] elements)
        {
            foreach (Elements e in elements)
            {
                this.elements.Add(e);
            }
        }
        internal Elements[] GetElements()
        {
            return elements.ToArray<Elements>();
        }

        internal float CalculateDistance(Cluster otherCluster)
        {
            return fusion.CalculateDistance(this, otherCluster);
        }
        

        #region IEnumerable Member
        public IEnumerator GetEnumerator()
        {
            return elements.GetEnumerator();
        }
        #endregion
    }
}
