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
        },
        
    })

var resultado = await response.json();

var html = ''
for (cocina of resultado){
    var row = `<tr>
    <td>${cocina.id}</td>
    <td>${cocina.plato}</td>
    <td>${cocina.descripcion}</td>
    <td>${cocina.terminado}</td>
    <td>
        <a                              class="botonEditar">Editar</a>
        <a href="#" onclick="remove(${cocina.id})" class="botonEliminar" >Eliminar</a>
    </td>
    </tr>`
    html = html + row;
}
    document.querySelector(`#pedido > tbody`).outerHTML = html
}


async function remove(id){
    respuesta = confirm('¿Estas seguro de querer eliminarlo?')
    if(respuesta){
        var url = URL_API + 'cocina/' + id
        await fetch(url, {
        "method": 'DELETE',
        "headers": {
            "Content-Type": 'application/json'
        }
        
    })
    window.location.reload();
    }
}

async function agregar(){
    if(respuesta){
        var url = URL_API + 'cocina'
        await fetch(url, {
        "method": 'POST',
        "headers": {
            "Content-Type": 'application/json'
        }
        
    })
    window.location.reload();
    }
}

//3:43:00
//49:00