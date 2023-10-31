document.addEventListener("DOMContentLoaded", search);
const URL_API = 'https://localhost:7016/api/'


function init(){
    search()
}

async function search() {
    var url = URL_API + 'cocina'
    var response = await fetch(url, {
        "method": 'GET',
        "headers": {
            "Content-Type": 'application/json'
        }
    })

var resultado = await response.json();

console.log(resultado)

    var row = `<tr>
    <td>1</td>
    <td>plato</td>
    <td>descripcion</td>
    <td>terminado</td>
    <td>
        <a>Editar</a>
        <a>Eliminar</a>
    </td>
    </tr>`

    document.querySelector(`#pedido > tbody`).outerHTML = 
    row
}
