using System;

namespace WebAPI.Infrastructure
{
    public interface ICacheService
    {
        object ReadFromCache(Guid Id);
        void WriteToCache(Guid Id, object content);
    }

    public class CacheService : ICacheService
    {
        public object ReadFromCache(Guid Id)
            => Id == Guid.Empty ? null : new { Id = Id, Content = "resultado da consulta" };

        public void WriteToCache(Guid Id, object content)
        { }
    }
}
