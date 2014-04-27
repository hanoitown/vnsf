using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Vnsf.Infrastructure.EventSourcing
{
    class GenericMethodActionBuilder<TArgetBase, TParamBase>
    {
        readonly Dictionary<Type, Action<TArgetBase, TParamBase>> _actionCache = new Dictionary<Type, Action<TArgetBase, TParamBase>>();

        readonly Type _targetType;
        readonly string _method;
        public GenericMethodActionBuilder(Type targetType, string method)
        {
            this._targetType = targetType;
            this._method = method;
        }

        public Action<TArgetBase, TParamBase> GetAction(TParamBase paramInstance)
        {
            var paramType = paramInstance.GetType();

            if (!_actionCache.ContainsKey(paramType))
            {
                _actionCache.Add(paramType, BuildActionForMethod(paramType));
            }

            return _actionCache[paramType];
        }

        private Action<TArgetBase, TParamBase> BuildActionForMethod(Type paramType)
        {
            var handlerType = _targetType.MakeGenericType(paramType);

            var ehParam = Expression.Parameter(typeof(TArgetBase));
            var evtParam = Expression.Parameter(typeof(TParamBase));
            var invocationExpression =
                Expression.Lambda(
                    Expression.Block(
                        Expression.Call(
                            Expression.Convert(ehParam, handlerType), handlerType.GetMethod(_method),
                            Expression.Convert(evtParam, paramType))),
                    ehParam, evtParam);

            return (Action<TArgetBase, TParamBase>)invocationExpression.Compile();
        }
    }
}
