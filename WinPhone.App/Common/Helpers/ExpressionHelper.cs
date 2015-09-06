using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinPhone.App.Common.Helpers
{
    using System.Linq.Expressions;
    using System.Reflection;

    public static class ExpressionHelper
    {
        /// <summary>
        /// extend provided expression with required property and returns new expression
        /// </summary>
        /// <typeparam name="T">return type of initial expression</typeparam>
        /// <typeparam name="TProp">type of required property</typeparam>
        /// <param name="expression">initial expression</param>
        /// <param name="property">lambda with required property</param>
        /// <returns>new expression</returns>
        public static Expression<Func<TProp>> GetExpressionForProperty<T, TProp>(Expression<Func<T>> expression, Expression<Func<T, TProp>> property)
        {
            var elements = GetExpressionMembers(property).Reverse();
            var innerExpression = elements.Aggregate(expression.Body, Expression.Property);
            var nestedExpression = Expression.Lambda<Func<TProp>>(innerExpression, null);
            return nestedExpression;
        }

        public static string GetFullPropertyName<T, TProp>(
            Expression<Func<T>> expression,
            Expression<Func<T, TProp>> property)
        {
            return GetFullPropertyName(GetExpressionForProperty(expression, property));
        }

        /// <summary>
        /// Get dot separated full property name.
        /// For lambda a.B.C.Property value will be like "B.C.Property"
        /// </summary>
        /// <typeparam name="T">any class</typeparam>
        /// <param name="e">lambda expresion with property</param>
        /// <param name="glue">separator to join properties names</param>
        /// <returns>full property name</returns>
        public static string GetFullPropertyName<T>(Expression<Func<T>> e, string glue = ".")
        {
            return string.Join(glue, GetExpressionMembers(e).ToArray().Reverse());
        }

        /// <summary>
        /// Gets correct MemberExpression instance from expression.
        /// Require for correct operations with nullable date.
        /// </summary>
        /// <typeparam name="T">return type for lambda expression. Really it's not required.</typeparam>
        /// <param name="e">lambda expression</param>
        /// <returns>MemberExpression instance</returns>
        /// <exception cref="ArgumentException">throws exception if MemberExpression can't be retrieved.</exception>
        public static MemberExpression GetMemberExpression<T>(Expression<T> e)
        {
            var member = e.Body as MemberExpression;
            if (member != null)
            {
                return member;
            }

            // for DateTime
            var unaryExp = e.Body as UnaryExpression;
            if (unaryExp != null)
            {
                member = unaryExp.Operand as MemberExpression;
                if (member != null)
                {
                    return member;
                }
            }

            throw new ArgumentException(@"'expression' should be a member expression or a method call expression.", @"e");
        }

        /// <summary>
        /// Get properties names for expression.
        /// </summary>
        /// <typeparam name="T">Expression type</typeparam>
        /// <param name="expression">expression itself</param>
        /// <returns>set of properties</returns>
        public static MemberInfo[] GetExpressionMemberInfos<T>(Expression<T> expression)
        {
            var info = new List<MemberInfo>();
            var member = GetMemberExpression(expression);
            while (member != null)
            {
                // we don't need first level
                if (member.Expression as MemberExpression != null || member.Expression as ParameterExpression != null)
                {
                    info.Add(member.Member);
                }

                member = member.Expression as MemberExpression;
            }

            return info.ToArray();
        }

        /// <summary>
        /// Get properties names for expression.
        /// </summary>
        /// <typeparam name="T">Expression type</typeparam>
        /// <param name="expression">expression itself</param>
        /// <returns>set of properties</returns>
        private static string[] GetExpressionMembers<T>(Expression<T> expression)
        {
            return GetExpressionMemberInfos(expression).Select(m => m.Name).ToArray();
        }

        /// <summary>
        /// Get property name from lambda expression
        /// </summary>
        /// <typeparam name="T">expression type</typeparam>
        /// <param name="e">lambda expresion with property</param>
        /// <returns>property name</returns>
        public static string GetPropertyName<T>(Expression<T> e)
        {
            var member = GetMemberExpression(e);
            return member.Member.Name;
        }
    }
}
