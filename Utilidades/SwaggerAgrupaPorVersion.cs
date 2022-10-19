using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace webapi.Utilidades
{
    public class SwaggerAgrupaPorVersion : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            var namespaceControlador = controller.ControllerType.Namespace; // esto me da el nombre del namesspace por ejemplo
                                                                            // Controllers.V1
            var versionAPI = namespaceControlador.Split('.').Last().ToLower(); // asi encontramos el nombre -> v1
            controller.ApiExplorer.GroupName = versionAPI; //y con esto agrupa 
        }
    }
}
