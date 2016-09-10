namespace AorangiPeak.Common.Query
{
    public class Criterion
    {
        private string _propertyName;
        private object _value;
        private CriteriaOperator _criteriaOperator;

        public object Value
        {
            get { return this._value; }
        }

        public string PropertyName
        {
            get { return this._propertyName; }
        }

        public CriteriaOperator CriteriaOperator
        {
            get { return this._criteriaOperator; }
        }

        public Criterion(string propertyName, object value, CriteriaOperator criteriaOperator)
        {
            this._propertyName = propertyName;
            this._value = value;
            this._criteriaOperator = criteriaOperator;
        }
    }
}
