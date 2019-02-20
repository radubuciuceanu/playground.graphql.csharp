﻿using System;
using System.Linq;
using System.Reactive.Linq;
using GraphQL.Business;
using GraphQL.Business.Models.Parameters;
using GraphQL.Data.Entities;

namespace GraphQL.Data.Commands
{
    public class FilterMessages : Command<IQueryable<Message>, IQueryable<Message>>, IFilterMessages
    {
        private GetMessagesParameter _parameter;

        public IFilterMessages With(GetMessagesParameter parameter)
        {
            _parameter = parameter;
            return this;
        }

        public override IObservable<IQueryable<Message>> Execute(IQueryable<Message> input)
        {
            return Observable.Return(input)
                .Select(FilterById);
        }

        private IQueryable<Message> FilterById(IQueryable<Message> entities)
        {
            if (!string.IsNullOrWhiteSpace(_parameter.Id))
            {
                Message found = entities.Single(entity => entity.Id == _parameter.Id);
                return new[] { found }.AsQueryable();
            }

            return entities;
        }
    }
}