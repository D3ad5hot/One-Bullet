using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HierarchicalClusteringProject
{
    /// <summary>
    /// The element class is an array of data points
    /// </summary>
    public class Elements
    {
        HashSet<object> dataPoints = new HashSet<object>();
        string id;

        public string ID
        {
            get { return id; }
        }

        /// <summary>
        /// empty constructor
        /// </summary>
        public Elements(){}

        /// <summary>
        /// contructor with parameters
        /// </summary>
        /// <param name="dataPoints">a list of data</param>
        public Elements(object[] dataPoints)
        {
            this.AddDataPoints(dataPoints);
        }

        /// <summary>
        /// constructor with parameters
        /// </summary>
        /// <param name="id">id of the dataset</param>
        public Elements(string id)
        {
            this.id = id;
        }

        public Elements(string id, object[] dataPoints)
        {
            this.id = id;
            this.AddDataPoints(dataPoints);
        }

        public void AddDataPoint(object dataPoint)
        {
            dataPoints.Add(dataPoint);
        }

        /// <summary>
        /// inserts the points int the hashset array
        /// </summary>
        /// <param name="dataPoints">array of points/data</param>
        public void AddDataPoints(object[] dataPoints)
        {
            foreach (object point in dataPoints)
                this.dataPoints.Add(point);          
        }

        public object[] GetDataPoints()
        {
            return dataPoints.ToArray<object>();
        }
    }
}
