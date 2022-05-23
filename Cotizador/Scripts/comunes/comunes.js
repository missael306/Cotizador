var Cotizador = Cotizador || {};
Cotizador.Comun = Cotizador.Comun || {};

Cotizador.Comun = (function () {
    "use strict";
    let ComunLoad = function () {

        this.Initialize = function () {
            Setting()            
            this.MaskInputs();
        };

        this.KeySettings = {
            0 : "MontoMinimo",
            1 : "MontoMaximo",
            2 : "PorcentajeEnganche"
        };

        let Setting = function () {
            $.ajax({
                url: `/Setting/GetInitialSetting`,                
            }).done(function (response) {                
                response.data.forEach(function (item, index) {
                    localStorage.setItem(Cotizador.Comun.KeySettings[index], item.Value);
                })
            });
        }

        this.MaskInputs = function () {
            $('.money').mask("#,##0", { reverse: true });
        }
    };

    return new ComunLoad();
})();
(function ($, window, document) {
    "use strict";
    $(function () {
        Cotizador.Comun.Initialize();
    });
})(window.jQuery, window, document);