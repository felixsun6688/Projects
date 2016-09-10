using System.Collections.Generic;

namespace AorangiPeak.Common.Query
{
    public class Query : IQuery
    {
        private List<Criterion> _criterions;
        private List<string> _selectPropertyNames;
        private string _tableName;
        private QueryOperator _queryOperator;
        private OrderByClause _orderByClause;

        public List<Criterion> Criterions
        {
            get { return this._criterions; }
        }

        public List<string> SelectPropertyNames
        {
            get { return this._selectPropertyNames; }
        }

        public string TableName
        {
            get { return this._tableName; }
        }

        // And, Or
        public QueryOperator QueryOperator
        {
            get { return _queryOperator; }
        }

        // Order by property
        public OrderByClause OrderByClause
        {
            get { return _orderByClause; }
        }

        public Query(string tableName, QueryOperator queryOperator, 
            OrderByClause orderByClause)
        {
            _tableName = tableName;
            _queryOperator = queryOperator;
            _orderByClause = orderByClause;

            _criterions = new List<Criterion>();
            _selectPropertyNames = new List<string>();
        }

        public void AddCriterion(Criterion criterion)
        {
            _criterions.Add(criterion);
        }

        public void AddSelectProperty(string propertyName)
        {
            _selectPropertyNames.Add(propertyName);
        }
    }
}
