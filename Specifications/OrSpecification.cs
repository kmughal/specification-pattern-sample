namespace SpecificationPatternSample
{
    using System.Linq;
    using System;
    using System.Linq.Expressions;

    public class OrSpecification<TEntity> : SpecificationPattern<TEntity>
    {
        public readonly SpecificationPattern<TEntity> _rightSpec;

        public OrSpecification(SpecificationPattern<TEntity> leftSpec, SpecificationPattern<TEntity> rightSpec)
        : base(leftSpec.ToExpression())
        {
            _rightSpec = rightSpec;
        }

        public override Expression<Func<TEntity, bool>> ToExpression()
        {
            Expression<Func<TEntity, bool>> leftExpression = base.ToExpression();
            Expression<Func<TEntity, bool>> rightExpression = _rightSpec.ToExpression();

            var exprBody = Expression.OrElse(leftExpression.Body, rightExpression.Body);
            var paramExpr = Expression.Parameter(typeof(TEntity));
            exprBody = (BinaryExpression)new ParameterReplacer(paramExpr).Visit(exprBody);

            return Expression.Lambda<Func<TEntity, bool>>(exprBody, paramExpr);
        }
    }
}