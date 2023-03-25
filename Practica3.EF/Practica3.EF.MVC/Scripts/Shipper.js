
function factualizar(e) {
    e.preventDefault()

    Swal.fire({
        title: '¿Estas seguro?',
        text: "Confirmar para editar el registro!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Si, Actualizar!'
    }).then((result) => {
        if (result.isConfirmed) {
            const factualizar = document.getElementById('factualizar')
            Swal.fire(
                'Actualizado!',
                'Tu registro ha sido actualizado.',
                'success'
            )
            setTimeout(() => {
              factualizar.submit()
            }, 2000);
        }
    })
}

function fagregar(e) {
    e.preventDefault()
    const fagregar = document.getElementById('fagregar')
    setTimeout(() => {
        fagregar.submit()
    }, 2000);

    Swal.fire({
        position: 'center',
        icon: 'success',
        title: 'Se creo el registro exitosamente!',
        showConfirmButton: false,
        timer: 1500
    })
}
