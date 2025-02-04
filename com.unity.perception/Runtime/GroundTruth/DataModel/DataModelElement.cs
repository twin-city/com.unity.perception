﻿using System;

namespace UnityEngine.Perception.GroundTruth.DataModel
{
    /// <summary>
    /// Parent class for all data model objects. <see cref="IMessageProducer"/>
    /// </summary>
    public abstract class DataModelElement : IMessageProducer
    {
        public abstract string modelType { get; }

        protected DataModelElement(string id)
        {
            this.id = id;
        }

        /// <summary>
        /// The ID of the component.
        /// </summary>
        public string id { get; set; }

        /// <inheritdoc />
        public virtual void ToMessage(IMessageBuilder builder)
        {
            builder.AddString("@type", modelType);
            builder.AddString("id", id);
        }

        /// <summary>
        /// Is the component valid?
        /// </summary>
        /// <returns>Is the component valid?</returns>
        public virtual bool IsValid()
        {
            return !string.IsNullOrEmpty(id);
        }
    }
}
