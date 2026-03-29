using System;
using System.Collections.Generic;

namespace GtMotive.Estimate.Microservice.Domain.Events
{
    /// <summary>
    /// DomainEvent base class.
    /// </summary>
    /// <typeparam name="T">DD.</typeparam>
    public class DomainEvent<T>
    {
        private List<Action<T>> Actions { get; } = [];

        /// <summary>
        /// Register.
        /// </summary>
        /// <param name="callback">callback.</param>
        public void Register(Action<T> callback)
        {
            if (Actions.Exists(a => a.Method == callback.Method))
            {
                return;
            }

            Actions.Add(callback);
        }

        /// <summary>
        /// Publish.
        /// </summary>
        /// <param name="args">args.</param>
        public void Publish(T args)
        {
            foreach (var action in Actions)
            {
                action.Invoke(args);
            }
        }
    }
}
