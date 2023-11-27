using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyStay.Domain.Helpers
{
    public class UpdatedMapperProperties<T, F>
    {
        public Task<T> MapperUpdate(T mapTo, F mapFrom)
        {
            // copy fields
            var typeOfMapFrom = mapFrom!.GetType();
            var typeOfMapTo = mapTo!.GetType();
            try
            {
                // copy properties
                foreach (var propertyOfMapFrom in typeOfMapFrom.GetProperties())
                {
                    var propertyOfMapTo = typeOfMapTo.GetProperty(propertyOfMapFrom.Name);
                    if (propertyOfMapFrom.GetValue(mapFrom) != null && propertyOfMapFrom.PropertyType.Name != "List`1")//^ (propertyOfMapFrom.PropertyType.FullName == "System.Guid" && propertyOfMapFrom.GetValue(mapFrom).Equals((object)Guid.Empty)))
                    {
                        if (propertyOfMapTo != null)
                        {
                            if (propertyOfMapFrom.PropertyType.FullName!.Contains(propertyOfMapTo.PropertyType.FullName!))
                            {
                                propertyOfMapTo.SetValue(mapTo, propertyOfMapFrom.GetValue(mapFrom));
                            }
                            else
                            {
                                propertyOfMapTo.SetValue(mapTo, (int)propertyOfMapFrom.GetValue(mapFrom)!);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Task.FromResult(mapTo);
        }
    }
}
