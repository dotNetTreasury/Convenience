﻿using System;
using System.Linq;
using System.Linq.Expressions;

namespace Convience.Util.Extension
{
    public static class ExpressionExtension
    {
        public static Expression<Func<T, bool>> TrueExpression<T>() { return t => true; }

        public static Expression<Func<T, bool>> FalseExpression<T>() { return t => false; }

        /// <summary>
        /// 条件与（字符串）
        /// </summary>
        public static Expression<Func<T, bool>> AndIfHaveValue<T>(this Expression<Func<T, bool>> expression,
            string value, Expression<Func<T, bool>> andExpression)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                var invokedExpr = Expression.Invoke(andExpression, expression.Parameters.Cast<Expression>());
                var newExp = Expression.And(expression.Body, invokedExpr);
                expression = Expression.Lambda<Func<T, bool>>(newExp, expression.Parameters);
            }
            return expression;
        }

        /// <summary>
        /// 条件与（字符串以外类型）
        /// </summary>
        public static Expression<Func<T, bool>> AndIfHaveValue<T>(this Expression<Func<T, bool>> expression,
            object value, Expression<Func<T, bool>> andExpression)
        {
            if (value != null)
            {
                var invokedExpr = Expression.Invoke(andExpression, expression.Parameters.Cast<Expression>());
                var newExp = Expression.And(expression.Body, invokedExpr);
                expression = Expression.Lambda<Func<T, bool>>(newExp, expression.Parameters);
            }
            return expression;
        }

        /// <summary>
        /// 与
        /// </summary>
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expression, Expression<Func<T, bool>> andExpression)
        {
            var invokedExpr = Expression.Invoke(andExpression, expression.Parameters.Cast<Expression>());
            var newExp = Expression.And(expression.Body, invokedExpr);
            return Expression.Lambda<Func<T, bool>>(newExp, expression.Parameters);
        }
    }
}
