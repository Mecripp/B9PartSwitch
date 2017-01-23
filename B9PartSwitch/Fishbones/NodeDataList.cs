﻿using System;
using B9PartSwitch.Fishbones.Context;

namespace B9PartSwitch.Fishbones
{
    public class NodeDataList
    {
        private INodeDataField[] fields;

        public NodeDataList(params INodeDataField[] fields)
        {
            fields.ThrowIfNullArgument(nameof(fields));

            this.fields = new INodeDataField[fields.Length];

            for (int i = 0; i < fields.Length; i++)
            {
                INodeDataField field = fields[i];

                if (field.IsNull()) throw new ArgumentNullException($"Encountered null in list at position {i}", nameof(fields));

                this.fields[i] = field;
            }
        }

        public void Load(ConfigNode node, OperationContext context)
        {
            node.ThrowIfNullArgument(nameof(node));
            context.ThrowIfNullArgument(nameof(context));

            foreach (INodeDataField field in fields)
            {
                field.Load(node, context);
            }
        }

        public void Save(ConfigNode node, OperationContext context)
        {
            node.ThrowIfNullArgument(nameof(node));
            context.ThrowIfNullArgument(nameof(context));

            foreach (INodeDataField field in fields)
            {
                field.Save(node, context);
            }
        }
    }
}
