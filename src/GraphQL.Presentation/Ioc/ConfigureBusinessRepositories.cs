﻿using System;
using System.Reactive.Linq;
using GraphQL.Business;
using GraphQL.Business.Repositories;
using GraphQL.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQL.Presentation.Ioc
{
    internal class ConfigureBusinessRepositories : Command<IServiceCollection, IServiceCollection>, IConfigureServices
    {
        public override IObservable<IServiceCollection> Execute(IServiceCollection input)
        {
            return Observable.Return(input)
                .Do(services => services.AddTransient<IMessageRepository, MessageRepository>());
        }
    }
}
