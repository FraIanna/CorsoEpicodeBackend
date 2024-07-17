// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

document.addEventListener('DOMContentLoaded', function () {
    var tipoSelect = document.getElementById('Tipo');
    var codiceFiscaleDiv = document.getElementById('codiceFiscaleDiv');
    var partitaIvaDiv = document.getElementById('partitaIvaDiv');

    function handleTipoChange() {
        if (tipoSelect.value === 'true') {
            codiceFiscaleDiv.style.display = 'none';
            partitaIvaDiv.style.display = 'flex';
            partitaIvaDiv.style.flexDirection = 'column';
        } else {
            codiceFiscaleDiv.style.display = 'flex';
            codiceFiscaleDiv.style.flexDirection = 'column'
            partitaIvaDiv.style.display = 'none';
        }
    }

    tipoSelect.addEventListener('change', handleTipoChange);
    handleTipoChange();
});