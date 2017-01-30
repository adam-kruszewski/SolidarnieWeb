using System.Web.Mvc;
using Kruchy.Model.DataTypes.Walidacja;

namespace SolidarnieWebApp.Walidacja
{
    public static class ControllerExtension
    {
        public static IWalidacjaListener DajListeneraWalidacji(
            this Controller controller)
        {
            return new WalidacjaListenerDlaModelState(controller.ModelState);
        }

        private class WalidacjaListenerDlaModelState : IWalidacjaListener
        {
            private readonly ModelStateDictionary modelStateDictionary;

            public WalidacjaListenerDlaModelState(
                ModelStateDictionary modelStateDictionary)
            {
                this.modelStateDictionary = modelStateDictionary;
            }

            public void Blad(string komunikat, string wlasciwosc)
            {
                modelStateDictionary.AddModelError(wlasciwosc, komunikat);
            }

            public void Ostrzezenie(string komunikat, string wlasciwosc)
            {
            }
        }
    }
}