using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExploreCalifornia.Data
{
    interface DateGateway<T>where T : class
    {
        Task<IEnumerable<T>> SelectAll();
        Task<T> SelectById(int? id);
        T Insert(T t);
        T Update(T t);
        T Delete(int? id);
        bool Exist(int? id);
    }
  
}

