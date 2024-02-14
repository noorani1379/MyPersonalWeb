using MyPersonalWeb.Models;

namespace MyPersonalWeb.DataModel
{
    public record DTO
    {
        public List<MyPersonalWeb.Models.Message> Content { get; set; }

        //can be other entityModels here
    }
}
