using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AorangiPeak.Common.Query
{
    public static class QueryTranslator
    {
        public static void Translate(this Query query, SqlCommand command)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(GenerateBaseQuery(query));

            if (query.Criterions.Count > 0) sql.Append("WHERE ");
            foreach (Criterion criterion in query.Criterions)
            {
                sql.Append(AddFilterClauseFrom(criterion));
                command.Parameters.Add(new SqlParameter("@ "+criterion.PropertyName, criterion.Value));
            }

            sql.Append(GenerateOrderByClauseFrom(query.OrderByClause));
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = sql.ToString();
        }

        private static string GenerateBaseQuery(Query query)
        {
            StringBuilder baseQuery = new StringBuilder();
            baseQuery.Append("SELECT ");
            List<string> seletPropertyNames = query.SelectPropertyNames;
            if (seletPropertyNames.Count == 0)
            {
                baseQuery.Append("* FROM " + query.TableName);
            }
            else
            {
                foreach (string property in seletPropertyNames)
                {
                    baseQuery.Append(property + ",");
                }

                baseQuery.Remove(baseQuery.ToString().LastIndexOf(','),1);
                baseQuery.Append(" FROM " + query.TableName);
            }
            return baseQuery.ToString();
        }

        private static string GenerateOrderByClauseFrom(OrderByClause orderByClause)
        {
            return string.Format("ORDER BY {0} {1}", 
                orderByClause.PropertyName,
                orderByClause.Desc?" DESC":" ASC");
        }

        private static string GetQueryOperator(Query query)
        {
            if (query.QueryOperator==QueryOperator.And)
            {
                return "AND ";
            }
            else
            {
                return "OR ";
            }
        }

        private static string AddFilterClauseFrom(Criterion criterion)
        {
            return string.Format("{0} {1} @ {2}", 
                criterion.PropertyName,
                FindSQLOperatorFor(criterion.CriteriaOperator),
                criterion.PropertyName);
        }

        private static string FindSQLOperatorFor(CriteriaOperator criteriaOperator)
        {
            switch (criteriaOperator)
            {
                case CriteriaOperator.Contain:
                    return "like% ";
                case CriteriaOperator.Equal:
                    return "=";
                case CriteriaOperator.LessThanOrEqual:
                    return "<=";
                case CriteriaOperator.MoreThanOrEqual:
                    return ">=";
                default:
                    return string.Empty;
            }
        }
    }
}
