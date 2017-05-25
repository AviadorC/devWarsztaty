using System;
namespace DevWorkshops.Service.Model
{
    public class GeneralResponse<T> : GeneralResponse
    {
        public T Data { get; set; }
    }
}
