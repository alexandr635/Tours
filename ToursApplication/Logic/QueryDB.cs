using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase;

namespace Logic
{
    public class QueryDB
    {
        public static TourBaseEntities GetContext()
        {
            return DataBase.TourBaseEntities.GetContext();
        }

        public static Exception DeleteHotel(List<Hotel> hotels)
        {
            TourBaseEntities.GetContext().Hotels.RemoveRange(hotels);
            try
            {
                GetContext().SaveChanges();
                return null;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        public static Exception EditHotel(Hotel currentHotel)
        {
            Hotel change = GetContext().Hotels.Where(h => h.Id == currentHotel.Id).FirstOrDefault();
            change = currentHotel;
            try
            {
                GetContext().SaveChanges();
                return null;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        public static Exception AddHotel(Hotel currentHotel)
        {
            GetContext().Hotels.Add(currentHotel);

            try
            {
                GetContext().SaveChanges();
                return null;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }
    }
}
