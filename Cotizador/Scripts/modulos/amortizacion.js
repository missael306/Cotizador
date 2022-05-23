var Cotizador = Cotizador || {};
Cotizador.Amortizacion = Cotizador.Amortizacion || {};

Cotizador.Amortizacion = (function () {
    "use strict";
    let AmortizacionLoad = function () {
        let Comun = Cotizador.Comun;

        this.initialize = function () {
            iniTable();
        };

        let iniTable = function () {
            $("#amortizationTable").DataTable({
                "searching": true,
                "ordering": false,
                "info": false,
                "dom": "t<'bottom'ip>",
                "language": {
                    "url": "/Scripts/plugins/datatable_language.json"
                },
            });
        }
  
    };

    return new AmortizacionLoad();
})();
(function ($, window, document) {
    "use strict";
    $(function () {
        Cotizador.Amortizacion.initialize();
    });
})(window.jQuery, window, document);