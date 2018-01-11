using System;
using TestingDemo.Models;

namespace TestingDemo.Tests.mocks
{
    public class MockServiceBase<T>
        where T : class
    {
        private bool _getWasCalled;
        private int _entityId;
        private Type _entityType = typeof(T);
        private T _entityInstance;

        public bool ThrowOnSave { get; set; }

        public T Get(int id)
        {
            _getWasCalled = true;
            _entityId = id;

            if (_entityType == typeof(User))
                return _entityInstance ?? MockEntities.User as T;

            else if (_entityType == typeof(Order))
                return _entityInstance?? MockEntities.Order as T;

            else
                throw new ArgumentException($"Unhandled type {_entityType}");
        }

        public bool GetWasCalled => _getWasCalled;

        public bool GetWasCalledWith(int test) => 
            _getWasCalled && test == _entityId;

        public void GetReturns(T instance) =>
            _entityInstance = instance;

        public void Save(T entity)
        {
            if (ThrowOnSave)
                throw new Exception("FAIL");
        }
    }
}
