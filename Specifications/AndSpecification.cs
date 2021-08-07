namespace SpecificationPatternSample
{
    using System.Linq;
    using System;
    using System.Linq.Expressions;

    public class AndSpecification<TEntity> : SpecificationPattern<TEntity>
    {

        public readonly SpecificationPattern<TEntity> _rightSpec;

        public AndSpecification(SpecificationPattern<TEntity> leftSpec, SpecificationPattern<TEntity> rightSpec)
        : base(leftSpec.ToExpression())
        {
            _rightSpec = rightSpec;
        }

        public override Expression<Func<TEntity, bool>> ToExpression()
        {
            var leftExpression = base.ToExpression();
            var rightExpression = _rightSpec.ToExpression();
            var exprBody = Expression.AndAlso(leftExpression.Body, rightExpression.Body);
            var paramExpr = Expression.Parameter(typeof(TEntity));
            exprBody = (BinaryExpression)new ParameterReplacer(paramExpr).Visit(exprBody);

            return Expression.Lambda<Func<TEntity, bool>>(exprBody, paramExpr);
        }
    }
}