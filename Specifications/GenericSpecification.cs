namespace SpecificationPatternSample
{
    using System;
    using System.Linq.Expressions;

    public class SpecificationPattern<TEntity>
    {
        private readonly Expression<Func<TEntity, bool>> _expression;

        public SpecificationPattern(Expression<Func<TEntity, bool>> expression) => _expression = expression;
        public virtual bool IsSatisfied(TEntity entity) => ToExpression().Compile().Invoke(entity);

        public virtual Expression<Func<TEntity, bool>> ToExpression() => _expression;

        public SpecificationPattern<TEntity> AndSpecification(SpecificationPattern<TEntity> spec) => new AndSpecification<TEntity>(this, spec);
        public SpecificationPattern<TEntity> OrSpecification(SpecificationPattern<TEntity> spec) => new OrSpecification<TEntity>(this, spec);
    }
}