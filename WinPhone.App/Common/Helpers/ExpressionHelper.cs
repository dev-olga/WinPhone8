using System;
using System.Collections.Generic;
using System.Linq;

namespace WinPhone.App.Common.Helpers
{
    using System.Linq.Expressions;
    using System.Reflection;

    public static class ExpressionHelper
    {
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
        private static MemberExpression GetMemberExpression<T>(Expression<T> e)
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
        private static MemberInfo[] GetExpressionMemberInfos<T>(Expression<T> expression)
        {
            var info = new List<MemberInfo>();
            var member = GetMemberExpression(expression);
            while (member != null)
            {
                // we don't need first level
                if (member.Expression as MemberExpression != null || member.Expression as ParameterExpression != null
                    || member.Expression as ConstantExpression != null)
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
    }
}
