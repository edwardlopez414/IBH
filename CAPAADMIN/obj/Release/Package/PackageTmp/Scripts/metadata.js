// Obtener una referencia al elemento canvas del DOM
const $grafica = document.querySelector("#grafica");
// Las etiquetas son las que van en el eje X. 
const etiquetas = ["Enero", "Febrero", "Marzo", "Abril"];
// Podemos tener varios conjuntos de datos. Comencemos con uno
const datosVentas2020 = {
    label: "Asistencias por mes",
    data: [5000, 1500, 8000, 5102], // La data es un arreglo que debe tener la misma cantidad de valores que la cantidad de etiquetas
    backgroundColor: '#FFFFFF', // Color de fondo
    borderColor: [
        '#00FFD0',
        '#0015FF',
        '#8700FF',
        '#FF00F4',
    ],// Colo, // Color del borde
    borderWidth: 5,// Ancho del borde
   
    
};
new Chart($grafica, {
    type: 'line',// Tipo de gráfica
    options: {
        animation: true,
        plugins: {
            legend: {
                display: false
            },
            tooltip: {
                enabled: false
            }
        }
    },
    data: {
        labels: etiquetas,
        datasets: [
            datosVentas2020,
            // Aquí más datos...
        ]
    },
    options: {
        scales: {
            yAxes: [{
                ticks: {
                    beginAtZero: true
                }
            }],
        },
    }
});

// Obtener una referencia al elemento canvas del DOM
const $grafica2 = document.querySelector("#grafica2");
// Las etiquetas son las que van en el eje X. 
const etiquetas2 = ["Enero", "Febrero", "Marzo", "Abril","Mayo","Junio"]
// Podemos tener varios conjuntos de datos. Comencemos con uno
const datosVentas2021 = {
    label: "Asistencias por mes",
    data: [5000, 1500, 8000, 5102,4044,6002], // La data es un arreglo que debe tener la misma cantidad de valores que la cantidad de etiquetas
    backgroundColor: '#FFFFFF',
    borderColor: [
        '#00FFD0',
        '#0015FF',
        '#8700FF',
        '#FF00F4',
        '#8700FF',
        '#FF00F4',
    ],// Colo, // Color del borde
    borderWidth: 2, // Ancho del borde
};
new Chart($grafica2, {
    type: 'bar',// Tipo de gráfica
    options: {
        animation: true,
        plugins: {
            legend: {
                display: false
            },
            tooltip: {
                enabled: false
            }
        }
    },
    data: {
        labels: etiquetas2,
        datasets: [
            datosVentas2021,
            // Aquí más datos...
        ]
    },
    options: {
        scales: {
            yAxes: [{
                ticks: {
                    beginAtZero: true
                }
            }],
        },
    }
});

//// Obtener una referencia al elemento canvas del DOM
//const $grafica3 = document.querySelector("#grafica3");
//// Las etiquetas son las porciones de la gráfica
//const etiquetas3 = ["Ventas", "Donaciones", "Trabajos", "Publicidad"]
//// Podemos tener varios conjuntos de datos. Comencemos con uno
//const datosIngresos = {
//    data: [1500, 400, 2000, 7000], // La data es un arreglo que debe tener la misma cantidad de valores que la cantidad de etiquetas
//    // Ahora debería haber tantos background colors como datos, es decir, para este ejemplo, 4
//    backgroundColor: [
//        'red',
//        'blue',
//        'pink',
//        'rgba(229,112,126,0.2)',
//    ],// Color de fondo
//    borderColor: [
//        'rgba(163,221,203,1)',
//        'rgba(232,233,161,1)',
//        'rgba(230,181,102,1)',
//        'rgba(229,112,126,1)',
//    ],// Color del borde
//    borderWidth: 1,// Ancho del borde
//};
//new Chart($grafica3, {
//    type: 'pie',// Tipo de gráfica. Puede ser dougnhut o pie
//    data: {
//        labels: etiquetas3,
//        datasets: [
//            datosIngresos,
//            // Aquí más datos...
//        ]
//    },
//});