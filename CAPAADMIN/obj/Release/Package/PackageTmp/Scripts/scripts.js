
function ocultarRecicler(opcion) {
    const APP = document.querySelector("#mainprincipal");
    APP.childNodes[1].style.display = "none";
    APP.childNodes[3].style.display = "none";
    APP.childNodes[5].style.display = "none";
    APP.childNodes[opcion].style.display = "";
}


