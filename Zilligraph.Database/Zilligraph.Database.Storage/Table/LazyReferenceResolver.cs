using System.Reflection;
using Zilligraph.Database.Contract;

namespace Zilligraph.Database.Storage.Table
{
    public class LazyReferenceResolver<TForeignRecord> : LazyReference<TForeignRecord> where TForeignRecord : class, new()
    {
        private readonly object _parent;
        private readonly PropertyInfo _parentKeyProperty;
        private readonly IZilligraphTable _foreignTable;
        private readonly string _foreignKey;
        private TForeignRecord? _value;
        private LazyReferenceState _state = LazyReferenceState.NotResolved;

        public LazyReferenceResolver(object parent, PropertyInfo parentKeyProperty, IZilligraphTable foreignTable, string foreignKey)
        {
            _parent = parent;
            _parentKeyProperty = parentKeyProperty;
            _foreignTable = foreignTable;
            _foreignKey = foreignKey;
        }

        public override TForeignRecord? Value
        {
            get
            {
                if (_state == LazyReferenceState.NotResolved)
                {
                    _value = ResolveValue();
                    _state = _value == null
                        ? LazyReferenceState.NotExists
                        : LazyReferenceState.Exists;
                }

                return _value;
            }
        }

        public override LazyReferenceState State => _state;

        private TForeignRecord? ResolveValue()
        {
            var keyValue = _parentKeyProperty.GetValue(_parent);
            if (keyValue != null)
            {
                return (TForeignRecord?)_foreignTable.GetRecord(_foreignKey, keyValue);
            }

            return null;
        }
    }
}
