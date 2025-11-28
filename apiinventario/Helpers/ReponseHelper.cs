using Microsoft.AspNetCore.Mvc;

namespace apiinventario.Helpers
{
    public class ReponseHelper
    {

        public static async Task<IActionResult> HandleSend
        (
            Func<Task<object?>> callback,
            string? messageSuccess = null
        )
        {
            try
            {

                var result = await callback();

                return new OkObjectResult(new
                {
                    message = messageSuccess ?? "Operación exitosa",
                    status = true,
                    data = result
                });

            }
            catch (Exception e)
            {

                return new ObjectResult(new
                {
                    message = e.Message ?? "Error interno del servidor",
                    status = false,
                    data = (object?)null
                })
                {
                    StatusCode = 500
                };

            }
        }
    }
}
