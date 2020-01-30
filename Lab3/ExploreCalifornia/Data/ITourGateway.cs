using ExploreCalifornia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExploreCalifornia.Data
{
    interface ITourGateway
    {
        Task<IEnumerable<Tour>> SelectAll();
        Task<Tour> SelectById(int? id);
        Tour Insert(Tour tour);
        Tour Update(Tour tour);
        Tour Delete(int? id);
        bool Exist(int ? id);
    }
}
